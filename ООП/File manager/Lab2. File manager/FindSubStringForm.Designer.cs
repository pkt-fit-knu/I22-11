namespace Lab2.File_manager
{
    partial class FindSubStringForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindSubStringForm));
            this.searchResults = new System.Windows.Forms.RichTextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.filePathEnter = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.subStringEnter = new System.Windows.Forms.TextBox();
            this.аctionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchResults
            // 
            this.searchResults.BackColor = System.Drawing.SystemColors.Window;
            this.searchResults.Location = new System.Drawing.Point(10, 83);
            this.searchResults.Name = "searchResults";
            this.searchResults.ReadOnly = true;
            this.searchResults.Size = new System.Drawing.Size(545, 247);
            this.searchResults.TabIndex = 16;
            this.searchResults.Text = "";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(10, 67);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(107, 13);
            this.resultLabel.TabIndex = 15;
            this.resultLabel.Text = "Результати пошуку:";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(468, 29);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Відмінити";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // filePathEnter
            // 
            this.filePathEnter.Location = new System.Drawing.Point(96, 31);
            this.filePathEnter.Name = "filePathEnter";
            this.filePathEnter.Size = new System.Drawing.Size(366, 20);
            this.filePathEnter.TabIndex = 13;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(12, 34);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(78, 13);
            this.pathLabel.TabIndex = 12;
            this.pathLabel.Text = "Файл пошуку:";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(468, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(87, 23);
            this.OKButton.TabIndex = 11;
            this.OKButton.Text = "Почати пошук";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // subStringEnter
            // 
            this.subStringEnter.Location = new System.Drawing.Point(96, 5);
            this.subStringEnter.Name = "subStringEnter";
            this.subStringEnter.Size = new System.Drawing.Size(366, 20);
            this.subStringEnter.TabIndex = 10;
            // 
            // аctionLabel
            // 
            this.аctionLabel.AutoSize = true;
            this.аctionLabel.Location = new System.Drawing.Point(10, 8);
            this.аctionLabel.Name = "аctionLabel";
            this.аctionLabel.Size = new System.Drawing.Size(80, 13);
            this.аctionLabel.TabIndex = 9;
            this.аctionLabel.Text = "Шукати рядок:";
            // 
            // FindSubStringForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(564, 338);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.filePathEnter);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.subStringEnter);
            this.Controls.Add(this.аctionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindSubStringForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FindSubStringForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox searchResults;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox filePathEnter;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox subStringEnter;
        private System.Windows.Forms.Label аctionLabel;
    }
}