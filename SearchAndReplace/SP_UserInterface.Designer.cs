namespace SearchAndReplace
{
    partial class SP_UserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SP_UserInterface));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.paramtersAffectedListBox = new System.Windows.Forms.CheckedListBox();
            this.exitAppParameterButton = new System.Windows.Forms.Button();
            this.submitSRParameterButton = new System.Windows.Forms.Button();
            this.toggleAffectedElementsOnButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.categoriesCheckList = new System.Windows.Forms.CheckedListBox();
            this.toggleCategoriesOnButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ExactFind_Checkbox = new System.Windows.Forms.CheckBox();
            this.populateParametersAffectedButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.replaceParameterTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.findParameterTextBox = new System.Windows.Forms.TextBox();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox6.Controls.Add(this.paramtersAffectedListBox);
            this.groupBox6.Controls.Add(this.exitAppParameterButton);
            this.groupBox6.Controls.Add(this.submitSRParameterButton);
            this.groupBox6.Controls.Add(this.toggleAffectedElementsOnButton);
            this.groupBox6.Location = new System.Drawing.Point(12, 428);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(366, 230);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Affected Elements";
            // 
            // paramtersAffectedListBox
            // 
            this.paramtersAffectedListBox.FormattingEnabled = true;
            this.paramtersAffectedListBox.Location = new System.Drawing.Point(45, 34);
            this.paramtersAffectedListBox.Name = "paramtersAffectedListBox";
            this.paramtersAffectedListBox.Size = new System.Drawing.Size(265, 123);
            this.paramtersAffectedListBox.TabIndex = 0;
            // 
            // exitAppParameterButton
            // 
            this.exitAppParameterButton.Location = new System.Drawing.Point(47, 184);
            this.exitAppParameterButton.Name = "exitAppParameterButton";
            this.exitAppParameterButton.Size = new System.Drawing.Size(97, 39);
            this.exitAppParameterButton.TabIndex = 6;
            this.exitAppParameterButton.Text = "Cancel";
            this.exitAppParameterButton.UseVisualStyleBackColor = true;
            this.exitAppParameterButton.Click += new System.EventHandler(this.exitAppParameterButton_Click);
            // 
            // submitSRParameterButton
            // 
            this.submitSRParameterButton.Location = new System.Drawing.Point(213, 184);
            this.submitSRParameterButton.Name = "submitSRParameterButton";
            this.submitSRParameterButton.Size = new System.Drawing.Size(97, 39);
            this.submitSRParameterButton.TabIndex = 5;
            this.submitSRParameterButton.Text = "Submit";
            this.submitSRParameterButton.UseVisualStyleBackColor = true;
            this.submitSRParameterButton.Click += new System.EventHandler(this.submitSRParameterButton_Click);
            // 
            // toggleAffectedElementsOnButton
            // 
            this.toggleAffectedElementsOnButton.Location = new System.Drawing.Point(306, 34);
            this.toggleAffectedElementsOnButton.Name = "toggleAffectedElementsOnButton";
            this.toggleAffectedElementsOnButton.Size = new System.Drawing.Size(28, 28);
            this.toggleAffectedElementsOnButton.TabIndex = 7;
            this.toggleAffectedElementsOnButton.Text = "+";
            this.toggleAffectedElementsOnButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toggleAffectedElementsOnButton.UseVisualStyleBackColor = true;
            this.toggleAffectedElementsOnButton.Click += new System.EventHandler(this.toggleAffectedElementsOnButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox5.Controls.Add(this.filterButton);
            this.groupBox5.Controls.Add(this.categoriesCheckList);
            this.groupBox5.Controls.Add(this.toggleCategoriesOnButton);
            this.groupBox5.Location = new System.Drawing.Point(12, 224);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(366, 198);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filter Categories";
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(129, 153);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(97, 39);
            this.filterButton.TabIndex = 9;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // categoriesCheckList
            // 
            this.categoriesCheckList.FormattingEnabled = true;
            this.categoriesCheckList.Location = new System.Drawing.Point(45, 31);
            this.categoriesCheckList.Name = "categoriesCheckList";
            this.categoriesCheckList.Size = new System.Drawing.Size(265, 106);
            this.categoriesCheckList.TabIndex = 9;
            this.categoriesCheckList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.categoriesCheckList_ItemCheck);
            // 
            // toggleCategoriesOnButton
            // 
            this.toggleCategoriesOnButton.Location = new System.Drawing.Point(306, 31);
            this.toggleCategoriesOnButton.Name = "toggleCategoriesOnButton";
            this.toggleCategoriesOnButton.Size = new System.Drawing.Size(28, 29);
            this.toggleCategoriesOnButton.TabIndex = 9;
            this.toggleCategoriesOnButton.Text = "+";
            this.toggleCategoriesOnButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toggleCategoriesOnButton.UseVisualStyleBackColor = true;
            this.toggleCategoriesOnButton.Click += new System.EventHandler(this.toggleCategoriesOnButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox4.Controls.Add(this.ExactFind_Checkbox);
            this.groupBox4.Controls.Add(this.populateParametersAffectedButton);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.replaceParameterTextBox);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.findParameterTextBox);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(366, 206);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            // 
            // ExactFind_Checkbox
            // 
            this.ExactFind_Checkbox.AutoSize = true;
            this.ExactFind_Checkbox.Location = new System.Drawing.Point(265, 21);
            this.ExactFind_Checkbox.Name = "ExactFind_Checkbox";
            this.ExactFind_Checkbox.Size = new System.Drawing.Size(91, 20);
            this.ExactFind_Checkbox.TabIndex = 5;
            this.ExactFind_Checkbox.Text = "Exact Find";
            this.ExactFind_Checkbox.UseVisualStyleBackColor = true;
            this.ExactFind_Checkbox.CheckedChanged += new System.EventHandler(this.ExactFind_Checkbox_CheckedChanged);
            // 
            // populateParametersAffectedButton
            // 
            this.populateParametersAffectedButton.Location = new System.Drawing.Point(129, 158);
            this.populateParametersAffectedButton.Name = "populateParametersAffectedButton";
            this.populateParametersAffectedButton.Size = new System.Drawing.Size(97, 42);
            this.populateParametersAffectedButton.TabIndex = 4;
            this.populateParametersAffectedButton.Text = "Search";
            this.populateParametersAffectedButton.UseVisualStyleBackColor = true;
            this.populateParametersAffectedButton.Click += new System.EventHandler(this.populateParametersAffectedButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Replace";
            // 
            // replaceParameterTextBox
            // 
            this.replaceParameterTextBox.Location = new System.Drawing.Point(45, 111);
            this.replaceParameterTextBox.Name = "replaceParameterTextBox";
            this.replaceParameterTextBox.Size = new System.Drawing.Size(265, 22);
            this.replaceParameterTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find";
            // 
            // findParameterTextBox
            // 
            this.findParameterTextBox.Location = new System.Drawing.Point(45, 54);
            this.findParameterTextBox.Name = "findParameterTextBox";
            this.findParameterTextBox.Size = new System.Drawing.Size(265, 22);
            this.findParameterTextBox.TabIndex = 0;
            // 
            // SP_UserInterface
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(394, 675);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SP_UserInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search and Replace";
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exitAppParameterButton;
        private System.Windows.Forms.Button submitSRParameterButton;
        private System.Windows.Forms.CheckedListBox paramtersAffectedListBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button populateParametersAffectedButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox replaceParameterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox findParameterTextBox;
        private System.Windows.Forms.Button toggleAffectedElementsOnButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox categoriesCheckList;
        private System.Windows.Forms.Button toggleCategoriesOnButton;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.CheckBox ExactFind_Checkbox;
    }
}