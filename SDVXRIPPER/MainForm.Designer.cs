
namespace SDVXRIPPER
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseSourceButton = new System.Windows.Forms.Button();
            this.sourceDirTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.browseOutputButton = new System.Windows.Forms.Button();
            this.outputDirTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titleTaggingBox = new System.Windows.Forms.ComboBox();
            this.artistTaggingBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.codecQualityBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browseSourceButton);
            this.groupBox1.Controls.Add(this.sourceDirTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SDVX Data Dir";
            // 
            // browseSourceButton
            // 
            this.browseSourceButton.Location = new System.Drawing.Point(506, 19);
            this.browseSourceButton.Name = "browseSourceButton";
            this.browseSourceButton.Size = new System.Drawing.Size(25, 21);
            this.browseSourceButton.TabIndex = 1;
            this.browseSourceButton.Text = "...";
            this.browseSourceButton.UseVisualStyleBackColor = true;
            this.browseSourceButton.Click += new System.EventHandler(this.browseSourceButton_Click);
            // 
            // sourceDirTextBox
            // 
            this.sourceDirTextBox.Location = new System.Drawing.Point(7, 20);
            this.sourceDirTextBox.Name = "sourceDirTextBox";
            this.sourceDirTextBox.ReadOnly = true;
            this.sourceDirTextBox.Size = new System.Drawing.Size(493, 20);
            this.sourceDirTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.browseOutputButton);
            this.groupBox2.Controls.Add(this.outputDirTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Dir";
            // 
            // browseOutputButton
            // 
            this.browseOutputButton.Location = new System.Drawing.Point(506, 19);
            this.browseOutputButton.Name = "browseOutputButton";
            this.browseOutputButton.Size = new System.Drawing.Size(25, 21);
            this.browseOutputButton.TabIndex = 1;
            this.browseOutputButton.Text = "...";
            this.browseOutputButton.UseVisualStyleBackColor = true;
            this.browseOutputButton.Click += new System.EventHandler(this.browseOutputButton_Click);
            // 
            // outputDirTextBox
            // 
            this.outputDirTextBox.Location = new System.Drawing.Point(7, 20);
            this.outputDirTextBox.Name = "outputDirTextBox";
            this.outputDirTextBox.ReadOnly = true;
            this.outputDirTextBox.Size = new System.Drawing.Size(493, 20);
            this.outputDirTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.titleTaggingBox);
            this.groupBox3.Controls.Add(this.artistTaggingBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 109);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tagging Style";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Track Names";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Artist Names";
            // 
            // titleTaggingBox
            // 
            this.titleTaggingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.titleTaggingBox.FormattingEnabled = true;
            this.titleTaggingBox.Items.AddRange(new object[] {
            "Original",
            "Yomigana"});
            this.titleTaggingBox.Location = new System.Drawing.Point(10, 76);
            this.titleTaggingBox.Name = "titleTaggingBox";
            this.titleTaggingBox.Size = new System.Drawing.Size(246, 21);
            this.titleTaggingBox.TabIndex = 1;
            this.titleTaggingBox.SelectedIndexChanged += new System.EventHandler(this.titleTaggingBox_SelectedIndexChanged);
            // 
            // artistTaggingBox
            // 
            this.artistTaggingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.artistTaggingBox.FormattingEnabled = true;
            this.artistTaggingBox.Items.AddRange(new object[] {
            "Original",
            "Yomigana"});
            this.artistTaggingBox.Location = new System.Drawing.Point(10, 36);
            this.artistTaggingBox.Name = "artistTaggingBox";
            this.artistTaggingBox.Size = new System.Drawing.Size(246, 21);
            this.artistTaggingBox.TabIndex = 0;
            this.artistTaggingBox.SelectedIndexChanged += new System.EventHandler(this.artistTaggingBox_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.codecQualityBox);
            this.groupBox4.Location = new System.Drawing.Point(287, 126);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(262, 54);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "LAME Preset";
            // 
            // codecQualityBox
            // 
            this.codecQualityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codecQualityBox.FormattingEnabled = true;
            this.codecQualityBox.Location = new System.Drawing.Point(6, 20);
            this.codecQualityBox.Name = "codecQualityBox";
            this.codecQualityBox.Size = new System.Drawing.Size(250, 21);
            this.codecQualityBox.TabIndex = 4;
            this.codecQualityBox.SelectedIndexChanged += new System.EventHandler(this.codecQualityBox_SelectedIndexChanged);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(287, 186);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(262, 49);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 248);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(578, 287);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(578, 287);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "SDVX Ripper";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseSourceButton;
        private System.Windows.Forms.TextBox sourceDirTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button browseOutputButton;
        private System.Windows.Forms.TextBox outputDirTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox titleTaggingBox;
        private System.Windows.Forms.ComboBox artistTaggingBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox codecQualityBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}

