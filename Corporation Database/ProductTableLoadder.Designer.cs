namespace Corporation_Database
{
    partial class ProductTableLoadder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductTableLoadder));
            this.RawMatResultsDaa = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findtxtbox0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crateCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeneralSummToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.findtxtbox0,
            this.toolStripMenuItem1,
            this.печатьToolStripMenuItem,
            this.хToolStripMenuItem,
            this.dataViewConfigToolStripMenuItem,
            this.crateCountToolStripMenuItem,
            this.GeneralSummToolStripMenuItem});
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
            // хToolStripMenuItem
            // 
            this.хToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.хToolStripMenuItem.Name = "хToolStripMenuItem";
            this.хToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.хToolStripMenuItem.Size = new System.Drawing.Size(26, 23);
            this.хToolStripMenuItem.Text = "Х";
            this.хToolStripMenuItem.Click += new System.EventHandler(this.хToolStripMenuItem_Click);
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
            // crateCountToolStripMenuItem
            // 
            this.crateCountToolStripMenuItem.Name = "crateCountToolStripMenuItem";
            this.crateCountToolStripMenuItem.Size = new System.Drawing.Size(117, 23);
            this.crateCountToolStripMenuItem.Text = "Кол-во Каробок 0";
            this.crateCountToolStripMenuItem.Click += new System.EventHandler(this.crateCountToolStripMenuItem_Click);
            // 
            // GeneralSummToolStripMenuItem
            // 
            this.GeneralSummToolStripMenuItem.Name = "GeneralSummToolStripMenuItem";
            this.GeneralSummToolStripMenuItem.Size = new System.Drawing.Size(108, 23);
            this.GeneralSummToolStripMenuItem.Text = "Общая Сумма 0";
            this.GeneralSummToolStripMenuItem.Click += new System.EventHandler(this.GeneralSummToolStripMenuItem_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // ProductTableLoadder
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
            this.Name = "ProductTableLoadder";
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
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.DataGridView RawMatResultsDaa;
        private System.Windows.Forms.ToolStripMenuItem dataViewConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem хToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crateCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GeneralSummToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}