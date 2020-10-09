namespace Corporation_Database
{
    partial class ProductConculationStep2
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
            this.Caption = new System.Windows.Forms.Label();
            this.MassProductListBox = new System.Windows.Forms.ListBox();
            this.RawMaterialListBox = new System.Windows.Forms.ListBox();
            this.MassDataTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CostTextBox = new System.Windows.Forms.TextBox();
            this.CostListBox = new System.Windows.Forms.ListBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SumLabel = new System.Windows.Forms.Label();
            this.RawDataComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Caption
            // 
            this.Caption.AutoSize = true;
            this.Caption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Caption.Location = new System.Drawing.Point(16, 9);
            this.Caption.Name = "Caption";
            this.Caption.Size = new System.Drawing.Size(184, 26);
            this.Caption.TabIndex = 0;
            this.Caption.Text = "Название: Продукт";
            // 
            // MassProductListBox
            // 
            this.MassProductListBox.FormattingEnabled = true;
            this.MassProductListBox.Location = new System.Drawing.Point(364, 44);
            this.MassProductListBox.Name = "MassProductListBox";
            this.MassProductListBox.Size = new System.Drawing.Size(262, 251);
            this.MassProductListBox.TabIndex = 1;
            // 
            // RawMaterialListBox
            // 
            this.RawMaterialListBox.FormattingEnabled = true;
            this.RawMaterialListBox.Location = new System.Drawing.Point(12, 43);
            this.RawMaterialListBox.Name = "RawMaterialListBox";
            this.RawMaterialListBox.Size = new System.Drawing.Size(346, 251);
            this.RawMaterialListBox.TabIndex = 2;
            // 
            // MassDataTextBox
            // 
            this.MassDataTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MassDataTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.MassDataTextBox.Location = new System.Drawing.Point(364, 301);
            this.MassDataTextBox.Multiline = true;
            this.MassDataTextBox.Name = "MassDataTextBox";
            this.MassDataTextBox.Size = new System.Drawing.Size(262, 33);
            this.MassDataTextBox.TabIndex = 8;
            this.MassDataTextBox.Text = "Введите массу...";
            this.MassDataTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MassDataTextBox.Click += new System.EventHandler(this.DataTextBox_Click);
            this.MassDataTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MassDataTextBox_MouseClick);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new System.Drawing.Point(815, 301);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(41, 33);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "+";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CostTextBox
            // 
            this.CostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CostTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.CostTextBox.Location = new System.Drawing.Point(632, 300);
            this.CostTextBox.Multiline = true;
            this.CostTextBox.Name = "CostTextBox";
            this.CostTextBox.Size = new System.Drawing.Size(177, 33);
            this.CostTextBox.TabIndex = 13;
            this.CostTextBox.Text = "Введите цену,,,";
            this.CostTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CostTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CostTextBox_MouseClick);
            // 
            // CostListBox
            // 
            this.CostListBox.FormattingEnabled = true;
            this.CostListBox.Location = new System.Drawing.Point(632, 43);
            this.CostListBox.Name = "CostListBox";
            this.CostListBox.Size = new System.Drawing.Size(224, 251);
            this.CostListBox.TabIndex = 14;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(781, 14);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 15;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SumLabel
            // 
            this.SumLabel.AutoSize = true;
            this.SumLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumLabel.Location = new System.Drawing.Point(236, 9);
            this.SumLabel.Name = "SumLabel";
            this.SumLabel.Size = new System.Drawing.Size(229, 26);
            this.SumLabel.TabIndex = 16;
            this.SumLabel.Text = "Общая Сумма: 0 Сомони";
            // 
            // RawDataComboBox
            // 
            this.RawDataComboBox.Enabled = false;
            this.RawDataComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RawDataComboBox.FormattingEnabled = true;
            this.RawDataComboBox.Location = new System.Drawing.Point(13, 300);
            this.RawDataComboBox.Name = "RawDataComboBox";
            this.RawDataComboBox.Size = new System.Drawing.Size(345, 26);
            this.RawDataComboBox.TabIndex = 17;
            this.RawDataComboBox.Visible = false;
            this.RawDataComboBox.SelectedIndexChanged += new System.EventHandler(this.RawDataComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Подсчёт общего расхода";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.NameTextBox.Location = new System.Drawing.Point(13, 301);
            this.NameTextBox.Multiline = true;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(346, 33);
            this.NameTextBox.TabIndex = 19;
            this.NameTextBox.Text = "Введите имя...";
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NameTextBox_MouseClick);
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // ProductConculationStep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 342);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RawDataComboBox);
            this.Controls.Add(this.SumLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CostListBox);
            this.Controls.Add(this.CostTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MassDataTextBox);
            this.Controls.Add(this.RawMaterialListBox);
            this.Controls.Add(this.MassProductListBox);
            this.Controls.Add(this.Caption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductConculationStep2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конкуляция Продуктов";
            this.Load += new System.EventHandler(this.ProductConculationStep2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox MassProductListBox;
        private System.Windows.Forms.ListBox RawMaterialListBox;
        private System.Windows.Forms.TextBox MassDataTextBox;
        public System.Windows.Forms.Label Caption;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox CostTextBox;
        private System.Windows.Forms.ListBox CostListBox;
        private System.Windows.Forms.Button DeleteButton;
        public System.Windows.Forms.Label SumLabel;
        private System.Windows.Forms.ComboBox RawDataComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NameTextBox;
    }
}