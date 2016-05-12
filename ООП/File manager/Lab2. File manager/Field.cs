using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;

namespace Lab2.File_manager
{
    public class Field
    {
        public TextBox FieldPath { get; set; }
        public ListView FieldView { get; set; }
        public ToolStrip DisksView { get; set; }
        public IFieldElement OpenedElement { get; set; }
        public List<IFieldElement> FieldElementList { get; set; }
        private int _renameIndex = -1;

        public Field(ListView fieldView, TextBox fieldPath, ToolStrip disksView, List<Disk> disks)
        {
            FieldView = fieldView;
            FieldPath = fieldPath;
            DisksView = disksView;
            OpenedElement = null;
            FieldElementList = new List<IFieldElement>();
            SetDisk(disks);
        }

        /*
         * Спробувати змінити диск, тобто оновити змінну OpenedElement.
         * У разі неможливості зміни диску буде показане відповідне повідомлення,
         * стан змінної OpenedElement зберігається.
         */
        public bool SetDisk(List<Disk> disks)
        {
            IFieldElement openedElement = null;
            foreach(Disk disk in disks)
            {
                DriveInfo drive = new DriveInfo(disk.Name);
                if (drive.IsReady)
                {
                    openedElement = new Disk(drive.Name, drive.Name, drive.DriveType, openedElement);
                    break;
                }
            }
            if (openedElement == null)
            {
                DialogResult msgboxID = MessageView.NoAvaliableDisksMessage();
                if (msgboxID == DialogResult.Retry)
                    return SetDisk(disks);
                return false;
            }
            if (UpdateField(openedElement))
            {
                OpenedElement = openedElement;
                return true;
            }
            return false;
        }        

        /*
         * Спробувати отримати список папок і файлів у OpenedElement.
         * Якщо поточний шлях не диск, то першою папкою є "..".
         * Спершу виводиться список папок, далі файлів.
         * У разі помилки зчитування список елементів не змінюється.
         */
        public bool UpdateField(IFieldElement openedElement)
        {
            if (openedElement == null)
            {
                MessageView.FileFolderGettingError();
                return false;
            }
            try
            {
                List<IFieldElement> fieldElementList = new List<IFieldElement>();
                if (!(openedElement is Disk))
                {
                    if (String.Compare(Directory.GetParent(openedElement.Path).Root.FullName,
                        Directory.GetParent(openedElement.Path).FullName) != 0)
                        fieldElementList.Add(new Folder("..", Directory.GetParent(openedElement.Path).FullName, openedElement));
                    else
                        fieldElementList.Add(new Disk("..", Directory.GetParent(openedElement.Path).FullName,
                            new DriveInfo(Directory.GetParent(openedElement.Path).FullName).DriveType, openedElement));
                }
                DirectoryInfo openedElementInfo = new DirectoryInfo(openedElement.Path);
                //Отримуємо список папок
                DirectoryInfo[] fieldDirectories = openedElementInfo.GetDirectories();
                foreach (DirectoryInfo fieldDirectory in fieldDirectories)
                    fieldElementList.Add(new Folder(fieldDirectory.Name, fieldDirectory.FullName, openedElement));
                //Отримуємо список файлів
                FileInfo[] fieldFiles = openedElementInfo.GetFiles();
                foreach (FileInfo fieldFile in fieldFiles)
                {
                    
                    //WshShell shell = new WshShell();
                    //WshShortcut shortcut = shell.CreateShortcut(fieldFile.FullName) as WshShortcut;
                    //var temp = shortcut.TargetPath;
                    //Console.WriteLine(shortcut.TargetPath);
                    fieldElementList.Add(new File(Path.GetFileNameWithoutExtension(fieldFile.Name),
                        fieldFile.FullName, fieldFile.Extension, fieldFile.Length, openedElement));
                }
                FieldElementList = fieldElementList;
            }
            catch
            {
                MessageView.FileFolderGettingError();
                return false;
            }
            return true;
        }

        /*
         * Повертає значення true, якщо потрібно оновити поле.
         */
        public bool OpenElement(int itemIndex)
        {
            bool needToUpdateField = FieldElementList[itemIndex].Open();
            if (needToUpdateField)
            {
                IFieldElement openedElement = FieldElementList[itemIndex];
                openedElement.Prev = OpenedElement;
                if (UpdateField(openedElement))
                {
                    OpenedElement = openedElement;
                    return true;
                }
            }
            return false;
        }

        public bool ChangeDisk(string diskName)
        {
            List<Disk> disks = new List<Disk>();
            DriveInfo drive = new DriveInfo(diskName);
            disks.Add(new Disk(drive.Name, drive.Name, drive.DriveType, null));
            return SetDisk(disks);
        }

