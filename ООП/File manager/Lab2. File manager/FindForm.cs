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

namespace Lab2.File_manager
{
    public partial class FindForm : Form
    {
        private FileManager _fm = null;

        public FindForm(string searchPath, FileManager fm)
        {
            InitializeComponent();
            searchPathEnter.Text = searchPath ?? "";
            _fm = fm;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            searchResults.Clear();
            _fm.FindFiles(fileNameEnter.Text, searchPathEnter.Text, this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void AddResult(string resultPath, string fileName, bool isDirectory)
        {
            searchResults.AppendText(resultPath);
            int i = searchResults.Text.LastIndexOf("\\");
            i = searchResults.Text.IndexOf(fileName, i);
            if (i >= 0)
            {
                searchResults.SelectionStart = i;
                searchResults.SelectionLength = fileName.Length;
                searchResults.SelectionBackColor = Color.Red;
            }
            searchResults.AppendText(isDirectory ? "\\\n" : "\n");
            searchResults.SelectionStart = searchResults.TextLength - (isDirectory ? 2 : 1);
            searchResults.SelectionLength = 1;
            searchResults.SelectionBackColor = searchResults.BackColor;
        }
    }
}
