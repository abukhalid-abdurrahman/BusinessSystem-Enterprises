namespace Corporation_Database
{
    partial class ProductListAdder
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
            this.ListB = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TextB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ListB
            // 
            this.ListB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListB.FormattingEnabled = true;
            this.ListB.ItemHeight = 24;
            this.ListB.Location = new System.Drawing.Point(12, 12);
            this.ListB.Name = "ListB";
            this.ListB.Size = new System.Drawing.Size(260, 220);
            this.ListB.TabIndex = 0;
            this.ListB.DoubleClick += new System.EventHandler(this.ListB_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextB
            // 
            this.TextB.Location = new System.Drawing.Point(12, 242);
            this.TextB.Name = "TextB";
            this.TextB.Size = new System.Drawing.Size(179, 20);
            this.TextB.TabIndex = 2;
            // 
            // ProductListAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 275);
            this.Controls.Add(this.TextB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ListB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductListAdder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Добавить";
            this.Load += new System.EventHandler(this.ProductListAdder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextB;
        public System.Windows.Forms.ListBox ListB;
    }
}