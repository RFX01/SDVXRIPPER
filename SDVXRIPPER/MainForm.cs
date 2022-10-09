using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Lame;
using System.IO;

namespace SDVXRIPPER
{
    public partial class MainForm : Form
    {

        RipperConfiguration configuration;

        public MainForm()
        {
            InitializeComponent();
            configuration = new RipperConfiguration();
        }

        private LAMEPreset getLamePresetEnumByIndex(int index)
        {
            int counter = 0;
            foreach (int value in Enum.GetValues(typeof(LAMEPreset)))
            {
                if (counter == index)
                {
                    return (LAMEPreset)value;
                }
                counter++;
            }
            return LAMEPreset.ABR_320; // default value if method fails to find something
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // Set Default Values
            artistTaggingBox.SelectedIndex = 0;
            titleTaggingBox.SelectedIndex = 0;
            List<string> lamePresets = Enum.GetNames(typeof(NAudio.Lame.LAMEPreset)).ToList();
            foreach (var preset in lamePresets)
            {
                codecQualityBox.Items.Add(preset);
            }
            codecQualityBox.SelectedIndex = 9;
        }

        private void browseSourceButton_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                sourceDirTextBox.Text = folderBrowser.SelectedPath;
                configuration.sourceDir = folderBrowser.SelectedPath;
            }
        }

        private void browseOutputButton_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                outputDirTextBox.Text = folderBrowser.SelectedPath;
                configuration.targetDir = folderBrowser.SelectedPath;
            }
        }

        private void artistTaggingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            configuration.artistTagging = (TaggingStyle)artistTaggingBox.SelectedIndex;
        }

        private void titleTaggingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            configuration.titleTagging = (TaggingStyle)titleTaggingBox.SelectedIndex;
        }

        private void codecQualityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            configuration.lamePreset = getLamePresetEnumByIndex(codecQualityBox.SelectedIndex);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            bool checksPassed = true;
            if (configuration.sourceDir == null || configuration.targetDir == null)
            {
                MessageBox.Show("Please select the source and target directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checksPassed = false;
            }

            if (configuration.sourceDir != null && !Directory.Exists(Path.Combine(configuration.sourceDir, "music")))
            {
                MessageBox.Show("The directory 'music' could not be found in the source directory. Please ensure you selected the correct directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checksPassed = false;
            }

            if (configuration.sourceDir != null && !File.Exists(Path.Combine(configuration.sourceDir, "others", "music_db.xml")))
            {
                MessageBox.Show(@"The file 'others\music_db.xml' could not be found in the source directory. Please ensure you selected the correct directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checksPassed = false;
            }

            if (checksPassed)
            {
                new WorkerDialog(configuration).ShowDialog();
            }
        }
    }
}
