namespace Corporation_Database
{
    partial class GraphGenerator
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.светлыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.яркийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шоколадныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.огненыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.колонкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.областьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.styleToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(690, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.typeToolStripMenuItem});
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.styleToolStripMenuItem.Text = "Стиль";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.светлыйToolStripMenuItem,
            this.яркийToolStripMenuItem,
            this.шоколадныйToolStripMenuItem,
            this.огненыйToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.colorToolStripMenuItem.Text = "Цвет";
            // 
            // светлыйToolStripMenuItem
            // 
            this.светлыйToolStripMenuItem.Name = "светлыйToolStripMenuItem";
            this.светлыйToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.светлыйToolStripMenuItem.Text = "Светлый";
            this.светлыйToolStripMenuItem.Click += new System.EventHandler(this.светлыйToolStripMenuItem_Click);
            // 
            // яркийToolStripMenuItem
            // 
            this.яркийToolStripMenuItem.Name = "яркийToolStripMenuItem";
            this.яркийToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.яркийToolStripMenuItem.Text = "Яркий";
            this.яркийToolStripMenuItem.Click += new System.EventHandler(this.яркийToolStripMenuItem_Click);
            // 
            // шоколадныйToolStripMenuItem
            // 
            this.шоколадныйToolStripMenuItem.Name = "шоколадныйToolStripMenuItem";
            this.шоколадныйToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.шоколадныйToolStripMenuItem.Text = "Шоколадный";
            this.шоколадныйToolStripMenuItem.Click += new System.EventHandler(this.шоколадныйToolStripMenuItem_Click);
            // 
            // огненыйToolStripMenuItem
            // 
            this.огненыйToolStripMenuItem.Name = "огненыйToolStripMenuItem";
            this.огненыйToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.огненыйToolStripMenuItem.Text = "Огненый";
            this.огненыйToolStripMenuItem.Click += new System.EventHandler(this.огненыйToolStripMenuItem_Click);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.колонкиToolStripMenuItem,
            this.линииToolStripMenuItem,
            this.областьToolStripMenuItem,
            this.точкиToolStripMenuItem});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.typeToolStripMenuItem.Text = "Тип";
            // 
            // колонкиToolStripMenuItem
            // 
            this.колонкиToolStripMenuItem.Name = "колонкиToolStripMenuItem";
            this.колонкиToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.колонкиToolStripMenuItem.Text = "Колонки";
            this.колонкиToolStripMenuItem.Click += new System.EventHandler(this.колонкиToolStripMenuItem_Click);
            // 
            // линииToolStripMenuItem
            // 
            this.линииToolStripMenuItem.Name = "линииToolStripMenuItem";
            this.линииToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.линииToolStripMenuItem.Text = "Линии";
            this.линииToolStripMenuItem.Click += new System.EventHandler(this.линииToolStripMenuItem_Click);
            // 
            // областьToolStripMenuItem
            // 
            this.областьToolStripMenuItem.Name = "областьToolStripMenuItem";
            this.областьToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.областьToolStripMenuItem.Text = "Область";
            this.областьToolStripMenuItem.Click += new System.EventHandler(this.областьToolStripMenuItem_Click);
            // 
            // точкиToolStripMenuItem
            // 
            this.точкиToolStripMenuItem.Name = "точкиToolStripMenuItem";
            this.точкиToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.точкиToolStripMenuItem.Text = "Точки";
            this.точкиToolStripMenuItem.Click += new System.EventHandler(this.точкиToolStripMenuItem_Click);
            // 
            // Chart
            // 
            this.Chart.BackColor = System.Drawing.Color.Wheat;
            this.Chart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.Chart.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.WideUpwardDiagonal;
            this.Chart.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(0, 24);
            this.Chart.Name = "Chart";
            this.Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Итог";
            series1.YValuesPerPoint = 2;
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(690, 348);
            this.Chart.TabIndex = 1;
            this.Chart.Text = "Диаграмма";
            // 
            // GraphGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 372);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.Menu;
            this.Name = "GraphGenerator";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор Диаграмм";
            this.Load += new System.EventHandler(this.GraphGenerator_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem светлыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem яркийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шоколадныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem огненыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem колонкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem областьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точкиToolStripMenuItem;
    }
}