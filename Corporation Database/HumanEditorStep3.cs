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
    public partial class HumanEditorStep3 : Form
    {
        private string DataFilePath = "Counterparty.EndOf.DataBase.Results.data";
        private object RowID = null;

        public HumanEditorStep3()
        {
            InitializeComponent();
        }

        public void LoadRecords()
        {
            try
            {
                General.LoadSQLData("CounterpartyData", HumanEditorDataResults);            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
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
                Bitmap bm = new Bitmap(this.HumanEditorDataResults.Width, this.HumanEditorDataResults.Height);
                HumanEditorDataResults.DrawToBitmap(bm, new Rectangle(0, 0, this.HumanEditorDataResults.Width, this.HumanEditorDataResults.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(HumanEditorDataResults, findtxtbox0.Text, 1);
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(HumanEditorDataResults, findtxtbox0.Text, 1);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("CounterpartyData", "ID", RowID);
                General.LoadSQLData("CounterpartyData", HumanEditorDataResults);
            }
            RowID = null;
            General.SetRowIndex(HumanEditorDataResults);
            General.SetGridStyle(HumanEditorDataResults, Color.LightSeaGreen); General.SetRowIndex(HumanEditorDataResults);
        }

        private void HumanEditorStep2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mineDataDataSet3.CounterpartyData' table. You can move, or remove it, as needed.
            this.counterpartyDataTableAdapter.Fill(this.mineDataDataSet3.CounterpartyData);
            LoadRecords();
            /*General.CheckForExitsFile(DataFilePath);*/
            General.SetRowIndex(HumanEditorDataResults);
            General.ChangeWidth(HumanEditorDataResults);
            General.SetGridStyle(HumanEditorDataResults, Color.MediumTurquoise);
        }

        private void HumanEditorStep2_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            */
            General.FormBlock(e, this);
        }

        private void HumanEditorDataResults_KeyDown_1(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            
            General.FormBlock(e, this);
        }

        public void InsertRecords(string Name, string Price,
                  string Count,
                  string Provider, string Counterparty)
        {
            //int RowsCountID = 0;
            //RowsCountID = General.GetRowsCount("CounterpartyData");
            //RowsCountID += 1;
            General.Command = new SqlCommand("insert into CounterpartyData(Имя, Цена, Количество, Поставщик, Контрагент) values(@name, @price, @count, @provider, @counterparty)", General.Connection);
            General.Connection.Open();
            //General.Command.Parameters.AddWithValue("@id", RowsCountID);
            General.Command.Parameters.AddWithValue("@name", Name);
            General.Command.Parameters.AddWithValue("@price", Price);
            General.Command.Parameters.AddWithValue("@count", Count);
            General.Command.Parameters.AddWithValue("@provider", Provider);
            General.Command.Parameters.AddWithValue("@counterparty", Counterparty);
            General.Command.ExecuteNonQuery();
            General.Connection.Close();
            General.LoadSQLData("CounterpartyData", HumanEditorDataResults);
            RowID = null;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("CounterpartyData", HumanEditorDataResults);
            General.Adapt.Fill(Table);
            General.GenGraph("Контрагент", "Количество", Table);
        }

        private void HumanEditorDataResults_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = HumanEditorDataResults.Rows[e.RowIndex].Cells[0].Value;
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(HumanEditorDataResults);
        }

        private void количествоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(HumanEditorDataResults, 3, ListSortDirection.Descending);
        }

        private void количествоПоУбывToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(HumanEditorDataResults, 3, ListSortDirection.Ascending);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
