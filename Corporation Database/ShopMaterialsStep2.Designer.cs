namespace Corporation_Database
{
    partial class ShopMaterialsStep2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findtxtbox0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crateCountToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkersMoneyResults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.хToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.ShopMatResultsDaa = new System.Windows.Forms.DataGridView();
            this.EditStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShopMatResultsDaa)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалитьToolStripMenuItem,
            this.EditStripMenu,
            this.findtxtbox0,
            this.toolStripMenuItem1,
            this.печатьToolStripMenuItem,
            this.crateCountToolStrip,
            this.WorkersMoneyResults,
            this.toolStripMenuItem7,
            this.dataViewConfigToolStripMenuItem,
            this.toolStripMenuItem2,
            this.хToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 27);
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
            // crateCountToolStrip
            // 
            this.crateCountToolStrip.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.crateCountToolStrip.Name = "crateCountToolStrip";
            this.crateCountToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.crateCountToolStrip.Size = new System.Drawing.Size(165, 23);
            this.crateCountToolStrip.Text = "КОЛ-ВО КАРОБОК 0 ШТУК";
            this.crateCountToolStrip.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.crateCountToolStrip.Click += new System.EventHandler(this.crateCountToolStrip_Click);
            // 
            // WorkersMoneyResults
            // 
            this.WorkersMoneyResults.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.WorkersMoneyResults.Name = "WorkersMoneyResults";
            this.WorkersMoneyResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WorkersMoneyResults.Size = new System.Drawing.Size(131, 23);
            this.WorkersMoneyResults.Text = "СУММА 0 СОМОНИ";
            this.WorkersMoneyResults.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.WorkersMoneyResults.Click += new System.EventHandler(this.WorkersMoneyResults_Click);
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
            this.excelToolStripMenuItem});
            this.dataViewConfigToolStripMenuItem.Name = "dataViewConfigToolStripMenuItem";
            this.dataViewConfigToolStripMenuItem.Size = new System.Drawing.Size(86, 23);
            this.dataViewConfigToolStripMenuItem.Text = "База данных";
            // 
            // excelToolStripMenuItem
            // 
            this.excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            this.excelToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.excelToolStripMenuItem.Text = "Excel";
            this.excelToolStripMenuItem.Click += new System.EventHandler(this.excelToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(85, 23);
            this.toolStripMenuItem2.Text = "Конкуляция";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
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
            // ShopMatResultsDaa
            // 
            this.ShopMatResultsDaa.AllowUserToAddRows = false;
            this.ShopMatResultsDaa.AllowUserToDeleteRows = false;
            this.ShopMatResultsDaa.BackgroundColor = System.Drawing.Color.White;
            this.ShopMatResultsDaa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShopMatResultsDaa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShopMatResultsDaa.Location = new System.Drawing.Point(0, 27);
            this.ShopMatResultsDaa.Name = "ShopMatResultsDaa";
            this.ShopMatResultsDaa.ReadOnly = true;
            this.ShopMatResultsDaa.Size = new System.Drawing.Size(856, 486);
            this.ShopMatResultsDaa.TabIndex = 23;
            this.ShopMatResultsDaa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShopMatResultsDaa_CellDoubleClick_1);
            this.ShopMatResultsDaa.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ShopMatResultsDaa_RowHeaderMouseClick);
            // 
            // EditStripMenu
            // 
            this.EditStripMenu.Name = "EditStripMenu";
            this.EditStripMenu.Size = new System.Drawing.Size(73, 23);
            this.EditStripMenu.Text = "Изменить";
            this.EditStripMenu.Click += new System.EventHandler(this.EditStripMenu_Click);
            // 
            // ShopMaterialsStep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 513);
            this.Controls.Add(this.ShopMatResultsDaa);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShopMaterialsStep2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор Цеха";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShopMaterialsStep2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShopMaterialsStep2_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShopMatResultsDaa)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem WorkersMoneyResults;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem dataViewConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem хToolStripMenuItem;
        private System.Windows.Forms.DataGridView ShopMatResultsDaa;
        private System.Windows.Forms.ToolStripMenuItem crateCountToolStrip;
        private System.Windows.Forms.ToolStripMenuItem EditStripMenu;
    }
}