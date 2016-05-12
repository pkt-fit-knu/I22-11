using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.File_manager
{
    public interface IFieldElement
    {
        string Name { get; set; }
        string Path { get; set; }
        string Type { get; set; }
        IFieldElement Prev { get; set; }
        IFieldElement Next { get; set; }
        void Copy(string dest);
        bool Replace(string dest);
        bool Rename(string newName);
        bool Open();
        bool Remove();
    }
}
