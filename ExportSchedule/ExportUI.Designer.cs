namespace F_OS.ExportPlugins.ExportSchedule
{
    partial class ExportUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportUI));
            this.exportButton = new System.Windows.Forms.Button();
            this.schedulesListBox = new System.Windows.Forms.CheckedListBox();
            this.toggleSchedules = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toggleSheetsButton = new System.Windows.Forms.Button();
            this.applySheets = new System.Windows.Forms.Button();
            this.sheetsNotMatched = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.referenceButton = new System.Windows.Forms.Button();
            this.sheetsListBox = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.exportSheetsNotMatched = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(283, 387);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(91, 43);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // schedulesListBox
            // 
            this.schedulesListBox.FormattingEnabled = true;
            this.schedulesListBox.Location = new System.Drawing.Point(6, 21);
            this.schedulesListBox.Name = "schedulesListBox";
            this.schedulesListBox.Size = new System.Drawing.Size(592, 344);
            this.schedulesListBox.TabIndex = 1;
            // 
            // toggleSchedules
            // 
            this.toggleSchedules.Location = new System.Drawing.Point(246, 395);
            this.toggleSchedules.Name = "toggleSchedules";
            this.toggleSchedules.Size = new System.Drawing.Size(31, 27);
            this.toggleSchedules.TabIndex = 3;
            this.toggleSchedules.Text = "+";
            this.toggleSchedules.UseVisualStyleBackColor = true;
            this.toggleSchedules.Click += new System.EventHandler(this.toggleSchedules_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.schedulesListBox);
            this.groupBox1.Controls.Add(this.exportButton);
            this.groupBox1.Controls.Add(this.toggleSchedules);
            this.groupBox1.Location = new System.Drawing.Point(619, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 436);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedules";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exportSheetsNotMatched);
            this.groupBox2.Controls.Add(this.applySheets);
            this.groupBox2.Controls.Add(this.sheetsNotMatched);
            this.groupBox2.Controls.Add(this.toggleSheetsButton);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.referenceButton);
            this.groupBox2.Controls.Add(this.sheetsListBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 436);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sheets";
            // 
            // toggleSheetsButton
            // 
            this.toggleSheetsButton.Location = new System.Drawing.Point(115, 395);
            this.toggleSheetsButton.Name = "toggleSheetsButton";
            this.toggleSheetsButton.Size = new System.Drawing.Size(31, 27);
            this.toggleSheetsButton.TabIndex = 4;
            this.toggleSheetsButton.Text = "+";
            this.toggleSheetsButton.UseVisualStyleBackColor = true;
            this.toggleSheetsButton.Click += new System.EventHandler(this.toggleSheetsButton_Click);
            // 
            // applySheets
            // 
            this.applySheets.Location = new System.Drawing.Point(346, 386);
            this.applySheets.Name = "applySheets";
            this.applySheets.Size = new System.Drawing.Size(91, 44);
            this.applySheets.TabIndex = 7;
            this.applySheets.Text = "Apply";
            this.applySheets.UseVisualStyleBackColor = true;
            this.applySheets.Click += new System.EventHandler(this.applySheets_Click);
            // 
            // sheetsNotMatched
            // 
            this.sheetsNotMatched.FormattingEnabled = true;
            this.sheetsNotMatched.ItemHeight = 16;
            this.sheetsNotMatched.Location = new System.Drawing.Point(6, 269);
            this.sheetsNotMatched.Name = "sheetsNotMatched";
            this.sheetsNotMatched.Size = new System.Drawing.Size(589, 100);
            this.sheetsNotMatched.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(6, 269);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(589, 96);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // referenceButton
            // 
            this.referenceButton.Location = new System.Drawing.Point(152, 386);
            this.referenceButton.Name = "referenceButton";
            this.referenceButton.Size = new System.Drawing.Size(91, 44);
            this.referenceButton.TabIndex = 5;
            this.referenceButton.Text = "Import";
            this.referenceButton.UseVisualStyleBackColor = true;
            this.referenceButton.Click += new System.EventHandler(this.referenceButton_Click);
            // 
            // sheetsListBox
            // 
            this.sheetsListBox.FormattingEnabled = true;
            this.sheetsListBox.Location = new System.Drawing.Point(6, 21);
            this.sheetsListBox.Name = "sheetsListBox";
            this.sheetsListBox.Size = new System.Drawing.Size(589, 242);
            this.sheetsListBox.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // exportSheetsNotMatched
            // 
            this.exportSheetsNotMatched.Enabled = false;
            this.exportSheetsNotMatched.Location = new System.Drawing.Point(249, 386);
            this.exportSheetsNotMatched.Name = "exportSheetsNotMatched";
            this.exportSheetsNotMatched.Size = new System.Drawing.Size(91, 44);
            this.exportSheetsNotMatched.TabIndex = 8;
            this.exportSheetsNotMatched.Text = "Export";
            this.exportSheetsNotMatched.UseVisualStyleBackColor = true;
            this.exportSheetsNotMatched.Click += new System.EventHandler(this.exportSheetsNotMatched_Click);
            // 
            // ExportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1235, 460);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Export";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.CheckedListBox schedulesListBox;
        private System.Windows.Forms.Button toggleSchedules;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox sheetsListBox;
        private System.Windows.Forms.Button referenceButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button applySheets;
        private System.Windows.Forms.ListBox sheetsNotMatched;
        private System.Windows.Forms.Button toggleSheetsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button exportSheetsNotMatched;
    }
}