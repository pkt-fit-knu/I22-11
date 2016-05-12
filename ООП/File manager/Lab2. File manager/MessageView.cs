using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2.File_manager
{
    static class MessageView
    {
        public static DialogResult NoAvaliableDisksMessage()
        {
            return MessageBox.Show(
                null,
                "Диск не готовий до використання",
                "Попередження",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Warning
            );
        }

        public static void FileFolderGettingError()
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                "Помилка зчитування списку файлів у поточній директорії",
                "Попередження",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FolderExistError()
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                "Папка вже існує. Будь ласка, введіть інше ім'я папки.",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static void FolderCreateError()
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                "Не можливо створити папку з таким ім'ям у поточній директорії.",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FileExistError()
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                "Файл вже існує. Будь ласка, введіть інше ім'я файлу.",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static void FileCreateError()
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                "Не можливо створити файл з таким ім'ям у поточній директорії.",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FileCopyError(string filePath)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо скопіювати файл {0}", filePath),
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FileCopyExistError(string filePath)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо скопіювати файл {0}\nФайл вже існує.", filePath),
                "Попередження",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static void FolderCopyError(string folderPath)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо скопіювати папку {0}", folderPath),
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FileRemoveError(string filePath)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо видалити файл {0}", filePath),
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FolderRemoveError(string folderPath)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо видалити папку {0}", folderPath),
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FileRenameError(string fileName)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо перейменувати файл {0}", fileName),
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FileRenameExistError(string fileName)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо перейменувати файл {0}\nФайл з таким іменем вже існує.", fileName),
                "Попередження",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static void FolderRenameError(string folderName)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо перейменувати папку {0}", folderName),
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void FolderRenameExistError(string folderName)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Не можливо перейменувати папку {0}\nПапка з таким іменем вже існує.", folderName),
                "Попередження",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        public static DialogResult ElementDeleteDialog(string folderName)
        {
            DialogResult msgboxID = MessageBox.Show(
                null,
                string.Format("Ви дійсно хочете видалити файл {0}?", folderName),
                "Попередження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            return msgboxID;
        }
    }
}
