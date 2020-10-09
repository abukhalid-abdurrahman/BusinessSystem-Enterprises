namespace Corporation_Database
{
    partial class HumanEditorStep3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HumanEditorStep3));
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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.HumanEditorDataResults = new System.Windows.Forms.DataGridView();
            this.mineDataDataSet3 = new Corporation_Database.MineDataDataSet3();
            this.counterpartyDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.counterpartyDataTableAdapter = new Corporation_Database.MineDataDataSet3TableAdapters.CounterpartyDataTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ценаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.поставщикDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.контрагентDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HumanEditorDataResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineDataDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterpartyDataBindingSource)).BeginInit();
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
            this.хToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 27);
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
            this.excelToolStripMenuItem});
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
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
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
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
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
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // HumanEditorDataResults
            // 
            this.HumanEditorDataResults.AllowUserToAddRows = false;
            this.HumanEditorDataResults.AllowUserToDeleteRows = false;
            this.HumanEditorDataResults.AutoGenerateColumns = false;
            this.HumanEditorDataResults.BackgroundColor = System.Drawing.Color.White;
            this.HumanEditorDataResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HumanEditorDataResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.имяDataGridViewTextBoxColumn,
            this.ценаDataGridViewTextBoxColumn,
            this.количествоDataGridViewTextBoxColumn,
            this.поставщикDataGridViewTextBoxColumn,
            this.контрагентDataGridViewTextBoxColumn});
            this.HumanEditorDataResults.DataSource = this.counterpartyDataBindingSource;
            this.HumanEditorDataResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HumanEditorDataResults.Location = new System.Drawing.Point(0, 27);
            this.HumanEditorDataResults.Name = "HumanEditorDataResults";
            this.HumanEditorDataResults.ReadOnly = true;
            this.HumanEditorDataResults.Size = new System.Drawing.Size(724, 359);
            this.HumanEditorDataResults.TabIndex = 24;
            this.HumanEditorDataResults.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.HumanEditorDataResults_RowHeaderMouseClick);
            this.HumanEditorDataResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HumanEditorDataResults_KeyDown_1);
            // 
            // mineDataDataSet3
            // 
            this.mineDataDataSet3.DataSetName = "MineDataDataSet3";
            this.mineDataDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // counterpartyDataBindingSource
            // 
            this.counterpartyDataBindingSource.DataMember = "CounterpartyData";
            this.counterpartyDataBindingSource.DataSource = this.mineDataDataSet3;
            // 
            // counterpartyDataTableAdapter
            // 
            this.counterpartyDataTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // имяDataGridViewTextBoxColumn
            // 
            this.имяDataGridViewTextBoxColumn.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn.Name = "имяDataGridViewTextBoxColumn";
            this.имяDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ценаDataGridViewTextBoxColumn
            // 
            this.ценаDataGridViewTextBoxColumn.DataPropertyName = "Цена";
            this.ценаDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.ценаDataGridViewTextBoxColumn.Name = "ценаDataGridViewTextBoxColumn";
            this.ценаDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // количествоDataGridViewTextBoxColumn
            // 
            this.количествоDataGridViewTextBoxColumn.DataPropertyName = "Количество";
            this.количествоDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.количествоDataGridViewTextBoxColumn.Name = "количествоDataGridViewTextBoxColumn";
            this.количествоDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // поставщикDataGridViewTextBoxColumn
            // 
            this.поставщикDataGridViewTextBoxColumn.DataPropertyName = "Поставщик";
            this.поставщикDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.поставщикDataGridViewTextBoxColumn.Name = "поставщикDataGridViewTextBoxColumn";
            this.поставщикDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // контрагентDataGridViewTextBoxColumn
            // 
            this.контрагентDataGridViewTextBoxColumn.DataPropertyName = "Контрагент";
            this.контрагентDataGridViewTextBoxColumn.HeaderText = "Контрагент";
            this.контрагентDataGridViewTextBoxColumn.Name = "контрагентDataGridViewTextBoxColumn";
            this.контрагентDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // HumanEditorStep3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 386);
            this.Controls.Add(this.HumanEditorDataResults);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HumanEditorStep3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Контрагент";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HumanEditorStep2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HumanEditorStep2_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HumanEditorDataResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineDataDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.counterpartyDataBindingSource)).EndInit();
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
        public System.Windows.Forms.DataGridView HumanEditorDataResults;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ценаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn поставщикDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn контрагентDataGridViewTextBoxColumn;
    }
}