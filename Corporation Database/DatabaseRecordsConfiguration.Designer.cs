namespace Corporation_Database
{
    partial class DatabaseRecordsConfiguration
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
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TextBox0 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(12, 64);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(219, 20);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.Text = "Зарплата(Только цифры)";
            this.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(12, 90);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(219, 20);
            this.TextBox2.TabIndex = 2;
            this.TextBox2.Text = "Аванс(Только цифры)";
            this.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(12, 116);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(219, 20);
            this.TextBox3.TabIndex = 3;
            this.TextBox3.Text = "Остаток(Только цифры)";
            this.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBox4
            // 
            this.TextBox4.Location = new System.Drawing.Point(12, 142);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(219, 20);
            this.TextBox4.TabIndex = 4;
            this.TextBox4.Text = "Общий(Только цифры)";
            this.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(12, 168);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(219, 23);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "ОК";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 13);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(219, 20);
            this.dateTimePicker.TabIndex = 7;
            // 
            // TextBox0
            // 
            this.TextBox0.FormattingEnabled = true;
            this.TextBox0.Location = new System.Drawing.Point(12, 37);
            this.TextBox0.Name = "TextBox0";
            this.TextBox0.Size = new System.Drawing.Size(219, 21);
            this.TextBox0.TabIndex = 8;
            // 
            // DatabaseRecordsConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 199);
            this.Controls.Add(this.TextBox0);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.TextBox4);
            this.Controls.Add(this.TextBox3);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DatabaseRecordsConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить";
            this.Load += new System.EventHandler(this.DatabaseRecordsConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OKBtn;
        public System.Windows.Forms.TextBox TextBox1;
        public System.Windows.Forms.TextBox TextBox2;
        public System.Windows.Forms.TextBox TextBox3;
        public System.Windows.Forms.TextBox TextBox4;
        public System.Windows.Forms.DateTimePicker dateTimePicker;
        public System.Windows.Forms.ComboBox TextBox0;
    }
}