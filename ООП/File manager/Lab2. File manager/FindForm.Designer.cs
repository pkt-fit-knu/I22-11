namespace Lab2.File_manager
{
    partial class FindForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindForm));
            this.аctionLabel = new System.Windows.Forms.Label();
            this.fileNameEnter = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.searchPathEnter = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.searchResults = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // аctionLabel
            // 
            this.аctionLabel.AutoSize = true;
            this.аctionLabel.Location = new System.Drawing.Point(12, 9);
            this.аctionLabel.Name = "аctionLabel";
            this.аctionLabel.Size = new System.Drawing.Size(120, 13);
            this.аctionLabel.TabIndex = 0;
            this.аctionLabel.Text = "Шукати файли і папки:";
            // 
            // fileNameEnter
            // 
            this.fileNameEnter.Location = new System.Drawing.Point(138, 6);
            this.fileNameEnter.Name = "fileNameEnter";
            this.fileNameEnter.Size = new System.Drawing.Size(326, 20);
            this.fileNameEnter.TabIndex = 1;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(470, 4);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(87, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "Почати пошук";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(54, 35);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(78, 13);
            this.pathLabel.TabIndex = 3;
            this.pathLabel.Text = "Місце пошуку:";
            // 
            // searchPathEnter
            // 
            this.searchPathEnter.Location = new System.Drawing.Point(138, 32);
            this.searchPathEnter.Name = "searchPathEnter";
            this.searchPathEnter.Size = new System.Drawing.Size(326, 20);
            this.searchPathEnter.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(470, 30);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Відмінити";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(12, 68);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(107, 13);
            this.resultLabel.TabIndex = 7;
            this.resultLabel.Text = "Результати пошуку:";
            // 
            // searchResults
            // 
            this.searchResults.BackColor = System.Drawing.SystemColors.Window;
            this.searchResults.Location = new System.Drawing.Point(12, 84);
            this.searchResults.Name = "searchResults";
            this.searchResults.ReadOnly = true;
            this.searchResults.Size = new System.Drawing.Size(545, 247);
            this.searchResults.TabIndex = 8;
            this.searchResults.Text = "";
            // 
            // FindForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(569, 343);
            this.Controls.Add(this.searchResults);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.searchPathEnter);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.fileNameEnter);
            this.Controls.Add(this.аctionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пошук файлів";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label аctionLabel;
        private System.Windows.Forms.TextBox fileNameEnter;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TextBox searchPathEnter;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.RichTextBox searchResults;
    }
}