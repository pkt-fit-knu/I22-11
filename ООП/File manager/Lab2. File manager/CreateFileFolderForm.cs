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
    public partial class CreateFileFolderForm : Form
    {
        private string _folderName = null;

        /*
         * 0 - створити папку
         * 1 - створити пустий файл
         */
        public CreateFileFolderForm(int actionType)
        {
            InitializeComponent();
            switch (actionType)
            {
                case 0 :
                    actionLabel.Text += "нову папку:";
                    break;
                case 1 :
                    actionLabel.Text += "пустий файл:";
                    break;
                default :
                    actionLabel.Text += "елемент поля:";
                    break;
            }
        }

        public string GetFileFolderName()
        {
            return _folderName;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            _folderName = folderNameEnter.Text;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
