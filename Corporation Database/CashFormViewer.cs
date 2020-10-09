using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Corporation_Database
{
    public partial class CashFormViewer : Form
    {
        private object RowID;

        public CashFormViewer()
        {
            InitializeComponent();
        }

        public void LoadRecords()
        {
            try
            {
                General.LoadSQLData("CashData", CashEditor);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void CashFormViewer_Load(object sender, EventArgs e)
        {
            LoadRecords();
            General.ChangeWidth(CashEditor);
            General.SetRowIndex(CashEditor);
            General.SetGridStyle(CashEditor, Color.LightSeaGreen);
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument6.Print();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(CashEditor, toolStripTextBox1.Text, 1);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(CashEditor, toolStripTextBox1.Text, 1);
        }


        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("CashData", "ID", RowID);
                General.LoadSQLData("CashData", CashEditor);
            }
            RowID = null;
            General.SetRowIndex(CashEditor);
            General.SetGridStyle(CashEditor, Color.LightSeaGreen);
        }

        private void printDocument6_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.CashEditor.Width, this.CashEditor.Height);
                CashEditor.DrawToBitmap(bm, new Rectangle(0, 0, this.CashEditor.Width, this.CashEditor.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void CashEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CashEditor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(CashEditor);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(CashEditor);
        }

        private void solaryMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(CashEditor, 5, ListSortDirection.Descending);
        }

        private void долженToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(CashEditor, 2, ListSortDirection.Descending);
        }

        private void оплаченноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(CashEditor, 3, ListSortDirection.Descending);
        }

        private void осталосьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(CashEditor, 4, ListSortDirection.Descending);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("CashData", CashEditor);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Должен", Table);
        }

        private void CashEditor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = CashEditor.Rows[e.RowIndex].Cells[0].Value;
        }

        public void InsertRecords(string Recipient, string Dolzhen,
                                  string Oplacheno, string Ostalos, string Bonus, string Date)
        {
            General.Command = new SqlCommand("insert into CashData(Поставщик, Должен, Оплаченно, Осталось, Бонус, Дата) values(@recipient, @dolzhen, @oplacheno, @ostalos, @bonus, @date)", General.Connection);
            General.Connection.Open();
            General.Command.Parameters.AddWithValue("@recipient", Recipient);
            General.Command.Parameters.AddWithValue("@dolzhen", Dolzhen);
            General.Command.Parameters.AddWithValue("@oplacheno", Oplacheno);
            General.Command.Parameters.AddWithValue("@ostalos", Ostalos);
            General.Command.Parameters.AddWithValue("@bonus", Bonus);
            General.Command.Parameters.AddWithValue("@date", Date);
            General.Command.ExecuteNonQuery();
            General.Connection.Close();
            General.LoadSQLData("CashData", CashEditor);
            RowID = null;
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GeneralSumMenuitem_Click(object sender, EventArgs e)
        {
            float A = 0;
            for (int i = 0; i < CashEditor.Rows.Count; i++)
            {
                A += float.Parse(CashEditor.Rows[i].Cells[3].Value.ToString().Replace(".", ","));
            }
            GeneralSumMenuitem.Text = String.Format("ОБЩАЯ ОПЛАЧЕННАЯ СУММА {0} СОМОНИ", A);
            General.WriteToFileValue(Application.StartupPath + "//CPState.data", A, false);
        }

        private void DebtSumMenuITem_Click(object sender, EventArgs e)
        {
            float A = 0;
            for (int i = 0; i < CashEditor.Rows.Count; i++)
            {
                A += float.Parse(CashEditor.Rows[i].Cells[4].Value.ToString().Replace(".", ","));
            }
            DebtSumMenuITem.Text = String.Format("ОБЩАЯ СУММА ДОЛГА {0} СОМОНИ", A);
            General.WriteToFileValue(Application.StartupPath + "//Report//Debt.data", A, false);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(CashEditor);
        }

        private void EditStripItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RowID);
            UpdateRecordsManager u = new UpdateRecordsManager("CashData", id);
            u.ShowDialog(this);
            LoadRecords();
        }
    }
}
