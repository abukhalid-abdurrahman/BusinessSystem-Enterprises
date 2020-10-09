namespace Corporation_Database
{
    partial class StorageViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ImportedMaterials = new System.Windows.Forms.DataGridView();
            this.RemovedMaterials = new System.Windows.Forms.DataGridView();
            this.ResidueMaterials = new System.Windows.Forms.DataGridView();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImportedMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemovedMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResidueMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RemovedMaterials);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(676, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Убранное";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ImportedMaterials);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(676, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Добавленное";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(684, 443);
            this.TabControl.TabIndex = 0;
            this.TabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ResidueMaterials);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(676, 417);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Оставшееся";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ImportedMaterials
            // 
            this.ImportedMaterials.AllowUserToAddRows = false;
            this.ImportedMaterials.AllowUserToDeleteRows = false;
            this.ImportedMaterials.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ImportedMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ImportedMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ImportedMaterials.DefaultCellStyle = dataGridViewCellStyle8;
            this.ImportedMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportedMaterials.Location = new System.Drawing.Point(3, 3);
            this.ImportedMaterials.Name = "ImportedMaterials";
            this.ImportedMaterials.ReadOnly = true;
            this.ImportedMaterials.Size = new System.Drawing.Size(670, 411);
            this.ImportedMaterials.TabIndex = 16;
            this.ImportedMaterials.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl_KeyDown);
            // 
            // RemovedMaterials
            // 
            this.RemovedMaterials.AllowUserToAddRows = false;
            this.RemovedMaterials.AllowUserToDeleteRows = false;
            this.RemovedMaterials.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RemovedMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.RemovedMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RemovedMaterials.DefaultCellStyle = dataGridViewCellStyle10;
            this.RemovedMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemovedMaterials.Location = new System.Drawing.Point(3, 3);
            this.RemovedMaterials.Name = "RemovedMaterials";
            this.RemovedMaterials.ReadOnly = true;
            this.RemovedMaterials.Size = new System.Drawing.Size(670, 411);
            this.RemovedMaterials.TabIndex = 16;
            this.RemovedMaterials.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl_KeyDown);
            // 
            // ResidueMaterials
            // 
            this.ResidueMaterials.AllowUserToAddRows = false;
            this.ResidueMaterials.AllowUserToDeleteRows = false;
            this.ResidueMaterials.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ResidueMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.ResidueMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ResidueMaterials.DefaultCellStyle = dataGridViewCellStyle12;
            this.ResidueMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResidueMaterials.Location = new System.Drawing.Point(0, 0);
            this.ResidueMaterials.Name = "ResidueMaterials";
            this.ResidueMaterials.ReadOnly = true;
            this.ResidueMaterials.Size = new System.Drawing.Size(676, 417);
            this.ResidueMaterials.TabIndex = 16;
            this.ResidueMaterials.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl_KeyDown);
            // 
            // StorageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 443);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StorageViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StorageViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StorageViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl_KeyDown);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImportedMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemovedMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResidueMaterials)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView RemovedMaterials;
        private System.Windows.Forms.DataGridView ImportedMaterials;
        private System.Windows.Forms.DataGridView ResidueMaterials;
    }
}