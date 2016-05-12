using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.File_manager
{
    class File : IFieldElement
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public long Size;
        public IFieldElement Prev { get; set; }
        public IFieldElement Next { get; set; }

        public File(string name, string path, string type, long size, IFieldElement prev)
        {
            Name = name;
            Path = path;
            Type = type;
            Size = size;
            Prev = prev;
            Next = null;
        }

        public void Copy(string dest)
        {
            if (System.IO.File.Exists(dest + @"\" + Name + Type))
            {
                MessageView.FileCopyExistError(Path);
                return;
            }
            try
            {
                System.IO.File.Copy(Path, dest + @"\" + Name + Type, false);
            }
            catch (IOException)
            {
                MessageView.FileCopyError(Path);
            }
        }

        public bool Replace(string dest)
        {
            if (System.IO.File.Exists(dest + @"\" + Name + Type))
            {
                MessageView.FileCopyExistError(Path);
                return false;
            }
            try
            {
                System.IO.File.Move(Path, dest + @"\" + Name + Type);
                return true;
            }
            catch (IOException)
            {
                MessageView.FileCopyError(Path);
                return false;
            }
        }

        public bool Rename(string newName)
        {
            if (newName == null)
                return true;
            string newPath = System.IO.Path.GetDirectoryName(Path) + @"\" + newName + Type;
            if (String.Equals(Path, newPath))
                return true;
            if (System.IO.File.Exists(newPath))
            {
                MessageView.FileRenameExistError(Path);
                return false;
            }
            try
            {
                System.IO.File.Move(Path, newPath);
                Name = newName;
                Path = newPath;
                return true;
            }
            catch (IOException)
            {
                MessageView.FileRenameError(Path);
                return false;
            }   
        }

        public bool Open()
        {
            System.Diagnostics.Process.Start(Path);
            return false;
        }

        public bool Remove()
        {
            try
            {
                System.IO.File.Delete(Path);
                return true;
            }
            catch (IOException)
            {
                MessageView.FileRemoveError(Path);
                return false;
            }
        }
    }
}
