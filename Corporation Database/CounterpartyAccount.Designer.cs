namespace Corporation_Database
{
    partial class CounterpartyAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterpartyAccount));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findtxtbox0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоПоУбывToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.AccountTable = new System.Windows.Forms.DataGridView();
            this.counterpartyDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mineDataDataSet3 = new Corporation_Database.MineDataDataSet3();
            this.counterpartyDataTableAdapter = new Corporation_Database.MineDataDataSet3TableAdapters.CounterpartyDataTableAdapter();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterpartyDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineDataDataSet3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.findtxtbox0,
            this.toolStripMenuItem1,
            this.печатьToolStripMenuItem,
            this.toolStripMenuItem7,
            this.dataViewConfigToolStripMenuItem,
            this.хToolStripMenuItem,
            this.summToolStripMenuItem,
            this.debtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 27);
            this.menuStrip1.TabIndex = 23;
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
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // dataViewConfigToolStripMenuItem
            // 
            this.dataViewConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem,
            this.excelToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.dataViewConfigToolStripMenuItem.Name = "dataViewConfigToolStripMenuItem";
            this.dataViewConfigToolStripMenuItem.Size = new System.Drawing.Size(86, 23);
            this.dataViewConfigToolStripMenuItem.Text = "База данных";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количествоToolStripMenuItem,
            this.количествоПоУбывToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sortToolStripMenuItem.Text = "Сортировка";
            // 
            // количествоToolStripMenuItem
            // 
            this.количествоToolStripMenuItem.Name = "количествоToolStripMenuItem";
            this.количествоToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.количествоToolStripMenuItem.Text = "Количество по возр.";
            this.количествоToolStripMenuItem.Click += new System.EventHandler(this.количествоToolStripMenuItem_Click);
            // 
            // количествоПоУбывToolStripMenuItem
            // 
            this.количествоПоУбывToolStripMenuItem.Name = "количествоПоУбывToolStripMenuItem";
            this.количествоПоУбывToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.количествоПоУбывToolStripMenuItem.Text = "Количество по убыв.";
            this.количествоПоУбывToolStripMenuItem.Click += new System.EventHandler(this.количествоПоУбывToolStripMenuItem_Click);
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
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
            // summToolStripMenuItem
            // 
            this.summToolStripMenuItem.Name = "summToolStripMenuItem";
            this.summToolStripMenuItem.Size = new System.Drawing.Size(117, 23);
            this.summToolStripMenuItem.Text = "Сумма: 0 Сомони";
            this.summToolStripMenuItem.Click += new System.EventHandler(this.summToolStripMenuItem_Click);
            // 
            // debtToolStripMenuItem
            // 
            this.debtToolStripMenuItem.Name = "debtToolStripMenuItem";
            this.debtToolStripMenuItem.Size = new System.Drawing.Size(106, 23);
            this.debtToolStripMenuItem.Text = "Долг: 0 Сомони";
            this.debtToolStripMenuItem.Click += new System.EventHandler(this.debtToolStripMenuItem_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // AccountTable
            // 
            this.AccountTable.AllowUserToAddRows = false;
            this.AccountTable.AllowUserToDeleteRows = false;
            this.AccountTable.BackgroundColor = System.Drawing.Color.White;
            this.AccountTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountTable.Location = new System.Drawing.Point(0, 27);
            this.AccountTable.Name = "AccountTable";
            this.AccountTable.ReadOnly = true;
            this.AccountTable.Size = new System.Drawing.Size(848, 359);
            this.AccountTable.TabIndex = 24;
            this.AccountTable.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.HumanEditorDataResults_RowHeaderMouseClick);
            this.AccountTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HumanEditorDataResults_KeyDown_1);
            // 
            // counterpartyDataBindingSource
            // 
            this.counterpartyDataBindingSource.DataMember = "CounterpartyData";
            this.counterpartyDataBindingSource.DataSource = this.mineDataDataSet3;
            // 
            // mineDataDataSet3
            // 
            this.mineDataDataSet3.DataSetName = "MineDataDataSet3";
            this.mineDataDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // counterpartyDataTableAdapter
            // 
            this.counterpartyDataTableAdapter.ClearBeforeFill = true;
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // CounterpartyAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 386);
            this.Controls.Add(this.AccountTable);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CounterpartyAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Контрагент";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HumanEditorStep2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HumanEditorStep2_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterpartyDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineDataDataSet3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox findtxtbox0;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.DataGridView AccountTable;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem dataViewConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem количествоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem количествоПоУбывToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хToolStripMenuItem;
        private MineDataDataSet3 mineDataDataSet3;
        private System.Windows.Forms.BindingSource counterpartyDataBindingSource;
        private MineDataDataSet3TableAdapters.CounterpartyDataTableAdapter counterpartyDataTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem summToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}