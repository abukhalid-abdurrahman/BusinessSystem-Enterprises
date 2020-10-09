namespace Corporation_Database
{
    partial class RecieverList
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
            this.List = new System.Windows.Forms.ListBox();
            this.ClientList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.List.FormattingEnabled = true;
            this.List.HorizontalScrollbar = true;
            this.List.ItemHeight = 24;
            this.List.Location = new System.Drawing.Point(12, 12);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(238, 268);
            this.List.TabIndex = 0;
            this.List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.List_MouseClick);
            // 
            // ClientList
            // 
            this.ClientList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientList.FormattingEnabled = true;
            this.ClientList.HorizontalScrollbar = true;
            this.ClientList.ItemHeight = 24;
            this.ClientList.Location = new System.Drawing.Point(256, 12);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(238, 268);
            this.ClientList.TabIndex = 1;
            this.ClientList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ClientList_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить точку продажи";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(256, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 47);
            this.button2.TabIndex = 3;
            this.button2.Text = "Добавить Клиента";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(102, 286);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(392, 20);
            this.NameTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Наименование";
            // 
            // RecieverList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.List);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RecieverList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Лист Получателей";
            this.Load += new System.EventHandler(this.RecieverList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox List;
        public System.Windows.Forms.ListBox ClientList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;

    }
}