namespace Corporation_Database
{
    partial class GeneralDataList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralDataList));
            this.DataControl = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.findtxtbox0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SummMoneyResults = new System.Windows.Forms.ToolStripMenuItem();
            this.хToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrateSummMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataControl
            // 
            this.DataControl.AllowUserToAddRows = false;
            this.DataControl.AllowUserToDeleteRows = false;
            this.DataControl.BackgroundColor = System.Drawing.Color.White;
            this.DataControl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DataControl.ColumnHeadersHeight = 24;
            this.DataControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.DataControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataControl.Location = new System.Drawing.Point(0, 27);
            this.DataControl.Name = "DataControl";
            this.DataControl.ReadOnly = true;
            this.DataControl.Size = new System.Drawing.Size(686, 359);
            this.DataControl.TabIndex = 0;
            this.DataControl.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataControl_CellDoubleClick);
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Имя";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Масса";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Кол-во";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Кол-во Каробок";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Цена";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Сумма";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findtxtbox0,
            this.toolStripMenuItem1,
            this.SummMoneyResults,
            this.хToolStripMenuItem,
            this.CrateSummMenuItem,
            this.reloadDataToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 27);
            this.menuStrip1.TabIndex = 21;
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
            // SummMoneyResults
            // 
            this.SummMoneyResults.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.SummMoneyResults.Name = "SummMoneyResults";
            this.SummMoneyResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SummMoneyResults.Size = new System.Drawing.Size(107, 23);
            this.SummMoneyResults.Text = "Сумма 0 Сомон";
            this.SummMoneyResults.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.SummMoneyResults.Click += new System.EventHandler(this.WorkersMoneyResults_Click);
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
            // CrateSummMenuItem
            // 
            this.CrateSummMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.CrateSummMenuItem.Name = "CrateSummMenuItem";
            this.CrateSummMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CrateSummMenuItem.Size = new System.Drawing.Size(117, 23);
            this.CrateSummMenuItem.Text = "Кол-во Каробок 0";
            this.CrateSummMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.CrateSummMenuItem.Click += new System.EventHandler(this.CrateSummMenuItem_Click);
            // 
            // reloadDataToolStripMenuItem
            // 
            this.reloadDataToolStripMenuItem.Name = "reloadDataToolStripMenuItem";
            this.reloadDataToolStripMenuItem.Size = new System.Drawing.Size(143, 23);
            this.reloadDataToolStripMenuItem.Text = "Перезагрузить данные";
            this.reloadDataToolStripMenuItem.Visible = false;
            this.reloadDataToolStripMenuItem.Click += new System.EventHandler(this.reloadDataToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(107, 23);
            this.saveAsToolStripMenuItem.Text = "Сохранить как...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // GeneralDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(686, 386);
            this.Controls.Add(this.DataControl);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GeneralDataList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор сырья";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RawMatFormStep2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox findtxtbox0;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SummMoneyResults;
        public System.Windows.Forms.DataGridView DataControl;
        private System.Windows.Forms.ToolStripMenuItem хToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrateSummMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}