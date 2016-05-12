using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.File_manager
{
    public partial class FindSubStringForm : Form
    {
        private FileManager _fm = null;

        public FindSubStringForm(string filePath, FileManager fm)
        {
            InitializeComponent();
            filePathEnter.Text = filePath ?? "";
            _fm = fm;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            searchResults.Clear();
            string subString = subStringEnter.Text;
            _fm.FindSubString(subString, filePathEnter.Text, this);
            int i = searchResults.Text.IndexOf(subString);
            while (i >= 0 && searchResults.Text.Length - subString.Length >= 0 && subString.Length > 0)
            {
                searchResults.SelectionStart = i;
                searchResults.SelectionLength = subString.Length;
                searchResults.SelectionBackColor = Color.Red;
                i = searchResults.Text.IndexOf(subString, i + subString.Length);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void AddResult(string resultString, string subString, int line)
        {
            searchResults.AppendText(line.ToString() + ". " + resultString + "\n");
        }
    }
}
