using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2.File_manager
{
    public class Disk : IFieldElement
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public DriveType DiskType { get; set; }
        public IFieldElement Prev { get; set; }
        public IFieldElement Next { get; set; }

        public Disk(string name, string path, DriveType diskType, IFieldElement prev)
        {
            Name = name;
            Path = path;
            DiskType = diskType;
            Type = GetDiskType(diskType);
            Prev = prev;
            Next = null;
        }

        private string GetDiskType(DriveType diskType)
        {
            if (diskType == DriveType.CDRom)
                return "<CD-дисковод>";
            else if (diskType == DriveType.Fixed)
                return "<Локальний диск>";
            else if (diskType == DriveType.Network)
                return "<Диск мережі>";
            else if (diskType == DriveType.NoRootDirectory)
                return "<Диск без кореневого каталогу>";
            else if (diskType == DriveType.Ram)
                return "<Диск ОЗУ>";
            else if (diskType == DriveType.Removable)
                return "<Зйомний диск>";
            else
                return "<Невідомий тип диску>";
        }

        public void Copy(string dest)
        {
            //Заглушка
        }

        public bool Replace(string dest)
        {
            return false;
        }

        public bool Rename(string newName)
        {
            return false;
        }

        public bool Open()
        {
            return true;
        }

        public bool Remove()
        {
            return false;
        }
    }
}
