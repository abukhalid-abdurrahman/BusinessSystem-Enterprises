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
    public partial class SaledShopMaterials : Form
    {
        private bool hasSaved = false, Appendi = true;
        private object RowID = null;
        public SaledShopMaterials()
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
                Bitmap bm = new Bitmap(this.ShopMatData.Width, this.ShopMatData.Height);
                ShopMatData.DrawToBitmap(bm, new Rectangle(0, 0, this.ShopMatData.Width, this.ShopMatData.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ShopMatData, findtxtbox0.Text, 1);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("SaledShopMaterials", "ID", RowID);
                General.LoadSQLData("SaledShopMaterials", ShopMatData);
            }
            RowID = null;
            General.SetRowIndex(ShopMatData);
        }

        private void RawMatFormStep2_Load(object sender, EventArgs e)
        {
            LoadRecords();
            General.SetRowIndex(ShopMatData);
            General.SetGridStyle(ShopMatData, Color.CornflowerBlue);
            General.ChangeWidth(ShopMatData);
        }

        public void LoadRecords()
        {
            try
            {
                General.LoadSQLData("SaledShopMaterials", ShopMatData);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        public void InsertRecords(string Name, string Mass, string Price,
                                  string Count, string CrateCount, string Date,
                                  string Provider, string Recipient)
        {
            //int RowsCountID = 0;
            //RowsCountID = General.GetRowsCount("ShopMaterials");
            //RowsCountID += 1;
            General.Command = new SqlCommand("insert into SaledShopMaterials(Имя, Масса, Цена, Количество, КоличествоКаробок, Дата, Поставщик, Получатель) values(@name, @mass, @price, @count, @cratecount, @date, @provider, @recipient)", General.Connection);
            General.Connection.Open();
            //General.Command.Parameters.AddWithValue("@id", RowsCountID);
            General.Command.Parameters.AddWithValue("@name", Name);
            General.Command.Parameters.AddWithValue("@mass", Mass);
            General.Command.Parameters.AddWithValue("@price", Price);
            General.Command.Parameters.AddWithValue("@count", Count);
            General.Command.Parameters.AddWithValue("@cratecount", CrateCount);
            General.Command.Parameters.AddWithValue("@date", Date);
            General.Command.Parameters.AddWithValue("@provider", Provider);
            General.Command.Parameters.AddWithValue("@recipient", Recipient);
            General.Command.ExecuteNonQuery();
            General.Connection.Close();
            General.LoadSQLData("SaledShopMaterials", ShopMatData);
            RowID = null;
            hasSaved = true;
        }

        private void WorkersMoneyResults_Click(object sender, EventArgs e)
        {
            float Sum = 0;

            Sum = 0;

            for (int i = 0; i < ShopMatData.Rows.Count; i++)
            {
                Sum += float.Parse(ShopMatData.Rows[i].Cells[3].Value.ToString().Replace(".", ","));
            }
            WorkersMoneyResults.Text = String.Format("СУММА {0} СОМОН", Sum);
            General.WriteToFileValue(Application.StartupPath + "//Report//ShopSaled.data", Sum, false);
        }

        private void RawMatResultsDaa_KeyDown(object sender, KeyEventArgs e)
        {
            General.FormBlock(e, this);
        }

        private void RawMatResultsDaa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(ShopMatData);
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ShopMatData, findtxtbox0.Text, 1);
        }

        private void RawMatResultsDaa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            ShopMatData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void genGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("SaledShopMaterials", ShopMatData);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Количество", Table);
        }

        private void solaryMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(ShopMatData, 4, ListSortDirection.Descending);
        }

        private void solaryMinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(ShopMatData, 4, ListSortDirection.Ascending);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(ShopMatData);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(ShopMatData);
        }

        private void EditToolStrip_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RowID);
            UpdateRecordsManager u = new UpdateRecordsManager("SaledShopMaterials", id);
            u.ShowDialog(this);
            LoadRecords();
        }

        private void RawMatResultsDaa_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = ShopMatData.Rows[e.RowIndex].Cells[0].Value;
        }
    }
}
