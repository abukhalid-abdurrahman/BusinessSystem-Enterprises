using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corporation_Database
{
    public partial class GraphGenerator : Form
    {
        public string XValue, YValue;
        public DataTable ChartTable; 
        public GraphGenerator()
        {
            InitializeComponent();
        }

        private void светлыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
        }

        private void яркийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
        }

        private void шоколадныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
        }

        private void огненыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
        }

        private void колонкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void линииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void областьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
        }

        private void точкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chart.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        private void GraphGenerator_Load(object sender, EventArgs e)
        {
            Chart.Series["Итог"].XValueMember = XValue;
            Chart.Series["Итог"].YValueMembers = YValue;
            Chart.DataSource = ChartTable;
            Chart.DataBind();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveGraph(Chart);
        }
    }
}
