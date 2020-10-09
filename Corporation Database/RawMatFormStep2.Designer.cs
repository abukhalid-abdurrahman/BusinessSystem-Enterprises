namespace Corporation_Database
{
    partial class RawMatFormStep2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawMatFormStep2));
            this.RawMatResultsDaa = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findtxtbox0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkersMoneyResults = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solaryMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solaryMinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.хToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.EditToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.RawMatResultsDaa)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RawMatResultsDaa
            // 
            this.RawMatResultsDaa.AllowUserToAddRows = false;
            this.RawMatResultsDaa.AllowUserToDeleteRows = false;
            this.RawMatResultsDaa.BackgroundColor = System.Drawing.Color.White;
            this.RawMatResultsDaa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RawMatResultsDaa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawMatResultsDaa.Location = new System.Drawing.Point(0, 27);
            this.RawMatResultsDaa.Name = "RawMatResultsDaa";
            this.RawMatResultsDaa.ReadOnly = true;
            this.RawMatResultsDaa.Size = new System.Drawing.Size(665, 359);
            this.RawMatResultsDaa.TabIndex = 0;
            this.RawMatResultsDaa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RawMatResultsDaa_CellDoubleClick);
            this.RawMatResultsDaa.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RawMatResultsDaa_RowHeaderMouseClick);
            this.RawMatResultsDaa.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.RawMatResultsDaa_RowsAdded);
            this.RawMatResultsDaa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RawMatResultsDaa_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.EditToolStrip,
            this.findtxtbox0,
            this.toolStripMenuItem1,
            this.печатьToolStripMenuItem,
            this.WorkersMoneyResults,
            this.dataViewConfigToolStripMenuItem,
            this.toolStripMenuItem7,
            this.хToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(665, 27);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // findtxtbox0
            // 
            this.findtxtbox0.Name = "findtxtbox0";
            this.findtxtbox0.Size = new System.Drawing.Size(100, 23);
            this.findtxtbox0.TextChanged += new System.EventHandler(this.findtxtbox0_TextChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 23);
            this.toolStripMenuItem1.Text = "Найти";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.печатьToolStripMenuItem.Text = "Печать";
            this.печатьToolStripMenuItem.Click += new System.EventHandler(this.печатьToolStripMenuItem_Click);
            // 
            // WorkersMoneyResults
            // 
            this.WorkersMoneyResults.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.WorkersMoneyResults.Name = "WorkersMoneyResults";
            this.WorkersMoneyResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WorkersMoneyResults.Size = new System.Drawing.Size(122, 23);
            this.WorkersMoneyResults.Text = "СУММА 0 СОМОН";
            this.WorkersMoneyResults.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.WorkersMoneyResults.Click += new System.EventHandler(this.WorkersMoneyResults_Click);
            // 
            // dataViewConfigToolStripMenuItem
            // 
            this.dataViewConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem,
            this.excelToolStripMenuItem});
            this.dataViewConfigToolStripMenuItem.Name = "dataViewConfigToolStripMenuItem";
            this.dataViewConfigToolStripMenuItem.Size = new System.Drawing.Size(86, 23);
            this.dataViewConfigToolStripMenuItem.Text = "База данных";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solaryMaxToolStripMenuItem,
            this.solaryMinToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.sortToolStripMenuItem.Text = "Сортировка";
            // 
            // solaryMaxToolStripMenuItem
            // 
            this.solaryMaxToolStripMenuItem.Name = "solaryMaxToolStripMenuItem";
            this.solaryMaxToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.solaryMaxToolStripMenuItem.Text = "Сумма по возр.";
            this.solaryMaxToolStripMenuItem.Click += new System.EventHandler(this.solaryMaxToolStripMenuItem_Click);
            // 
            // solaryMinToolStripMenuItem
            // 
            this.solaryMinToolStripMenuItem.Name = "solaryMinToolStripMenuItem";
            this.solaryMinToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.solaryMinToolStripMenuItem.Text = "Сумма по убыв.";
            this.solaryMinToolStripMenuItem.Click += new System.EventHandler(this.solaryMinToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(82, 23);
            this.toolStripMenuItem7.Text = "Диаграмма";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuItem8.Text = "Генерация";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.genGraphToolStripMenuItem_Click);
            // 
            // хToolStripMenuItem
            // 
            this.хToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.хToolStripMenuItem.Name = "хToolStripMenuItem";
            this.хToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.хToolStripMenuItem.Size = new System.Drawing.Size(26, 23);
            this.хToolStripMenuItem.Text = "Х";
            this.хToolStripMenuItem.Click += new System.EventHandler(this.хToolStripMenuItem_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // EditToolStrip
            // 
            this.EditToolStrip.Name = "EditToolStrip";
            this.EditToolStrip.Size = new System.Drawing.Size(73, 23);
            this.EditToolStrip.Text = "Изменить";
            this.EditToolStrip.Click += new System.EventHandler(this.EditToolStrip_Click);
            // 
            // RawMatFormStep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(665, 386);
            this.Controls.Add(this.RawMatResultsDaa);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RawMatFormStep2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор сырья";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RawMatFormStep2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RawMatResultsDaa)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox findtxtbox0;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WorkersMoneyResults;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.DataGridView RawMatResultsDaa;
        private System.Windows.Forms.ToolStripMenuItem dataViewConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solaryMaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solaryMinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem хToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStrip;
    }
}