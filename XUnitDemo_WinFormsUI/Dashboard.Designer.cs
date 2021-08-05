
namespace XUnitDemo_WinFormsUI
{
    partial class Dashboard
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
            this.databaseSectionGroup = new System.Windows.Forms.GroupBox();
            this.addPersonButton = new System.Windows.Forms.Button();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameText = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.firstNameText = new System.Windows.Forms.TextBox();
            this.usersLabel = new System.Windows.Forms.Label();
            this.usersDropdown = new System.Windows.Forms.ComboBox();
            this.calculateSection = new System.Windows.Forms.GroupBox();
            this.divideButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.subtractButton = new System.Windows.Forms.Button();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.resultsText = new System.Windows.Forms.TextBox();
            this.secondNumberValue = new System.Windows.Forms.NumericUpDown();
            this.firstNumberValue = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.secondNumberLabel = new System.Windows.Forms.Label();
            this.firstNumberLabel = new System.Windows.Forms.Label();
            this.databaseSectionGroup.SuspendLayout();
            this.calculateSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondNumberValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNumberValue)).BeginInit();
            this.SuspendLayout();
            // 
            // databaseSectionGroup
            // 
            this.databaseSectionGroup.Controls.Add(this.addPersonButton);
            this.databaseSectionGroup.Controls.Add(this.lastNameLabel);
            this.databaseSectionGroup.Controls.Add(this.lastNameText);
            this.databaseSectionGroup.Controls.Add(this.firstNameLabel);
            this.databaseSectionGroup.Controls.Add(this.firstNameText);
            this.databaseSectionGroup.Controls.Add(this.usersLabel);
            this.databaseSectionGroup.Controls.Add(this.usersDropdown);
            this.databaseSectionGroup.Location = new System.Drawing.Point(446, 61);
            this.databaseSectionGroup.Name = "databaseSectionGroup";
            this.databaseSectionGroup.Size = new System.Drawing.Size(393, 287);
            this.databaseSectionGroup.TabIndex = 0;
            this.databaseSectionGroup.TabStop = false;
            this.databaseSectionGroup.Text = "Database Section";
            // 
            // addPersonButton
            // 
            this.addPersonButton.Location = new System.Drawing.Point(94, 215);
            this.addPersonButton.Name = "addPersonButton";
            this.addPersonButton.Size = new System.Drawing.Size(171, 39);
            this.addPersonButton.TabIndex = 6;
            this.addPersonButton.Text = "Add Person";
            this.addPersonButton.UseVisualStyleBackColor = true;
            this.addPersonButton.Click += new System.EventHandler(this.addPersonButton_Click);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(20, 168);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(115, 25);
            this.lastNameLabel.TabIndex = 5;
            this.lastNameLabel.Text = "Last Name";
            // 
            // lastNameText
            // 
            this.lastNameText.Location = new System.Drawing.Point(142, 165);
            this.lastNameText.Name = "lastNameText";
            this.lastNameText.Size = new System.Drawing.Size(192, 31);
            this.lastNameText.TabIndex = 4;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(20, 131);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(116, 25);
            this.firstNameLabel.TabIndex = 3;
            this.firstNameLabel.Text = "First Name";
            // 
            // firstNameText
            // 
            this.firstNameText.Location = new System.Drawing.Point(142, 128);
            this.firstNameText.Name = "firstNameText";
            this.firstNameText.Size = new System.Drawing.Size(192, 31);
            this.firstNameText.TabIndex = 2;
            // 
            // usersLabel
            // 
            this.usersLabel.AutoSize = true;
            this.usersLabel.Location = new System.Drawing.Point(20, 76);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(68, 25);
            this.usersLabel.TabIndex = 1;
            this.usersLabel.Text = "Users";
            // 
            // usersDropdown
            // 
            this.usersDropdown.FormattingEnabled = true;
            this.usersDropdown.Location = new System.Drawing.Point(94, 73);
            this.usersDropdown.Name = "usersDropdown";
            this.usersDropdown.Size = new System.Drawing.Size(240, 33);
            this.usersDropdown.TabIndex = 0;
            // 
            // calculateSection
            // 
            this.calculateSection.Controls.Add(this.divideButton);
            this.calculateSection.Controls.Add(this.multiplyButton);
            this.calculateSection.Controls.Add(this.subtractButton);
            this.calculateSection.Controls.Add(this.resultsLabel);
            this.calculateSection.Controls.Add(this.resultsText);
            this.calculateSection.Controls.Add(this.secondNumberValue);
            this.calculateSection.Controls.Add(this.firstNumberValue);
            this.calculateSection.Controls.Add(this.addButton);
            this.calculateSection.Controls.Add(this.secondNumberLabel);
            this.calculateSection.Controls.Add(this.firstNumberLabel);
            this.calculateSection.Location = new System.Drawing.Point(34, 61);
            this.calculateSection.Name = "calculateSection";
            this.calculateSection.Size = new System.Drawing.Size(393, 287);
            this.calculateSection.TabIndex = 7;
            this.calculateSection.TabStop = false;
            this.calculateSection.Text = "Calculate Section";
            // 
            // divideButton
            // 
            this.divideButton.Location = new System.Drawing.Point(35, 239);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(146, 39);
            this.divideButton.TabIndex = 12;
            this.divideButton.Text = "Divide";
            this.divideButton.UseVisualStyleBackColor = true;
            this.divideButton.Click += new System.EventHandler(this.divideButton_Click);
            // 
            // multiplyButton
            // 
            this.multiplyButton.Location = new System.Drawing.Point(35, 200);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(146, 39);
            this.multiplyButton.TabIndex = 11;
            this.multiplyButton.Text = "Multiply";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new System.EventHandler(this.multiplyButton_Click);
            // 
            // subtractButton
            // 
            this.subtractButton.Location = new System.Drawing.Point(35, 162);
            this.subtractButton.Name = "subtractButton";
            this.subtractButton.Size = new System.Drawing.Size(146, 39);
            this.subtractButton.TabIndex = 10;
            this.subtractButton.Text = "Subtract";
            this.subtractButton.UseVisualStyleBackColor = true;
            this.subtractButton.Click += new System.EventHandler(this.subtractButton_Click);
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(211, 171);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(84, 25);
            this.resultsLabel.TabIndex = 7;
            this.resultsLabel.Text = "Results";
            // 
            // resultsText
            // 
            this.resultsText.Location = new System.Drawing.Point(216, 200);
            this.resultsText.Name = "resultsText";
            this.resultsText.Size = new System.Drawing.Size(120, 31);
            this.resultsText.TabIndex = 9;
            // 
            // secondNumberValue
            // 
            this.secondNumberValue.Location = new System.Drawing.Point(216, 76);
            this.secondNumberValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.secondNumberValue.Name = "secondNumberValue";
            this.secondNumberValue.Size = new System.Drawing.Size(120, 31);
            this.secondNumberValue.TabIndex = 8;
            // 
            // firstNumberValue
            // 
            this.firstNumberValue.Location = new System.Drawing.Point(216, 39);
            this.firstNumberValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.firstNumberValue.Name = "firstNumberValue";
            this.firstNumberValue.Size = new System.Drawing.Size(120, 31);
            this.firstNumberValue.TabIndex = 7;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(35, 124);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(146, 39);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // secondNumberLabel
            // 
            this.secondNumberLabel.AutoSize = true;
            this.secondNumberLabel.Location = new System.Drawing.Point(30, 78);
            this.secondNumberLabel.Name = "secondNumberLabel";
            this.secondNumberLabel.Size = new System.Drawing.Size(166, 25);
            this.secondNumberLabel.TabIndex = 5;
            this.secondNumberLabel.Text = "Second Number";
            // 
            // firstNumberLabel
            // 
            this.firstNumberLabel.AutoSize = true;
            this.firstNumberLabel.Location = new System.Drawing.Point(30, 41);
            this.firstNumberLabel.Name = "firstNumberLabel";
            this.firstNumberLabel.Size = new System.Drawing.Size(135, 25);
            this.firstNumberLabel.TabIndex = 3;
            this.firstNumberLabel.Text = "First Number";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 710);
            this.Controls.Add(this.calculateSection);
            this.Controls.Add(this.databaseSectionGroup);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Dashboard";
            this.Text = "Demo Dashboard by Tim Corey";
            this.databaseSectionGroup.ResumeLayout(false);
            this.databaseSectionGroup.PerformLayout();
            this.calculateSection.ResumeLayout(false);
            this.calculateSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondNumberValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstNumberValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox databaseSectionGroup;
        private System.Windows.Forms.Button addPersonButton;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameText;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameText;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.ComboBox usersDropdown;
        private System.Windows.Forms.GroupBox calculateSection;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button subtractButton;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.TextBox resultsText;
        private System.Windows.Forms.NumericUpDown secondNumberValue;
        private System.Windows.Forms.NumericUpDown firstNumberValue;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label secondNumberLabel;
        private System.Windows.Forms.Label firstNumberLabel;
    }
}