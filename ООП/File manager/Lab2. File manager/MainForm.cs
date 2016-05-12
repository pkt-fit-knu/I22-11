using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2.File_manager
{
    public partial class MainForm : Form
    {
        FileManager FM;

        public MainForm()
        {
            InitializeComponent();
            FM = new FileManager(field1View, field2View, field1Path, field2Path, disksView1, disksView2, refresher, this);
            UpdateFormSize();
        }

        /*
         * Повертає 0 у випадку неспівпадіння розміру списків або імен файлів чи папок
         * Повертає 1 у випадку неспівпадіння розмірів деяких файлів чи неспівпадінні ОДНОГО елементу
         * Повертає 2 у випадку рівності списків
         */
        private int ListEquals(ListView.ListViewItemCollection list1, List<ListViewItem> list2)
        {
            int notEqualsCount = 0;
            bool fullEqual = true;
            if (list1.Count != list2.Count)
                return 0;
            else
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    if (!String.Equals(list1[i].SubItems[0].Text, list2[i].SubItems[0].Text) ||
                        !String.Equals(list1[i].SubItems[1].Text, list2[i].SubItems[1].Text))
                    {
                        if (notEqualsCount > 0)
                            return 0;
                        notEqualsCount++;
                    }
                    else if (!String.Equals(list1[i].SubItems[2].Text, list2[i].SubItems[2].Text))
                        fullEqual = false;
                }
                if(fullEqual && notEqualsCount == 0)
                    return 2;
                else
                    return 1;
            }
        }

        /*
         * Зробити тимчасовий список елементів, для того, щоб перевірити,
         * чи потрібно і як потрібно оновлювати список елементів FieldView
         */
        private void MakeTempItemsList(Field field, List<ListViewItem> tempItemsList)
        {
            if (tempItemsList == null)
                tempItemsList = new List<ListViewItem>();
            /*
             * отримуємо список папок і файлів
             * параметри ListViewItem.Add
             *  0 - папки
             *  1 - файли
             *  2 - папка вгору
             */
            foreach (IFieldElement fieldElement in field.FieldElementList)
            {
                if (fieldElement is Folder || fieldElement is Disk)
                {
                    string[] listViewItemData = new string[field1View.Columns.Count];
                    listViewItemData[0] = fieldElement.Name;
                    listViewItemData[1] = fieldElement.Type;
                    listViewItemData[2] = "";
                    tempItemsList.Add(fieldElement.Name == ".."
                        ? new ListViewItem(listViewItemData, 2)
                        : new ListViewItem(listViewItemData, 0));
                }
                else if (fieldElement is File)
                {
                    string[] listViewItemData = new string[field1View.Columns.Count];
                    listViewItemData[0] = fieldElement.Name;
                    listViewItemData[1] = fieldElement.Type;
                    listViewItemData[2] = ((File)fieldElement).Size.ToString();
                    tempItemsList.Add(new ListViewItem(listViewItemData, 1));
                }
            }
        }

        public void UpdateFieldView(Field field)
        {
            List<ListViewItem> tempItemsList = new List<ListViewItem>();
            MakeTempItemsList(field, tempItemsList);
            if (String.Equals(field.FieldPath.Text, field.OpenedElement.Path))
            {
                int listEquals = ListEquals(field.FieldView.Items, tempItemsList);
                if (listEquals == 1)
                {
                    //початок оновлення (промальовки) списку
                    field.FieldView.BeginUpdate();
                    for (int i = 0; i < tempItemsList.Count; i++)
                        if (!tempItemsList[i].Equals(field.FieldView.Items[i]))
                            field.FieldView.Items[i] = tempItemsList[i];
                    //кінець оновлення
                    field.FieldView.EndUpdate();
                    return;
                }
                if (listEquals == 2)
                    return;
            }
            //початок оновлення (промальовки) списку
            field.FieldView.BeginUpdate();
            field.FieldView.Items.Clear();
            foreach (ListViewItem item in tempItemsList)
                field.FieldView.Items.Add(item);
            //виводимо повний шлях до папки чи диску в якому знаходимося
            field.FieldPath.Text = field.OpenedElement.Path;
            //кінець оновлення
            field.FieldView.EndUpdate();
        }

        /*
         * оновлюємо кнопки дисків
         * параметри DisksView.Items.Add disksIcons.Images:
         * 0 - Fixed or NoRootDirectory
         * 1 - CDRom
         * 2 - Network
         * 3 - Ram
         * 4 - Removable
         * 5 - Unknown
         */
        public void UpdateDisksView(Field field, List<Disk> disks)
        {
            if (disks != null)
            {
                field.DisksView.Items.Clear();
                foreach (Disk disk in disks)
                {
                    System.Drawing.Image diskIcon;
                    if (disk.DiskType == DriveType.Fixed || disk.DiskType == DriveType.NoRootDirectory)
                        diskIcon = disksIcons.Images[0];
                    else if (disk.DiskType == DriveType.CDRom)
                        diskIcon = disksIcons.Images[1];
                    else if (disk.DiskType == DriveType.Network)
                        diskIcon = disksIcons.Images[2];
                    else if (disk.DiskType == DriveType.Ram)
                        diskIcon = disksIcons.Images[3];
                    else if (disk.DiskType == DriveType.Removable)
                        diskIcon = disksIcons.Images[4];
                    else
                        diskIcon = disksIcons.Images[5];
                    if (field.DisksView == disksView1)
                        field.DisksView.Items.Add(disk.Name, diskIcon).Click += new EventHandler(DiskView1Btn_Click);
                    else if (field.DisksView == disksView2)
                        field.DisksView.Items.Add(disk.Name, diskIcon).Click += new EventHandler(DiskView2Btn_Click);
                }
            }
            
        }

        private void field1View_ItemActivate(object sender, EventArgs e)
        {
            FM.OpenElement(this);
        }

        private void field1View_Enter(object sender, EventArgs e)
        {
            FM.ChangeCurrentField(1);
        }

        private void field2View_ItemActivate(object sender, EventArgs e)
        {
            FM.OpenElement(this);
        }

        private void field2View_Enter(object sender, EventArgs e)
        {
            FM.ChangeCurrentField(2);
        }

        private void DiskView1Btn_Click(object sender, EventArgs e)
        {
            FM.ChangeDisk(sender.ToString(), 1, this);
        }

        private void DiskView2Btn_Click(object sender, EventArgs e)
        {
            FM.ChangeDisk(sender.ToString(), 2, this);
        }

        private void refresher_Tick(object sender, EventArgs e)
        {
            FM.RefreshAll(this);
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.OpenElement(this);
        }

        private void папкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.CreateFolder(this);
        }

        private void пустийФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.CreateEmptyFile(this);
        }

        /*
         * Функція копіювання елементу в буфер обміну Windows
         */
        private void копіюватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.CopyCutSelectedToClipboard(5);
        }

        private void вирізатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.CopyCutSelectedToClipboard(2);
        }

        private void вставитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.PasteFromClipboard(this);
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.RemoveSelected(this);
        }

        private void field1View_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            FM.RenameSelected();
        }

        private void field1View_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            FM.RenameSelected(e.Label, this);
        }

        private void field2View_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            FM.RenameSelected();
        }

        private void field2View_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            FM.RenameSelected(e.Label, this);
        }

        private void перейменуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.BeginRename();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            FM.CopySelected(this);
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            FM.ReplaceSelected(this);
        }

        private void KeyDownAction(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
                FM.BeginRename();
            else if (e.KeyCode == Keys.F5)
                FM.CopySelected(this);
            else if (e.KeyCode == Keys.F6)
                FM.ReplaceSelected(this);
            else if (e.KeyCode == Keys.F7)
                FM.CreateFolder(this);
            else if (e.KeyCode == Keys.F8 || e.KeyCode == Keys.Delete)
                FM.RemoveSelected(this);
        }

        private void field1View_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownAction(e);
        }

        private void field2View_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDownAction(e);
        }

        private void createFolderButton_Click(object sender, EventArgs e)
        {
            FM.CreateFolder(this);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            FM.RemoveSelected(this);
        }

        private void пошукФайлівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.StartFindFiles();
        }

        private void злиттяHTMLФайлівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.MargeSelectedHTMLFiles(this);
        }

        private void знайтиСловаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.FindOnceWords();
        }

        private void знайтиПідпослідовністьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FM.StartFindSubString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FM.GoBack(this);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FM.GoForward(this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FM.RefreshAll(this);
        }

        private void вихідToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void field1Path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FM.GoPath(field1Path.Text, 1, this);
                field1View.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void field1Path_Enter(object sender, EventArgs e)
        {
            refresher.Enabled = false;
        }

        private void field1Path_Leave(object sender, EventArgs e)
        {
            refresher.Enabled = true;
        }

        private void field2Path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FM.GoPath(field2Path.Text, 2, this);
                field1View.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void field2Path_Enter(object sender, EventArgs e)
        {
            refresher.Enabled = false;
        }

        private void field2Path_Leave(object sender, EventArgs e)
        {
            refresher.Enabled = true;
        }

        private void UpdateFormSize()
        {
            const int centreInterval = -14;
            const int rightCornerInterval = 16;
            const int heightInterval = 1;
            int footterInterval = 40 + copyButton.Height;
            const int buttonCount = 4;
            const int buttonCentreInterval = 0;
            disksView1.Location = new Point(0, tools.Location.Y + tools.Size.Height);
            disksView1.Size = new Size((this.Size.Width - centreInterval) / 2 - rightCornerInterval, disksView1.Size.Height);
            disksView2.Location = new Point((this.Size.Width + centreInterval) / 2, disksView1.Location.Y);
            disksView2.Size = new Size(this.Size.Width - disksView2.Location.X - rightCornerInterval, disksView2.Size.Height);
            field1Path.Location = new Point(0, disksView1.Location.Y + disksView1.Size.Height);
            field1Path.Size = new Size(disksView1.Size.Width, field1Path.Size.Height);
            field2Path.Location = new Point((this.Size.Width + centreInterval) / 2, field1Path.Location.Y);
            field2Path.Size = new Size(this.Size.Width - field2Path.Location.X - rightCornerInterval, field2Path.Size.Height);
            field1View.Location = new Point(0, field1Path.Location.Y + field1Path.Size.Height + heightInterval);
            field1View.Size = new Size(field1Path.Size.Width, this.Size.Height - field1View.Location.Y - footterInterval);
            field2View.Location = new Point((this.Size.Width + centreInterval) / 2, field1View.Location.Y);
            field2View.Size = new Size(this.Size.Width - field2View.Location.X - rightCornerInterval, field1View.Size.Height);
            copyButton.Location = new Point(0, field1View.Location.Y + field1View.Size.Height + heightInterval);
            copyButton.Size = new Size((this.Size.Width - 14) / buttonCount - buttonCentreInterval / 2, copyButton.Height);
            replaceButton.Location = new Point(copyButton.Location.X + copyButton.Size.Width + buttonCentreInterval, copyButton.Location.Y);
            replaceButton.Size = copyButton.Size;
            createFolderButton.Location = new Point(replaceButton.Location.X + replaceButton.Size.Width + buttonCentreInterval, copyButton.Location.Y);
            createFolderButton.Size = copyButton.Size; ;
            removeButton.Location = new Point(createFolderButton.Location.X + createFolderButton.Size.Width + buttonCentreInterval, copyButton.Location.Y);
            removeButton.Size = copyButton.Size;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            UpdateFormSize();
        }
    }
}
