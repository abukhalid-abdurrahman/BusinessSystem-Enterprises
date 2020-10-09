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
    public partial class CounterpartyAccount : Form
    {
        private object RowID = null;
        public string LoadString = null, ProductName = null, PriceString = null, CountString = null, SumString = null;
        public bool InsertRecordsBoolean = false;
        public bool CreateTable = true;
        public string Date;
        public bool insertRecords = true;
        public CounterpartyAccount()
        {
            InitializeComponent();
        }

        public void LoadRecords()
        {
            try
            {
                AttachToAccount();
            }
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
                Bitmap bm = new Bitmap(this.AccountTable.Width, this.AccountTable.Height);
                AccountTable.DrawToBitmap(bm, new Rectangle(0, 0, this.AccountTable.Width, this.AccountTable.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(AccountTable, findtxtbox0.Text, 1);
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(AccountTable, findtxtbox0.Text, 1);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase(LoadString, "ID", RowID);
                General.LoadSQLData(LoadString, AccountTable);
            }
            RowID = null;
            General.SetRowIndex(AccountTable);
            General.SetGridStyle(AccountTable, Color.LightSeaGreen); General.SetRowIndex(AccountTable);
        }

        private void HumanEditorStep2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mineDataDataSet3.CounterpartyData' table. You can move, or remove it, as needed.
            //this.counterpartyDataTableAdapter.Fill(this.mineDataDataSet3.CounterpartyData);
            LoadRecords();
            /*General.CheckForExitsFile(DataFilePath);*/
            General.SetRowIndex(AccountTable);
            General.ChangeWidth(AccountTable);
            General.SetGridStyle(AccountTable, Color.MediumTurquoise);
        }

        private void HumanEditorStep2_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void AttachToAccount()
        {
            if (CreateTable)
            {
                General.CreateTable(LoadString, String.Format("ID int IDENTITY (1, 1) not null, Продукт nchar(25) not null, Цена float not null, Количество float not null, Сумма float not null, Дата nvarchar(15), constraint PK_{0} primary key clustered([ID] ASC)", LoadString));
            }
            if(insertRecords)
            {
                InsertRecords();
            }
            AttachToTable();
        }

        public void AttachToTable()
        {
            General.LoadSQLData(LoadString, AccountTable);
        }

        public void InsertRecords()
        {
            if (InsertRecordsBoolean)
            {
                //int RowsCountID = 0;
                //RowsCountID = General.GetRowsCount(LoadString);
                //RowsCountID += 1;
                General.Command = new SqlCommand(String.Format("insert into {0}(Продукт, Цена, Количество, Сумма, Дата) values(@name, @price, @count, @summ, @date)", LoadString), General.Connection);
                General.Connection.Open();
                //General.Command.Parameters.AddWithValue("@id", RowsCountID);
                General.Command.Parameters.AddWithValue("@name", ProductName);
                General.Command.Parameters.AddWithValue("@price", PriceString);
                General.Command.Parameters.AddWithValue("@count", CountString);
                General.Command.Parameters.AddWithValue("@summ", SumString);
                General.Command.Parameters.AddWithValue("@date", Date);
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
                General.LoadSQLData(LoadString, AccountTable);
                RowID = null;

                General.DebtManager(Convert.ToInt32(SumString), true, LoadString);
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData(LoadString, AccountTable);
            General.Adapt.Fill(Table);
            General.GenGraph("Имя", "Количество", Table);
        }
        
        private void HumanEditorDataResults_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = AccountTable.Rows[e.RowIndex].Cells[0].Value;
        }

        private void summToolStripMenuItem_Click(object sender, EventArgs e)
        {
            long WorkersSum;
            long A = 0;
            WorkersSum = 0;
            for (int i = 0; i < AccountTable.Rows.Count; i++)
            {
                A = Convert.ToInt32(AccountTable.Rows[i].Cells[4].Value);
                WorkersSum += A;
            }
            summToolStripMenuItem.Text = String.Format("СУММА {0} СОМОНИ", WorkersSum);
        }

        private void debtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            debtToolStripMenuItem.Text = String.Format("Долг: {0} Сомони", General.GetDebt(LoadString));
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(AccountTable);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(AccountTable);
        }

        private void количествоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(AccountTable, 3, ListSortDirection.Descending);
        }

        private void количествоПоУбывToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(AccountTable, 3, ListSortDirection.Ascending);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
