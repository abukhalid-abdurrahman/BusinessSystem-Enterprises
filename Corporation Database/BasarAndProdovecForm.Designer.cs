namespace Corporation_Database
{
    partial class BasarAndProdovecForm
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
            this.сохрантьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findtxtbox01 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.humanEditorData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.хToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.humanEditorData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохрантьToolStripMenuItem,
            this.добавитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.очиститьToolStripMenuItem,
            this.findtxtbox01,
            this.toolStripMenuItem1,
            this.хToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 27);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохрантьToolStripMenuItem
            // 
            this.сохрантьToolStripMenuItem.Name = "сохрантьToolStripMenuItem";
            this.сохрантьToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.сохрантьToolStripMenuItem.Text = "Сохранть";
            this.сохрантьToolStripMenuItem.Click += new System.EventHandler(this.сохрантьToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // findtxtbox01
            // 
            this.findtxtbox01.Name = "findtxtbox01";
            this.findtxtbox01.Size = new System.Drawing.Size(100, 23);
            this.findtxtbox01.TextChanged += new System.EventHandler(this.findtxtbox01_TextChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 23);
            this.toolStripMenuItem1.Text = "Найти";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // humanEditorData
            // 
            this.humanEditorData.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.humanEditorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.humanEditorData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.humanEditorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.humanEditorData.Location = new System.Drawing.Point(0, 27);
            this.humanEditorData.Name = "humanEditorData";
            this.humanEditorData.Size = new System.Drawing.Size(708, 413);
            this.humanEditorData.TabIndex = 23;
            this.humanEditorData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.humanEditorData_CellDoubleClick);
            this.humanEditorData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.humanEditorData_RowsAdded);
            this.humanEditorData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.humanEditorData_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Точка продажи";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Продовец";
            this.Column2.Name = "Column2";
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
            // BasarAndProdovecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(708, 440);
            this.Controls.Add(this.humanEditorData);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BasarAndProdovecForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Точка продаж и продовцы";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BasarAndProdovecForm_FormClosed);
            this.Load += new System.EventHandler(this.BasarAndProdovecForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BasarAndProdovecForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.humanEditorData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохрантьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox findtxtbox01;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.DataGridView humanEditorData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem хToolStripMenuItem;
    }
}