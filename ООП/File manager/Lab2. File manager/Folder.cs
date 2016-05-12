using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace Lab2.File_manager
{
    class Folder : IFieldElement
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public IFieldElement Prev { get; set; }
        public IFieldElement Next { get; set; }

        public Folder(string name, string path, IFieldElement prev)
        {
            Name = name;
            Path = path;
            Type = "<Папка>";
            Prev = prev;
            Next = null;
        }

        public void Copy(string dest)
        {
            if (dest.Contains(Path))
            {
                MessageView.FolderCopyError(Path);
                return;
            }
            try
            {
                DirectoryInfo currentDirectory = new DirectoryInfo(Path);
                dest = dest + @"\" + Name;
                if (!Directory.Exists(dest))
                    Directory.CreateDirectory(dest);
                foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
                {
                    if (!Directory.Exists(dest + @"\" + dir.Name))
                        Directory.CreateDirectory(dest + @"\" + dir.Name);
                    Folder currentFolder = new Folder(dir.Name, dir.FullName, null);
                    currentFolder.Copy(dest);
                }
                foreach (FileInfo file in currentDirectory.GetFiles())
                {
                    File currentFile = new File(System.IO.Path.GetFileNameWithoutExtension(file.Name),
                        file.FullName, file.Extension, file.Length, null);
                    currentFile.Copy(dest);
                }
            }
            catch (IOException)
            {
                MessageView.FolderCopyError(Path);
            }
        }

        public bool Replace(string dest)
        {
            if (dest.Contains(Path))
            {
                MessageView.FolderCopyError(Path);
                return false;
            }
            try
            {
                DirectoryInfo currentDirectory = new DirectoryInfo(Path);
                dest = dest + @"\" + Name;
                if (!Directory.Exists(dest))
                    Directory.CreateDirectory(dest);
                foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
                {
                    if (!Directory.Exists(dest + @"\" + dir.Name))
                        Directory.CreateDirectory(dest + @"\" + dir.Name);
                    Folder currentFolder = new Folder(dir.Name, dir.FullName, null);
                    currentFolder.Replace(dest);
                }
                foreach (FileInfo file in currentDirectory.GetFiles())
                {
                    File currentFile = new File(System.IO.Path.GetFileNameWithoutExtension(file.Name),
                        file.FullName, file.Extension, file.Length, null);
                    currentFile.Replace(dest);
                }
                currentDirectory.Delete();
                return true;
            }
            catch (IOException)
            {
                MessageView.FolderCopyError(Path);
                return false;
            }
        }

        public bool Rename(string newName)
        {
            if(newName == null)
                return true;
            string newPath = System.IO.Path.GetDirectoryName(Path) + @"\" + newName;
            if (String.Equals(Path, newPath))
                return true;
            if (System.IO.Directory.Exists(newPath))
            {
                MessageView.FolderRenameExistError(Path);
                return false;
            }
            try
            {
                System.IO.Directory.Move(Path, newPath);
                Name = newName;
                Path = newPath;
                return true;
            }
            catch (IOException)
            {
                MessageView.FolderRenameError(Path);
                return false;
            }
        }

        public bool Open()
        {
            return true;
        }

        public bool Remove()
        {
            try
            {
                DirectoryInfo currentDirectory = new DirectoryInfo(Path);
                foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
                {
                    Folder currentFolder = new Folder(dir.Name, dir.FullName, null);
                    currentFolder.Remove();
                }
                foreach (FileInfo file in currentDirectory.GetFiles())
                {
                    File currentFile = new File(System.IO.Path.GetFileNameWithoutExtension(file.Name),
                        file.FullName, file.Extension, file.Length, null);
                    currentFile.Remove();
                }
                currentDirectory.Delete();
                return true;
            }
            catch (IOException)
            {
                MessageView.FolderRemoveError(Path);
                return false;
            }
        }
    }
}
