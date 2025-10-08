using System.Windows.Input;

namespace Acty.Skillup.FileCopy
{
    partial class FileCopy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileCopy));
            this.ButtonFileSelect = new System.Windows.Forms.Button();
            this.ButtonFolderSelect = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.TextBoxFilePath = new System.Windows.Forms.TextBox();
            this.TextBoxFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.LabelBytes = new System.Windows.Forms.Label();
            this.LabelPercent = new System.Windows.Forms.Label();
            this.ProgressBarPercent = new System.Windows.Forms.ProgressBar();
            this.LabelTimeRemaining = new System.Windows.Forms.Label();
            this.LabelSpeed = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ButtonFileSelect
            // 
            this.ButtonFileSelect.Location = new System.Drawing.Point(490, 12);
            this.ButtonFileSelect.Name = "ButtonFileSelect";
            this.ButtonFileSelect.Size = new System.Drawing.Size(75, 21);
            this.ButtonFileSelect.TabIndex = 0;
            this.ButtonFileSelect.Tag = "";
            this.ButtonFileSelect.Text = "&File...\r\n";
            this.ButtonFileSelect.UseVisualStyleBackColor = true;
            this.ButtonFileSelect.Click += new System.EventHandler(this.ButtonFile_Click);
            // 
            // ButtonFolderSelect
            // 
            this.ButtonFolderSelect.Location = new System.Drawing.Point(490, 53);
            this.ButtonFolderSelect.Name = "ButtonFolderSelect";
            this.ButtonFolderSelect.Size = new System.Drawing.Size(75, 21);
            this.ButtonFolderSelect.TabIndex = 2;
            this.ButtonFolderSelect.Text = "F&older...";
            this.ButtonFolderSelect.UseVisualStyleBackColor = true;
            this.ButtonFolderSelect.Click += new System.EventHandler(this.ButtonFolderSelect_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(258, 96);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonStart.TabIndex = 4;
            this.ButtonStart.Text = "&Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.Start_Click);
            // 
            // TextBoxFilePath
            // 
            this.TextBoxFilePath.Location = new System.Drawing.Point(109, 12);
            this.TextBoxFilePath.Name = "TextBoxFilePath";
            this.TextBoxFilePath.Size = new System.Drawing.Size(375, 20);
            this.TextBoxFilePath.TabIndex = 1;
            // 
            // TextBoxFolderPath
            // 
            this.TextBoxFolderPath.Location = new System.Drawing.Point(109, 53);
            this.TextBoxFolderPath.Name = "TextBoxFolderPath";
            this.TextBoxFolderPath.Size = new System.Drawing.Size(375, 20);
            this.TextBoxFolderPath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Destination:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // LabelBytes
            // 
            this.LabelBytes.AutoSize = true;
            this.LabelBytes.Location = new System.Drawing.Point(23, 138);
            this.LabelBytes.Name = "LabelBytes";
            this.LabelBytes.Size = new System.Drawing.Size(33, 13);
            this.LabelBytes.TabIndex = 17;
            this.LabelBytes.Text = "Bytes";
            this.LabelBytes.Visible = false;
            // 
            // LabelPercent
            // 
            this.LabelPercent.AutoSize = true;
            this.LabelPercent.Location = new System.Drawing.Point(544, 138);
            this.LabelPercent.Name = "LabelPercent";
            this.LabelPercent.Size = new System.Drawing.Size(21, 13);
            this.LabelPercent.TabIndex = 16;
            this.LabelPercent.Text = "0%";
            this.LabelPercent.Visible = false;
            // 
            // ProgressBarPercent
            // 
            this.ProgressBarPercent.Location = new System.Drawing.Point(26, 154);
            this.ProgressBarPercent.MarqueeAnimationSpeed = 10;
            this.ProgressBarPercent.Name = "ProgressBarPercent";
            this.ProgressBarPercent.Size = new System.Drawing.Size(539, 23);
            this.ProgressBarPercent.Step = 0;
            this.ProgressBarPercent.TabIndex = 15;
            this.ProgressBarPercent.Visible = false;
            // 
            // LabelTimeRemaining
            // 
            this.LabelTimeRemaining.AutoSize = true;
            this.LabelTimeRemaining.Location = new System.Drawing.Point(23, 180);
            this.LabelTimeRemaining.Name = "LabelTimeRemaining";
            this.LabelTimeRemaining.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.LabelTimeRemaining.Size = new System.Drawing.Size(30, 23);
            this.LabelTimeRemaining.TabIndex = 18;
            this.LabelTimeRemaining.Text = "Time";
            this.LabelTimeRemaining.Visible = false;
            // 
            // LabelSpeed
            // 
            this.LabelSpeed.AutoSize = true;
            this.LabelSpeed.Location = new System.Drawing.Point(459, 180);
            this.LabelSpeed.Name = "LabelSpeed";
            this.LabelSpeed.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.LabelSpeed.Size = new System.Drawing.Size(38, 23);
            this.LabelSpeed.TabIndex = 19;
            this.LabelSpeed.Text = "Speed";
            this.LabelSpeed.Visible = false;
            // 
            // FileCopy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(594, 140);
            this.Controls.Add(this.LabelSpeed);
            this.Controls.Add(this.LabelTimeRemaining);
            this.Controls.Add(this.LabelBytes);
            this.Controls.Add(this.LabelPercent);
            this.Controls.Add(this.ProgressBarPercent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxFolderPath);
            this.Controls.Add(this.TextBoxFilePath);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.ButtonFolderSelect);
            this.Controls.Add(this.ButtonFileSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(610, 322);
            this.MinimumSize = new System.Drawing.Size(610, 179);
            this.Name = "FileCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileCopy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button ButtonFileSelect;
        public System.Windows.Forms.Button ButtonFolderSelect;
        public System.Windows.Forms.Button ButtonStart;
        public System.Windows.Forms.TextBox TextBoxFilePath;
        public System.Windows.Forms.TextBox TextBoxFolderPath;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Label LabelBytes;
        public System.Windows.Forms.Label LabelPercent;
        public System.Windows.Forms.ProgressBar ProgressBarPercent;
        public System.Windows.Forms.Label LabelTimeRemaining;
        public System.Windows.Forms.Label LabelSpeed;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

