namespace Corporation_Database
{
    partial class CounterpartyAccountList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterpartyAccountList));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.findtxtbox0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.AccountTableList = new System.Windows.Forms.DataGridView();
            this.CounterpartNamesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findtxtbox0,
            this.toolStripMenuItem1,
            this.печатьToolStripMenuItem,
            this.dataViewConfigToolStripMenuItem,
            this.хToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 27);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
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
            // dataViewConfigToolStripMenuItem
            // 
            this.dataViewConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.dataViewConfigToolStripMenuItem.Name = "dataViewConfigToolStripMenuItem";
            this.dataViewConfigToolStripMenuItem.Size = new System.Drawing.Size(86, 23);
            this.dataViewConfigToolStripMenuItem.Text = "База данных";
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
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // AccountTableList
            // 
            this.AccountTableList.AllowUserToAddRows = false;
            this.AccountTableList.AllowUserToDeleteRows = false;
            this.AccountTableList.BackgroundColor = System.Drawing.Color.White;
            this.AccountTableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountTableList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CounterpartNamesColumn});
            this.AccountTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountTableList.Location = new System.Drawing.Point(0, 27);
            this.AccountTableList.Name = "AccountTableList";
            this.AccountTableList.ReadOnly = true;
            this.AccountTableList.Size = new System.Drawing.Size(724, 359);
            this.AccountTableList.TabIndex = 24;
            this.AccountTableList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountTableList_CellDoubleClick);
            this.AccountTableList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HumanEditorDataResults_KeyDown_1);
            // 
            // CounterpartNamesColumn
            // 
            this.CounterpartNamesColumn.HeaderText = "Контрагенты";
            this.CounterpartNamesColumn.Name = "CounterpartNamesColumn";
            this.CounterpartNamesColumn.ReadOnly = true;
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // CounterpartyAccountList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(724, 386);
            this.Controls.Add(this.AccountTableList);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CounterpartyAccountList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Контрагент";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HumanEditorStep2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HumanEditorStep2_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountTableList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox findtxtbox0;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.DataGridView AccountTableList;
        private System.Windows.Forms.ToolStripMenuItem dataViewConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CounterpartNamesColumn;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}