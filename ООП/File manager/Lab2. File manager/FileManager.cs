using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Lab2.File_manager
{
    public class FileManager
    {
        public Field Field1 { get; set; }
        public Field Field2 { get; set; }
        public Field CurrentField { get; set; }
        public List<Disk> Disks { get; set; }

        public FileManager(ListView field1View, ListView field2View, TextBox field1Path, TextBox field2Path,
            ToolStrip disksView1, ToolStrip disksView2, Timer refresher, MainForm mainForm)
        {
            UpdateDisks();
            Field1 = new Field(field1View, field1Path, disksView1, Disks);
            Field2 = new Field(field2View, field2Path, disksView2, Disks);
            RefreshAll(mainForm);
            CurrentField = Field1;
            refresher.Enabled = true;
        }

        /*
         * Оновити список дисків у список Disks.
         * Якщо списку не існує, буде створено новий.
         */
        private void UpdateDisks()
        {
            if (Disks == null)
                Disks = new List<Disk>();
            if (Disks != null)
            {
                Disks.Clear();
                string[] disks = Directory.GetLogicalDrives();
                foreach (string disk in disks)
                {
                    DriveInfo drive = new DriveInfo(disk);
                    Disks.Add(new Disk(drive.Name, drive.Name, drive.DriveType, null));
                }
            }
        }

        /*
         * Відкрити елемент з індексом itemIndex у списку FieldElementList
         */
        public void OpenElement(MainForm mainForm)
        {
            if (CurrentField.FieldView.SelectedItems.Count == 0)
                return;
            int itemIndex = CurrentField.FieldView.Items.IndexOf(CurrentField.FieldView.SelectedItems[0]);
            bool needToUpdateFieldView = CurrentField.OpenElement(itemIndex);
            if (needToUpdateFieldView)
                mainForm.UpdateFieldView(CurrentField);
        }

        /*
         * Змінити поточне поле
         */
        public void ChangeCurrentField(int fieldIndex)
        {
            if (fieldIndex == 1)
                CurrentField = Field1;
            else
                CurrentField = Field2;
        }

        public void ChangeDisk(string diskName, int fieldIndex, MainForm mainForm)
        {
            if (fieldIndex == 1)
                Field1.ChangeDisk(diskName);
            else
                Field2.ChangeDisk(diskName);
            RefreshAll(mainForm);
        }

        public void RefreshAll(MainForm mainForm)
        {
            UpdateDisks();
            mainForm.UpdateDisksView(Field1, Disks);
            mainForm.UpdateDisksView(Field2, Disks);
            if (!Field1.UpdateField(Field1.OpenedElement))
                Field1.SetDisk(Disks);
            if (!Field2.UpdateField(Field2.OpenedElement))
                Field2.SetDisk(Disks);
            mainForm.UpdateFieldView(Field1);
            mainForm.UpdateFieldView(Field2);
        }

        /*
         * Створити нову папку чи дерево папок.
         * У разі існування папки чи неможливості створення виводяться відповідні повідомлення.
         */
        public void CreateFolder(MainForm mainForm)
        {
            CreateFileFolderForm createFolderForm = new CreateFileFolderForm(0);
            createFolderForm.ShowDialog(mainForm);
            string name = createFolderForm.GetFileFolderName();
            if (name == null)
                return;
            string path = CurrentField.OpenedElement.Path + @"\" + name;
            if (Directory.Exists(path))
            {
                MessageView.FolderExistError();
                return;
            }
            try
            {
                Directory.CreateDirectory(path);
            }
            catch
            {
                MessageView.FolderCreateError();
            }
            RefreshAll(mainForm);
        }

        /*
         * Створити новий пустий файл.
         * У разі існування файлу чи неможливості створення виводяться відповідні повідомлення.
         */
        public void CreateEmptyFile(MainForm mainForm)
        {
            CreateFileFolderForm createFolderForm = new CreateFileFolderForm(1);
            createFolderForm.ShowDialog(mainForm);
            string name = createFolderForm.GetFileFolderName();
            if (name == null)
                return;
            string Path = CurrentField.OpenedElement.Path + @"\" + name;
            if (System.IO.File.Exists(Path))
            {
                MessageView.FileExistError();
                return;
            }
            try
            {
                var newFile = new StreamWriter(Path);
                newFile.Close();
            }
            catch
            {
                MessageView.FileCreateError();
                return;
            }
            RefreshAll(mainForm);
        }

        /*
         * Вирізати в буфер обміну виділені файли, якщо action = 2
         * Копіювати в буфер обміну виділені файли, якщо action = 5
         */
        public void CopyCutSelectedToClipboard(byte action)
        {
            if (CurrentField.FieldView.SelectedItems.Count == 0 || (action != 2 && action != 5))
                return;
            var selectedItems = new System.Collections.Specialized.StringCollection();
            for (int i = 0; i < CurrentField.FieldView.SelectedItems.Count; i++)
            {
                int itemIndex = CurrentField.FieldView.Items.IndexOf(CurrentField.FieldView.SelectedItems[i]);
                if (!String.Equals(CurrentField.FieldElementList[itemIndex].Name, ".."))
                    selectedItems.Add(CurrentField.FieldElementList[itemIndex].Path);
            }
            byte[] moveEffect = new byte[] { action, 0, 0, 0 };
            MemoryStream dropEffect = new MemoryStream();
            dropEffect.Write(moveEffect, 0, moveEffect.Length);
            DataObject data = new DataObject();
            data.SetFileDropList(selectedItems);
            data.SetData("Preferred DropEffect", dropEffect);
            Clipboard.Clear();
            Clipboard.SetDataObject(data, true);
        }

        public void PasteFromClipboard(MainForm mainForm)
        {
            if (!Clipboard.ContainsFileDropList())
                return;
            IDataObject data = Clipboard.GetDataObject();
            string[] files = data.GetData(DataFormats.FileDrop) as string[];
            MemoryStream stream = data.GetData("Preferred DropEffect", true) as MemoryStream;
            if (stream == null)
                return;
            int flag = stream.ReadByte();
            if (flag != 2 && flag != 5)
                return;
            bool cut = (flag == 2);
            if (files != null)
            {
                if (cut)
                    CurrentField.ReplaceClipboard(files, CurrentField.OpenedElement.Path);
                else
                    CurrentField.CopyClipboard(files, CurrentField.OpenedElement.Path);
            }
            RefreshAll(mainForm);
        }

        public void RemoveSelected(MainForm mainForm)
        {
            CurrentField.RemoveSelected();
            RefreshAll(mainForm);
        }

        public void RenameSelected()
        {
            CurrentField.RenameSelected();
        }

        public void RenameSelected(string newName, MainForm mainForm)
        {
            CurrentField.RenameSelected(newName);
            RefreshAll(mainForm);
        }

        public void BeginRename()
        {
            if (CurrentField.FieldView.SelectedItems.Count == 0)
                return;
            int renameIndex = CurrentField.FieldView.Items.IndexOf(CurrentField.FieldView.SelectedItems[0]);
            CurrentField.FieldView.Items[renameIndex].BeginEdit();
        }

        public void CopySelected(MainForm mainForm)
        {
            if(CurrentField == Field1)
                CurrentField.CopySelected(Field2.OpenedElement.Path);
            else
                CurrentField.CopySelected(Field1.OpenedElement.Path);
            RefreshAll(mainForm);
        }

        public void ReplaceSelected(MainForm mainForm)
        {
            CurrentField.ReplaceSelected(CurrentField == Field1 ? Field2.OpenedElement.Path : Field1.OpenedElement.Path);
            RefreshAll(mainForm);
        }

        public void StartFindFiles()
        {
            var findForm = new FindForm(CurrentField.OpenedElement.Path, this);
            findForm.ShowDialog();
        }

        public void GoBack(MainForm mainForm)
        {
            if (CurrentField.GoBack())
                RefreshAll(mainForm);
        }

        public void GoForward(MainForm mainForm)
        {
            if(CurrentField.GoForward())
                RefreshAll(mainForm);
        }

        /*
         * Значення fieldNum = 1, якщо змінюється шлях першого поля,
         * значення fieldNum = 2, якщо змінюється шлях другого поля,
         */
        public void GoPath(string path, int fieldNum, MainForm mainForm)
        {
            switch (fieldNum)
            {
                case 1:
                    Field1.GoPath(path);
                    break;
                case 2:
                    Field2.GoPath(path);
                    break;
            }
            RefreshAll(mainForm);
        }

        public void FindFiles(string fileName, string searchPath, FindForm findForm)
        {
            if (!Directory.Exists(searchPath) || String.IsNullOrEmpty(fileName))
                return;
            string directoryName = Path.GetFileName(searchPath);
            if(directoryName != null && directoryName.Contains(fileName))
                findForm.AddResult(searchPath, fileName, true);
            var currentDirectory = new DirectoryInfo(searchPath);
            try
            {
                foreach (var file in currentDirectory.GetFiles())
                    if (file.Name.Contains(fileName))
                        findForm.AddResult(searchPath + @"\" + file.Name, fileName, false);
            }
            catch (Exception)
            {
                //Пропустити пошук файлу у цій директорії
            }
            try
            {
                foreach (var directory in currentDirectory.GetDirectories())
                    FindFiles(fileName, directory.FullName, findForm);
            }
            catch (Exception)
            {
                //Пропустити папки файлів у цій директорії
            }
        }

        public void MargeSelectedHTMLFiles(MainForm mainForm)
        {
            if (CurrentField.FieldView.SelectedItems.Count != 2)
                return;
            int firstFileIndex = CurrentField.FieldView.Items.IndexOf(CurrentField.FieldView.SelectedItems[0]);
            int secondFileIndex = CurrentField.FieldView.Items.IndexOf(CurrentField.FieldView.SelectedItems[1]);
            var firstFile = new FileInfo(CurrentField.FieldElementList[firstFileIndex].Path);
            var secondFile = new FileInfo(CurrentField.FieldElementList[secondFileIndex].Path);
            if (!firstFile.Exists || !secondFile.Exists ||
                (!String.Equals(firstFile.Extension, ".htm") && !String.Equals(firstFile.Extension, ".html")) ||
                (!String.Equals(secondFile.Extension, ".htm") && !String.Equals(secondFile.Extension, ".html")))
                return;
            StreamReader firstFileStream = new StreamReader(firstFile.FullName, Encoding.Default);
            StreamReader secondFileStream = new StreamReader(secondFile.FullName, Encoding.Default);
            string outputFile = firstFile.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(firstFile.Name) +
                                Path.GetFileNameWithoutExtension(secondFile.Name);
            while (System.IO.File.Exists(outputFile + @".html"))
                outputFile += @"1";
            outputFile += @".html";
            StreamWriter outputFileStream = new StreamWriter(outputFile, false, Encoding.Default);
            StringBuilder style = new StringBuilder();
            int isGetStyle = 0;
            string buffer = null;
            while ((buffer = firstFileStream.ReadLine()) != null)
            {
                outputFileStream.WriteLine(buffer);
                if (isGetStyle == 0)
                {
                    int startIndex = buffer.IndexOf(@"<style"), finishIndex = buffer.IndexOf(@"</style");
                    if (startIndex != -1 && finishIndex != -1)
                    {
                        style.Append(buffer.Substring(startIndex, finishIndex - startIndex + 1));
                        isGetStyle = 2;
                    }
                    else if (startIndex != -1)
                    {
                        style.AppendLine(buffer.Substring(startIndex));
                        isGetStyle = 1;
                    }
                }
                else if (isGetStyle == 1)
                {
                    int finishIndex = buffer.IndexOf(@"</style>");
                    if (finishIndex != -1)
                    {
                        style.Append(buffer.Substring(0, finishIndex));
                        isGetStyle = 2;
                    }
                    else
                        style.AppendLine(buffer);
                }
            }
            buffer = null;
            isGetStyle = 0;
            while ((buffer = secondFileStream.ReadLine()) != null)
            {
                if (isGetStyle == 0)
                {
                    int startIndex = buffer.IndexOf(@"<style"), finishIndex = buffer.IndexOf(@"</style");
                    if (startIndex != -1 && finishIndex != -1)
                    {
                        outputFileStream.WriteLine(buffer.Substring(0, startIndex) + style + buffer.Substring(finishIndex));
                        isGetStyle = 2;
                    }
                    else if (startIndex != -1)
                    {
                        outputFileStream.Write(buffer.Substring(0, startIndex) + style);
                        isGetStyle = 1;
                    }
                    else
                        outputFileStream.WriteLine(buffer);
                }
                else if (isGetStyle == 1)
                {
                    int finishIndex = buffer.IndexOf(@"</style>");
                    if (finishIndex != -1)
                    {
                        outputFileStream.WriteLine(buffer.Substring(finishIndex));
                        isGetStyle = 2;
                    }
                }
                else
                    outputFileStream.WriteLine(buffer);
            }
            firstFileStream.Close();
            secondFileStream.Close();
            outputFileStream.Close();
        }

        public void FindOnceWords()
        {
            if (CurrentField.FieldView.SelectedItems.Count != 1)
                return;
            int fileIndex = CurrentField.FieldView.Items.IndexOf(CurrentField.FieldView.SelectedItems[0]);
            var file = new FileInfo(CurrentField.FieldElementList[fileIndex].Path);
            if (!file.Exists || !String.Equals(file.Extension, ".txt"))
                return;
            StreamReader fileStream = new StreamReader(file.FullName, Encoding.Default);
            string outputFile = file.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(file.Name) + @"Result";
            while (System.IO.File.Exists(outputFile + @".txt"))
                outputFile += @"1";
            outputFile += @".txt";
            StreamWriter outputFileStream = new StreamWriter(outputFile, false, Encoding.Default);
            string buffer = null;
            var allWords = new List<string>();
            while ((buffer = fileStream.ReadLine()) != null)
            {
                string[] words = buffer.Split(' ');
                foreach (var word in words)
                    allWords.Add(word);
            }
            allWords.Sort();
            if (allWords.Count == 1)
                outputFileStream.WriteLine(allWords[0]);
            else if (allWords.Count == 2)
            {
                if (!allWords[0].Equals(allWords[1]))
                {
                    outputFileStream.WriteLine(allWords[0]);
                    outputFileStream.WriteLine(allWords[1]);
                }
            }
            else
            {
                if (!allWords[0].Equals(allWords[1]))
                    outputFileStream.WriteLine(allWords[0]);
                string firstWord = null, secondWord = null;
                foreach (var word in allWords)
                {
                    if (firstWord == null)
                        firstWord = word;
                    else if (secondWord == null)
                        secondWord = word;
                    else
                    {
                        if (!secondWord.Equals(firstWord) && !secondWord.Equals(word))
                            outputFileStream.WriteLine(secondWord);
                        firstWord = secondWord;
                        secondWord = word;
                    }
                }
                if(!secondWord.Equals(firstWord))
                    outputFileStream.WriteLine(secondWord);
                fileStream.Close();
                outputFileStream.Close();
            }
        }

        public void StartFindSubString()
        {
            if(CurrentField.FieldView.SelectedItems.Count != 1)
                return;
            int fileIndex = CurrentField.FieldView.Items.IndexOf(CurrentField.FieldView.SelectedItems[0]);
            var findSubStringForm = new FindSubStringForm(CurrentField.FieldElementList[fileIndex].Path, this);
            findSubStringForm.ShowDialog();
        }

        public void FindSubString(string subString, string filePath, FindSubStringForm findSubStringForm)
        {
            if (!System.IO.File.Exists(filePath) || String.IsNullOrEmpty(subString))
                return;
            var file = new FileInfo(filePath);
            if (!file.Exists || !String.Equals(file.Extension, ".txt"))
                return;
            StreamReader fileStream = new StreamReader(file.FullName, Encoding.Default);
            string buffer = null;
            int line = 1;
            while ((buffer = fileStream.ReadLine()) != null)
            {
                if (buffer.Contains(subString))
                    findSubStringForm.AddResult(buffer, subString, line);
                line++;
            }
            fileStream.Close();
        }
    }
}