        public void CopyClipboard(string[] elements, string dest)
        {
            if (OpenedElement == null || elements == null)
                return;
            foreach (string element in elements)
            {
                if(Directory.Exists(element))
                {
                    Folder currentFolder = new Folder(Path.GetFileName(element), element, null);
                    currentFolder.Copy(dest);
                }
                else if (System.IO.File.Exists(element))
                {
                    FileInfo file = new FileInfo(element);
                    File currentFile = new File(Path.GetFileNameWithoutExtension(file.Name),
                        file.FullName, file.Extension, file.Length, null);
                    currentFile.Copy(dest);
                }
            }
        }

        public void ReplaceClipboard(string[] elements, string dest)
        {
            if (OpenedElement == null || elements == null)
                return;
            foreach (string element in elements)
            {
                if (Directory.Exists(element))
                {
                    Folder currentFolder = new Folder(Path.GetFileName(element), element, null);
                    currentFolder.Replace(dest);
                }
                else if (System.IO.File.Exists(element))
                {
                    FileInfo file = new FileInfo(element);
                    File currentFile = new File(Path.GetFileNameWithoutExtension(file.Name),
                        file.FullName, file.Extension, file.Length, null);
                    currentFile.Replace(dest);
                }
            }
        }

        public void CopySelected(string dest)
        {
            if (OpenedElement == null || dest == null || FieldView.SelectedItems.Count == 0)
                return;
            for (int i = 0; i < FieldView.SelectedItems.Count; i++)
            {
                int itemIndex = FieldView.Items.IndexOf(FieldView.SelectedItems[i]);
                FieldElementList[itemIndex].Copy(dest);
            }
        }

        public void ReplaceSelected(string dest)
        {
            if (OpenedElement == null || dest == null || FieldView.SelectedItems.Count == 0)
                return;
            for (int i = 0; i < FieldView.SelectedItems.Count; i++)
            {
                int itemIndex = FieldView.Items.IndexOf(FieldView.SelectedItems[i]);
                FieldElementList[itemIndex].Replace(dest);
            }
        }

        public void RemoveSelected()
        {
            if (FieldView.SelectedItems.Count == 0)
                return;
            for (int i = 0; i < FieldView.SelectedItems.Count; i++)
            {
                int itemIndex = FieldView.Items.IndexOf(FieldView.SelectedItems[i]);
                var msgResul = MessageView.ElementDeleteDialog(FieldElementList[itemIndex].Path);
                if (msgResul == DialogResult.Yes)
                    FieldElementList[itemIndex].Remove();
            }
        }

        public void RenameSelected()
        {
            if (FieldView.SelectedItems.Count == 0)
            {
                _renameIndex = -1;
                return;
            }
            _renameIndex = FieldView.Items.IndexOf(FieldView.SelectedItems[0]);
        }

        public bool RenameSelected(string newName)
        {
            if (_renameIndex == -1)
                return false;
            if (FieldElementList[_renameIndex].Rename(newName))
            {
                _renameIndex = -1;
                return true;
            }
            _renameIndex = -1;
            return false;
        }

        public void GoUp()
        {
            
        }

        public bool GoBack()
        {
            if (OpenedElement.Prev != null)
            {
                OpenedElement.Prev.Next = OpenedElement;
                OpenedElement = OpenedElement.Prev;
                return true;
            }
            return false;
        }

        public bool GoForward()
        {
            if (OpenedElement.Next != null)
            {
                OpenedElement.Next.Prev = OpenedElement;
                OpenedElement = OpenedElement.Next;
                return true;
            }
            return false;
        }

        public void GoPath(string path)
        {
            if (string.IsNullOrEmpty(path) || OpenedElement.Path == path)
                return;
            if(Path.GetPathRoot(path) == path && (new DriveInfo(path).IsReady))
            {
                var openedDriveInfo = new DriveInfo(path);
                var openedElement = new Disk(openedDriveInfo.Name,
                    openedDriveInfo.Name,
                    openedDriveInfo.DriveType,
                    OpenedElement);
                if (UpdateField(openedElement))
                    OpenedElement = openedElement;
            }
            else if (Directory.Exists(path))
            {
                var openedDirectoryInfo = new DirectoryInfo(path);
                var openedElement = new Folder(openedDirectoryInfo.Name,
                    openedDirectoryInfo.FullName,
                    OpenedElement);
                if (UpdateField(openedElement))
                    OpenedElement = openedElement;
            }
            else if(System.IO.File.Exists(path))
            {
                var openedFileInfo = new FileInfo(path);
                var openedElement = new File(
                    openedFileInfo.Name,
                    openedFileInfo.FullName,
                    openedFileInfo.Extension,
                    openedFileInfo.Length,
                    OpenedElement);
                if (UpdateField(openedElement))
                    OpenedElement = openedElement;
            }
        }
    }
}
