using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SDVXRIPPER
{
    public partial class WorkerDialog : Form
    {
        RipperConfiguration configuration;
        List<BackgroundWorker> workers;
        int threadCount;
        int songProgress;
        int totalSongs;
        int finishedWorkers;

        public WorkerDialog(RipperConfiguration config)
        {
            InitializeComponent();
            configuration = config;
            threadCount = Environment.ProcessorCount;
            songProgress = 0;
            finishedWorkers = 0;
            // Workaround to make label seem transparent (sort of)
            progressLabel.Parent = progressBar;
            progressLabel.Location = new Point(5, 5);
            progressLabel.BackColor = Color.FromArgb(6, 176, 37);
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }

        private void WorkerDialog_Load(object sender, EventArgs e)
        {
            // Configure and Start BackgroundWorkers
            workers = new List<BackgroundWorker>();
            List<WorkerConfiguration> workerConfigs = new List<WorkerConfiguration>();

            // Get Music DB from game files
            XDocument musicDb = new XDocument();
            musicDb = XDocument.Load(Path.Combine(configuration.sourceDir, "others", "music_db.xml"));

            // Get Songs
            List<string> allSongs = new List<string>();
            allSongs.AddRange(Directory.GetDirectories(Path.Combine(configuration.sourceDir, "music")));
            totalSongs = allSongs.Count;
            progressBar.Maximum = totalSongs;

            // Initialize song lists for all workers
            List<List<string>> workerSongLists = new List<List<string>>();
            for (int i = 0; i < threadCount; i++)
            {
                workerSongLists.Add(new List<string>());
            }

            // Split song list for multithreading
            int currentList = 0;
            for (int i = 0; i < allSongs.Count; i++)
            {
                workerSongLists[currentList].Add(allSongs[i]);
                // Go back to list 0 if threads are exhausted
                currentList++;
                if (currentList >= threadCount)
                {
                    currentList = 0;
                }
            }

            // Create and run workers
            for (int i = 0; i < threadCount; i++)
            {
                logBox.AppendText($"Configuring and starting worker for Thread {i + 1}.\n");
                workers.Add(new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true });
                workerConfigs.Add(new WorkerConfiguration(configuration, workerSongLists[i], musicDb));
                workers[i].ProgressChanged += Worker_ProgressChanged;
                workers[i].RunWorkerCompleted += Worker_RunCompleted;
                workers[i].DoWork += Worker_DoWork;
                workers[i].RunWorkerAsync(workerConfigs[i]);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            songProgress++;
            progressBar.Value = songProgress;
            progressLabel.Text = $"{songProgress}/{totalSongs}";
            logBox.AppendText((string)e.UserState);
        }

        private void Worker_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logBox.AppendText($"Thread finished.\n");
            finishedWorkers++;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker me = (BackgroundWorker)sender;
            WorkerConfiguration workerConfig = (WorkerConfiguration)e.Argument;
            XDocument musicDb = workerConfig.musicDb;
            List<string> songs = workerConfig.trackPaths;
            RipperConfiguration config = workerConfig.configuration;
            for (int i = 0; i < songs.Count; i++)
            {
                // Get Song ID from path
                int songId = int.Parse(Path.GetFileName(songs[i]).Split('_')[0]);

                // Ensure song file actually exists
                if (!File.Exists(Path.Combine(songs[i], $"{Path.GetFileName(songs[i])}.s3v")))
                {
                    me.ReportProgress(0, $"Could not find audio data for song {Path.GetFileName(songs[i])}\n");
                    continue;
                }

                // Get Metadata from Music DB
                string artist;
                string title;

                // Get Relevant XElement
                XElement selectedElement = null;
                var elements = musicDb.Elements("mdb").Elements("music");
                foreach (var element in elements)
                {
                    if (int.Parse(element.Attribute("id").Value) == songId)
                    {
                        selectedElement = element;
                    }
                }

                // Retrieve Metadata from XML
                if (selectedElement != null)
                {
                    if (config.artistTagging == TaggingStyle.Original)
                    {
                        artist = selectedElement.Elements("info").Elements("artist_name").First().Value;
                    }
                    else
                    {
                        artist = selectedElement.Elements("info").Elements("artist_yomigana").First().Value;
                    }

                    if (config.titleTagging == TaggingStyle.Original)
                    {
                        title = selectedElement.Elements("info").Elements("title_name").First().Value;
                    }
                    else
                    {
                        title = selectedElement.Elements("info").Elements("title_yomigana").First().Value;
                    }
                }
                else
                {
                    // Fallback if file is not found in music db
                    title = "MISSING DB DATA";
                    artist = "MISSING DB DATA";
                }

                // Convert song to MP3
                string mp3Path;
                if (selectedElement != null)
                {
                    mp3Path = Path.Combine(config.targetDir, MakeValidFileName($"{songId.ToString("0000")} - {artist} - {title}.mp3"));
                }
                else
                {
                    // Fallback if file is not found in music db
                    mp3Path = Path.Combine(config.targetDir, MakeValidFileName($"{Path.GetFileName(songs[i])}.mp3"));
                }
                string mp3TempPath = Path.Combine(Path.GetTempPath(), $"song_{songId}.mp3"); // temp path to avoid access errors if user has target dir open in explorer
                using (var reader = new NAudio.Wave.AudioFileReader(Path.Combine(songs[i], $"{Path.GetFileName(songs[i])}.s3v")))
                using (var writer = new NAudio.Lame.LameMP3FileWriter(mp3TempPath, reader.WaveFormat, config.lamePreset))
                {
                    reader.CopyTo(writer);
                }

                // Add Tags to MP3
                using (var mp3File = TagLib.File.Create(mp3TempPath))
                {
                    mp3File.Tag.Track = (uint)songId;
                    mp3File.Tag.Title = title;
                    mp3File.Tag.Performers = new string[] { artist };
                    mp3File.Tag.AlbumArtists = new string[] { "Various Artists" };
                    mp3File.Tag.Album = "SDVX OST";
                    mp3File.Tag.Comment = "Ripped using SDVXRIPPER.";
                    mp3File.Save();
                }

                // Move file to target location and overwrite already existing file
                if (File.Exists(mp3Path))
                {
                    File.Delete(mp3Path);
                }
                File.Move(mp3TempPath, mp3Path);

                // Report Progress
                me.ReportProgress(0, $"Finished processing song {Path.GetFileName(songs[i])}\n");

                // Cancel if requested
                if(me.CancellationPending == true)
                {
                    break;
                }
            }
        }

        private void logBox_TextChanged(object sender, EventArgs e)
        {
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        private void WorkerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finishedWorkers != threadCount)
            {
                DialogResult r = MessageBox.Show("Are you sure you want to cancel?", "Cancelling...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    // Request worker cancellation
                    foreach (BackgroundWorker b in workers)
                    {
                        b.CancelAsync();
                    }
                    // Keep dialog open until all workers have cancelled
                    bool waitForCancel = true;
                    while (waitForCancel)
                    {
                        bool allDone = true;
                        foreach (BackgroundWorker b in workers)
                        {
                            if (b.IsBusy)
                            {
                                allDone = false;
                            }
                        }
                        waitForCancel = !allDone;
                        // Prevent deadlock and unnecessary cpu usage
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(100);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
