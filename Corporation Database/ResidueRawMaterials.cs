using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Corporation_Database
{
    public partial class ResidueRawMaterials : Form
    {
        private object RowID = null;
        public ResidueRawMaterials()
        {
            InitializeComponent();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.RawMatResultsDaa.Width, this.RawMatResultsDaa.Height);
                RawMatResultsDaa.DrawToBitmap(bm, new Rectangle(0, 0, this.RawMatResultsDaa.Width, this.RawMatResultsDaa.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(RawMatResultsDaa, findtxtbox0.Text, 1);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawMatResultsDaa.Rows.Clear();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawMatResultsDaa.Rows.Add();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("RawMaterialsResidue", "ID", RowID);
                General.LoadSQLData("RawMaterialsResidue", RawMatResultsDaa);
            }
            RowID = null;
            General.SetRowIndex(RawMatResultsDaa);
        }

        private void RawMatFormStep2_Load(object sender, EventArgs e)
        {
            LoadRecords();
            /*General.CheckForExitsFile(DataFilePath);*/
            General.SetRowIndex(RawMatResultsDaa);
            General.SetGridStyle(RawMatResultsDaa, Color.CornflowerBlue);
            General.ChangeWidth(RawMatResultsDaa);
        }

        public void LoadRecords()
        {
            try
            {
                General.LoadSQLData("RawMaterialsResidue", RawMatResultsDaa);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        public void InsertRecords(string Name, string Mass, string Price, 
                                  string Count, string CrateCount, string Summ, string Date, 
                                  string Provider, string Recipient)
        {
            //int RowsCountID = 0;
            //RowsCountID = General.GetRowsCount("RawMaterials");
            //RowsCountID += 1;
            General.Command = new SqlCommand("insert into RawMaterialsResidue(Имя, Масса, Цена, Количество, КоличествоКаробок, Сумма, Дата, Поставщик, Получатель) values(@name, @mass, @price, @count, @cratecount, @summ, @date, @provider, @recipient)", General.Connection);
            General.Connection.Open();
            //General.Command.Parameters.AddWithValue("@id", RowsCountID);
            General.Command.Parameters.AddWithValue("@name", Name);
            General.Command.Parameters.AddWithValue("@mass", Mass);
            General.Command.Parameters.AddWithValue("@price", Price);
            General.Command.Parameters.AddWithValue("@count", Count);
            General.Command.Parameters.AddWithValue("@cratecount", CrateCount);
            General.Command.Parameters.AddWithValue("@summ", Summ);
            General.Command.Parameters.AddWithValue("@date", Date);
            General.Command.Parameters.AddWithValue("@provider", Provider);
            General.Command.Parameters.AddWithValue("@recipient", Recipient);
            General.Command.ExecuteNonQuery();
            General.Connection.Close();
            //General.LoadSQLData("RemovedRawMaterials", RawMatResultsDaa);
            RowID = null;
        }

        private void WorkersMoneyResults_Click(object sender, EventArgs e)
        {
            float Sum = 0;

            Sum = 0;

            for (int i = 0; i < RawMatResultsDaa.Rows.Count; i++)
            {
                Sum += float.Parse(RawMatResultsDaa.Rows[i].Cells[6].Value.ToString().Replace(".", ","));
            }
            WorkersMoneyResults.Text = String.Format("СУММА {0} СОМОН", Sum);
            General.WriteToFileValue("Report//RawsResidue.data", Sum, false);
        }

        private void RawMatResultsDaa_KeyDown(object sender, KeyEventArgs e)
        {
            General.FormBlock(e, this);
        }

        private void RawMatResultsDaa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(RawMatResultsDaa);
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(RawMatResultsDaa, findtxtbox0.Text, 1);
        }

        private void RawMatResultsDaa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            RawMatResultsDaa.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void genGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("RawMaterialsResidue", RawMatResultsDaa);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Сумма", Table);
        }

        private void solaryMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(RawMatResultsDaa, 4, ListSortDirection.Descending);
        }

        private void solaryMinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(RawMatResultsDaa, 4, ListSortDirection.Ascending);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(RawMatResultsDaa);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RawMatResultsDaa_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = RawMatResultsDaa.Rows[e.RowIndex].Cells[0].Value;
        }

        private void EditToolStrip_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RowID);
            UpdateRecordsManager u = new UpdateRecordsManager("RawMaterialsResidue", id);
            u.ShowDialog(this);
            LoadRecords();
        }
    }
}
