namespace Lab2.File_manager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.field1View = new System.Windows.Forms.ListView();
            this.column1Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column1Extension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column1Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fieldElementProperties = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.відкритиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.вирізатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копіюватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.видалитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейменуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.створитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.пустийФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldElementIcons = new System.Windows.Forms.ImageList(this.components);
            this.field2View = new System.Windows.Forms.ListView();
            this.column2Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2Extension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.disksView1 = new System.Windows.Forms.ToolStrip();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.вихідToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.вихідToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.інструментиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукФайлівToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.злиттяHTMLФайлівToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.знайтиСловаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.знайтиПідпослідовністьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disksIcons = new System.Windows.Forms.ImageList(this.components);
            this.disksView2 = new System.Windows.Forms.ToolStrip();
            this.refresher = new System.Windows.Forms.Timer(this.components);
            this.copyButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.createFolderButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.backButton = new System.Windows.Forms.ToolStripButton();
            this.forwardButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.field1Path = new System.Windows.Forms.TextBox();
            this.field2Path = new System.Windows.Forms.TextBox();
            this.fieldElementProperties.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // field1View
            // 
            this.field1View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1Name,
            this.column1Extension,
            this.column1Size});
            this.field1View.ContextMenuStrip = this.fieldElementProperties;
            this.field1View.LabelEdit = true;
            this.field1View.LargeImageList = this.fieldElementIcons;
            this.field1View.Location = new System.Drawing.Point(0, 99);
            this.field1View.Name = "field1View";
            this.field1View.Size = new System.Drawing.Size(394, 279);
            this.field1View.SmallImageList = this.fieldElementIcons;
            this.field1View.TabIndex = 0;
            this.field1View.UseCompatibleStateImageBehavior = false;
            this.field1View.View = System.Windows.Forms.View.Details;
            this.field1View.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.field1View_AfterLabelEdit);
            this.field1View.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.field1View_BeforeLabelEdit);
            this.field1View.ItemActivate += new System.EventHandler(this.field1View_ItemActivate);
            this.field1View.Enter += new System.EventHandler(this.field1View_Enter);
            this.field1View.KeyDown += new System.Windows.Forms.KeyEventHandler(this.field1View_KeyDown);
            // 
            // column1Name
            // 
            this.column1Name.Text = "Ім\'я";
            this.column1Name.Width = 208;
            // 
            // column1Extension
            // 
            this.column1Extension.Text = "Тип";
            this.column1Extension.Width = 67;
            // 
            // column1Size
            // 
            this.column1Size.Text = "Розмір";
            this.column1Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column1Size.Width = 100;
            // 
            // fieldElementProperties
            // 
            this.fieldElementProperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.відкритиToolStripMenuItem,
            this.toolStripSeparator1,
            this.вирізатиToolStripMenuItem,
            this.копіюватиToolStripMenuItem,
            this.вставитиToolStripMenuItem,
            this.toolStripSeparator2,
            this.видалитиToolStripMenuItem,
            this.перейменуватиToolStripMenuItem,
            this.toolStripSeparator3,
            this.створитиToolStripMenuItem});
            this.fieldElementProperties.Name = "contextMenuStrip";
            this.fieldElementProperties.Size = new System.Drawing.Size(162, 176);
            // 
            // відкритиToolStripMenuItem
            // 
            this.відкритиToolStripMenuItem.Name = "відкритиToolStripMenuItem";
            this.відкритиToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.відкритиToolStripMenuItem.Text = "Відкрити";
            this.відкритиToolStripMenuItem.Click += new System.EventHandler(this.відкритиToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // вирізатиToolStripMenuItem
            // 
            this.вирізатиToolStripMenuItem.Name = "вирізатиToolStripMenuItem";
            this.вирізатиToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.вирізатиToolStripMenuItem.Text = "Вирізати";
            this.вирізатиToolStripMenuItem.Click += new System.EventHandler(this.вирізатиToolStripMenuItem_Click);
            // 
            // копіюватиToolStripMenuItem
            // 
            this.копіюватиToolStripMenuItem.Name = "копіюватиToolStripMenuItem";
            this.копіюватиToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.копіюватиToolStripMenuItem.Text = "Копіювати";
            this.копіюватиToolStripMenuItem.Click += new System.EventHandler(this.копіюватиToolStripMenuItem_Click);
            // 
            // вставитиToolStripMenuItem
            // 
            this.вставитиToolStripMenuItem.Name = "вставитиToolStripMenuItem";
            this.вставитиToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.вставитиToolStripMenuItem.Text = "Вставити";
            this.вставитиToolStripMenuItem.Click += new System.EventHandler(this.вставитиToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // видалитиToolStripMenuItem
            // 
            this.видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            this.видалитиToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.видалитиToolStripMenuItem.Text = "Видалити";
            this.видалитиToolStripMenuItem.Click += new System.EventHandler(this.видалитиToolStripMenuItem_Click);
            // 
            // перейменуватиToolStripMenuItem
            // 
            this.перейменуватиToolStripMenuItem.Name = "перейменуватиToolStripMenuItem";
            this.перейменуватиToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.перейменуватиToolStripMenuItem.Text = "Перейменувати";
            this.перейменуватиToolStripMenuItem.Click += new System.EventHandler(this.перейменуватиToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // створитиToolStripMenuItem
            // 
            this.створитиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.папкуToolStripMenuItem,
            this.toolStripSeparator4,
            this.пустийФайлToolStripMenuItem});
            this.створитиToolStripMenuItem.Name = "створитиToolStripMenuItem";
            this.створитиToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.створитиToolStripMenuItem.Text = "Створити";
            // 
            // папкуToolStripMenuItem
            // 
            this.папкуToolStripMenuItem.Name = "папкуToolStripMenuItem";
            this.папкуToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.папкуToolStripMenuItem.Text = "Папку";
            this.папкуToolStripMenuItem.Click += new System.EventHandler(this.папкуToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(143, 6);
            // 
            // пустийФайлToolStripMenuItem
            // 
            this.пустийФайлToolStripMenuItem.Name = "пустийФайлToolStripMenuItem";
            this.пустийФайлToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.пустийФайлToolStripMenuItem.Text = "Пустий файл";
            this.пустийФайлToolStripMenuItem.Click += new System.EventHandler(this.пустийФайлToolStripMenuItem_Click);
            // 
            // fieldElementIcons
            // 
            this.fieldElementIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fieldElementIcons.ImageStream")));
            this.fieldElementIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.fieldElementIcons.Images.SetKeyName(0, "Folder.ico");
            this.fieldElementIcons.Images.SetKeyName(1, "Blank.ico");
            this.fieldElementIcons.Images.SetKeyName(2, "Up.ico");
            // 
            // field2View
            // 
            this.field2View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column2Name,
            this.column2Extension,
            this.column2Size});
            this.field2View.ContextMenuStrip = this.fieldElementProperties;
            this.field2View.LabelEdit = true;
            this.field2View.LargeImageList = this.fieldElementIcons;
            this.field2View.Location = new System.Drawing.Point(400, 99);
            this.field2View.Name = "field2View";
            this.field2View.Size = new System.Drawing.Size(362, 279);
            this.field2View.SmallImageList = this.fieldElementIcons;
            this.field2View.TabIndex = 1;
            this.field2View.UseCompatibleStateImageBehavior = false;
            this.field2View.View = System.Windows.Forms.View.Details;
            this.field2View.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.field2View_AfterLabelEdit);
            this.field2View.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.field2View_BeforeLabelEdit);
            this.field2View.ItemActivate += new System.EventHandler(this.field2View_ItemActivate);
            this.field2View.Enter += new System.EventHandler(this.field2View_Enter);
            this.field2View.KeyDown += new System.Windows.Forms.KeyEventHandler(this.field2View_KeyDown);
            // 
            // column2Name
            // 
            this.column2Name.Text = "Ім\'я";
            this.column2Name.Width = 182;
            // 
            // column2Extension
            // 
            this.column2Extension.Text = "Тип";
            this.column2Extension.Width = 62;
            // 
            // column2Size
            // 
            this.column2Size.Text = "Розмір";
            this.column2Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column2Size.Width = 111;
            // 
            // disksView1
            // 
            this.disksView1.AutoSize = false;
            this.disksView1.Dock = System.Windows.Forms.DockStyle.None;
            this.disksView1.Location = new System.Drawing.Point(0, 53);
            this.disksView1.Name = "disksView1";
            this.disksView1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.disksView1.Size = new System.Drawing.Size(394, 25);
            this.disksView1.TabIndex = 2;
            this.disksView1.Text = "Disks";
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вихідToolStripMenuItem1,
            this.інструментиToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(762, 24);
            this.mainMenu.TabIndex = 3;
            // 
            // вихідToolStripMenuItem1
            // 
            this.вихідToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вихідToolStripMenuItem2});
            this.вихідToolStripMenuItem1.Name = "вихідToolStripMenuItem1";
            this.вихідToolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.вихідToolStripMenuItem1.Text = "Файли";
            // 
            // вихідToolStripMenuItem2
            // 
            this.вихідToolStripMenuItem2.Name = "вихідToolStripMenuItem2";
            this.вихідToolStripMenuItem2.Size = new System.Drawing.Size(102, 22);
            this.вихідToolStripMenuItem2.Text = "Вихід";
            this.вихідToolStripMenuItem2.Click += new System.EventHandler(this.вихідToolStripMenuItem2_Click);
            // 
            // інструментиToolStripMenuItem
            // 
            this.інструментиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пошукФайлівToolStripMenuItem,
            this.злиттяHTMLФайлівToolStripMenuItem,
            this.знайтиСловаToolStripMenuItem,
            this.знайтиПідпослідовністьToolStripMenuItem});
            this.інструментиToolStripMenuItem.Name = "інструментиToolStripMenuItem";
            this.інструментиToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.інструментиToolStripMenuItem.Text = "Інструменти";
            // 
            // пошукФайлівToolStripMenuItem
            // 
            this.пошукФайлівToolStripMenuItem.Name = "пошукФайлівToolStripMenuItem";
            this.пошукФайлівToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.пошукФайлівToolStripMenuItem.Text = "Пошук файлів";
            this.пошукФайлівToolStripMenuItem.Click += new System.EventHandler(this.пошукФайлівToolStripMenuItem_Click);
            // 
            // злиттяHTMLФайлівToolStripMenuItem
            // 
            this.злиттяHTMLФайлівToolStripMenuItem.Name = "злиттяHTMLФайлівToolStripMenuItem";
            this.злиттяHTMLФайлівToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.злиттяHTMLФайлівToolStripMenuItem.Text = "Злиття HTML файлів";
            this.злиттяHTMLФайлівToolStripMenuItem.Click += new System.EventHandler(this.злиттяHTMLФайлівToolStripMenuItem_Click);
            // 
            // знайтиСловаToolStripMenuItem
            // 
            this.знайтиСловаToolStripMenuItem.Name = "знайтиСловаToolStripMenuItem";
            this.знайтиСловаToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.знайтиСловаToolStripMenuItem.Text = "Знайти слова";
            this.знайтиСловаToolStripMenuItem.Click += new System.EventHandler(this.знайтиСловаToolStripMenuItem_Click);
            // 
            // знайтиПідпослідовністьToolStripMenuItem
            // 
            this.знайтиПідпослідовністьToolStripMenuItem.Name = "знайтиПідпослідовністьToolStripMenuItem";
            this.знайтиПідпослідовністьToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.знайтиПідпослідовністьToolStripMenuItem.Text = "Знайти підпослідовність";
            this.знайтиПідпослідовністьToolStripMenuItem.Click += new System.EventHandler(this.знайтиПідпослідовністьToolStripMenuItem_Click);
            // 
            // disksIcons
            // 
            this.disksIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("disksIcons.ImageStream")));
            this.disksIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.disksIcons.Images.SetKeyName(0, "HDD-Alt.ico");
            this.disksIcons.Images.SetKeyName(1, "CD-Alt.ico");
            this.disksIcons.Images.SetKeyName(2, "HDD-Network.ico");
            this.disksIcons.Images.SetKeyName(3, "memory.ico");
            this.disksIcons.Images.SetKeyName(4, "USB.ico");
            this.disksIcons.Images.SetKeyName(5, "Unknown.ico");
            // 
            // disksView2
            // 
            this.disksView2.AutoSize = false;
            this.disksView2.Dock = System.Windows.Forms.DockStyle.None;
            this.disksView2.Location = new System.Drawing.Point(400, 53);
            this.disksView2.Name = "disksView2";
            this.disksView2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.disksView2.Size = new System.Drawing.Size(362, 25);
            this.disksView2.TabIndex = 6;
            this.disksView2.Text = "Disks";
            // 
            // refresher
            // 
            this.refresher.Interval = 2000;
            this.refresher.Tick += new System.EventHandler(this.refresher_Tick);
            // 
            // copyButton
            // 
            this.copyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyButton.Location = new System.Drawing.Point(208, 384);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(131, 23);
            this.copyButton.TabIndex = 7;
            this.copyButton.Text = "F5 Копіювати";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(345, 384);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(131, 23);
            this.replaceButton.TabIndex = 8;
            this.replaceButton.Text = "F6 Перемістити";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // createFolderButton
            // 
            this.createFolderButton.Location = new System.Drawing.Point(482, 384);
            this.createFolderButton.Name = "createFolderButton";
            this.createFolderButton.Size = new System.Drawing.Size(131, 23);
            this.createFolderButton.TabIndex = 9;
            this.createFolderButton.Text = "F7 Папка";
            this.createFolderButton.UseVisualStyleBackColor = true;
            this.createFolderButton.Click += new System.EventHandler(this.createFolderButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(619, 384);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(131, 23);
            this.removeButton.TabIndex = 10;
            this.removeButton.Text = "F8 Видалити";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton,
            this.forwardButton,
            this.refreshButton});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(762, 25);
            this.tools.TabIndex = 0;
            this.tools.Text = "tools";
            // 
            // backButton
            // 
            this.backButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(23, 22);
            this.backButton.Text = "Back";
            this.backButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardButton.Image = ((System.Drawing.Image)(resources.GetObject("forwardButton.Image")));
            this.forwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(23, 22);
            this.forwardButton.Text = "Forward";
            this.forwardButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 22);
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // field1Path
            // 
            this.field1Path.Location = new System.Drawing.Point(1, 78);
            this.field1Path.Name = "field1Path";
            this.field1Path.Size = new System.Drawing.Size(393, 20);
            this.field1Path.TabIndex = 11;
            this.field1Path.Text = "C:\\";
            this.field1Path.Enter += new System.EventHandler(this.field1Path_Enter);
            this.field1Path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.field1Path_KeyDown);
            this.field1Path.Leave += new System.EventHandler(this.field1Path_Leave);
            // 
            // field2Path
            // 
            this.field2Path.Location = new System.Drawing.Point(400, 78);
            this.field2Path.Name = "field2Path";
            this.field2Path.Size = new System.Drawing.Size(362, 20);
            this.field2Path.TabIndex = 12;
            this.field2Path.Text = "C:\\";
            this.field2Path.Enter += new System.EventHandler(this.field2Path_Enter);
            this.field2Path.KeyDown += new System.Windows.Forms.KeyEventHandler(this.field2Path_KeyDown);
            this.field2Path.Leave += new System.EventHandler(this.field2Path_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 415);
            this.Controls.Add(this.field2Path);
            this.Controls.Add(this.field1Path);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.createFolderButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.disksView2);
            this.Controls.Add(this.disksView1);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.field2View);
            this.Controls.Add(this.field1View);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(778, 453);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.fieldElementProperties.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView field1View;
        private System.Windows.Forms.ListView field2View;
        private System.Windows.Forms.ImageList fieldElementIcons;
        private System.Windows.Forms.ContextMenuStrip fieldElementProperties;
        private System.Windows.Forms.ToolStrip disksView1;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem2;
        private System.Windows.Forms.ColumnHeader column1Name;
        private System.Windows.Forms.ColumnHeader column1Extension;
        private System.Windows.Forms.ColumnHeader column1Size;
        private System.Windows.Forms.ColumnHeader column2Name;
        private System.Windows.Forms.ColumnHeader column2Extension;
        private System.Windows.Forms.ColumnHeader column2Size;
        private System.Windows.Forms.ImageList disksIcons;
        private System.Windows.Forms.ToolStrip disksView2;
        private System.Windows.Forms.Timer refresher;
        private System.Windows.Forms.ToolStripMenuItem відкритиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem вирізатиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копіюватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem видалитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейменуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem створитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem пустийФайлToolStripMenuItem;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button createFolderButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ToolStripMenuItem інструментиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукФайлівToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem злиттяHTMLФайлівToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem знайтиСловаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem знайтиПідпослідовністьToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton backButton;
        private System.Windows.Forms.ToolStripButton forwardButton;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.TextBox field1Path;
        private System.Windows.Forms.TextBox field2Path;
    }
}