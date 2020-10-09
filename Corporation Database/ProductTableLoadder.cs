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
    public partial class ProductTableLoadder : Form
    {
        private bool hasSaved = false, Appendi = true;
        private object RowID = null;
        public string TableName = null;
        private string IDName = null;
        private string IDDate = null;
        public ProductTableLoadder()
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
            if (RowID != null && IDName != null)
            {
                General.DeleteFromSQLDataBase(TableName, "ID", RowID);
                if (this.Text == "RawTable")
                {
                    try
                    {
                        string IDStr = null;

                        General.Command = new SqlCommand("select ID from RawMaterials where Имя=@name and Дата=@date", General.Connection);
                        General.Connection.Open();
                        General.Command.Parameters.AddWithValue("@name", IDName.Trim());
                        General.Command.Parameters.AddWithValue("@date", IDDate.Trim());

                        SqlDataReader sqlReader = General.Command.ExecuteReader();

                        while (sqlReader.Read())
                        {
                            IDStr = sqlReader["ID"].ToString();
                        }

                        sqlReader.Close();
                        General.Connection.Close();
                        General.DeleteFromSQLDataBase("RawMaterials", "ID", int.Parse(IDStr));
                    }
                    catch (Exception)
                    {
                        General.Connection.Close();
                    }
                }
                else if (this.Text == "ShopTable")
                {
                    try
                    {
                        string IDStr = null;

                        General.Command = new SqlCommand("select ID from ShopMaterials where Имя=@name and Дата=@date", General.Connection);
                        General.Connection.Open();
                        General.Command.Parameters.AddWithValue("@name", IDName.Trim());
                        General.Command.Parameters.AddWithValue("@date", IDDate.Trim());

                        SqlDataReader sqlReader = General.Command.ExecuteReader();

                        while (sqlReader.Read())
                        {
                            IDStr = sqlReader["ID"].ToString();
                        }

                        sqlReader.Close();
                        General.Connection.Close();
                        General.DeleteFromSQLDataBase("ShopMaterials", "ID", int.Parse(IDStr));
                    }
                    catch (Exception)
                    {
                        General.Connection.Close();
                    }
                }
                General.LoadSQLData(TableName, RawMatResultsDaa);
            }
            RowID = null;
            IDDate = null;
            IDName = null;
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
                General.LoadSQLData(TableName, "ID, Масса, Цена, Количество, КоличествоКаробок, Сумма, Дата, Поставщик, Получатель", RawMatResultsDaa);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        public void InsertRecordsShop(string Name, string Mass, string Price,
                          string Count, string CrateCount, string Date,
                          string Provider, string Recipient)
        {
            float Summ = 0;
            try
            {
                float C = 0;
                float P = 0;
                C = float.Parse(Count.Replace(".", ","));
                P = float.Parse(Price.Replace(".", ","));
                Summ = C * P;
            }
            catch (Exception) { }
            //int RowsCountID = 0;
            //RowsCountID = General.GetRowsCount("ShopMaterials");
            //RowsCountID += 1;
            General.Command = new SqlCommand("insert into " + TableName + "(Имя, Масса, Цена, Количество, КоличествоКаробок, Сумма, Дата, Поставщик, Получатель) values(@name, @mass, @price, @count, @cratecount, @summ, @date, @provider, @recipient)", General.Connection);
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
            General.LoadSQLData(TableName, RawMatResultsDaa);
            RowID = null;
            IDName = null;
            IDDate = null;
            hasSaved = true;
        }

        public void InsertRecords(string Name, string Mass, string Price, 
                                  string Count, string CrateCount, string Summ, string Date, 
                                  string Provider, string Recipient)
        {
            //int RowsCountID = 0;
            //RowsCountID = General.GetRowsCount("RawMaterials");
            //RowsCountID += 1;
            General.Command = new SqlCommand("insert into " + TableName + "(Имя, Масса, Цена, Количество, КоличествоКаробок, Сумма, Дата, Поставщик, Получатель) values(@name, @mass, @price, @count, @cratecount, @summ, @date, @provider, @recipient)", General.Connection);
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
            General.LoadSQLData(TableName, RawMatResultsDaa);
            RowID = null;
            IDName = null;
            IDDate = null;
            hasSaved = true;
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
            string NameData = RawMatResultsDaa.Rows[e.RowIndex].Cells[1].Value.ToString();
            string IDData = RawMatResultsDaa.Rows[e.RowIndex].Cells[0].Value.ToString();
            string DateData = RawMatResultsDaa.Rows[e.RowIndex].Cells[6].Value.ToString();
            string Provider = RawMatResultsDaa.Rows[e.RowIndex].Cells[7].Value.ToString();
            string Recipient = RawMatResultsDaa.Rows[e.RowIndex].Cells[8].Value.ToString();
            RawMaterialsRemove RMR = new RawMaterialsRemove();
            RMR.titlebox.Text = NameData;
            RMR.ID = IDData;
            RMR.Date = DateData;
            RMR.Provider = Provider;
            RMR.Recipient = Recipient;
            RMR.ShowDialog(this);
        }

        private void genGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData(TableName, RawMatResultsDaa);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Сумма", Table);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(RawMatResultsDaa);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crateCountToolStripMenuItem_Click(object sender, EventArgs e)
        {       
            try
            {
                General.Command = new SqlCommand("select sum(КоличествоКаробок) from " + TableName, General.Connection);
                General.Connection.Open();
                float A = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                crateCountToolStripMenuItem.Text = "Кол-во Каробок " + A;
            } 
            catch(Exception)
            {
                float A = 0.0f;
                crateCountToolStripMenuItem.Text = "Кол-во Каробок " + A;
                General.Connection.Close();
            }
        }

        private void GeneralSummToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                General.Command = new SqlCommand("select sum(Сумма) from " + TableName, General.Connection);
                General.Connection.Open();
                float A = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                GeneralSummToolStripMenuItem.Text = "Общая Сумма " + A;
            }
            catch (Exception)
            {
                float A = 0.0f;
                GeneralSummToolStripMenuItem.Text = "Общая Сумма " + A;
                General.Connection.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(RawMatResultsDaa);
        }

        /*
private void saveCrateCountToReportToolStripMenuItem_Click(object sender, EventArgs e)
{
   General.CheckForExitsDirectory("CrateCountsData");
   General.CheckForExitsFile("CrateCountsData/" + LoadString + ".data");
   bool isNull = General.CheckIsFileNull("CrateCountsData/" + LoadString + ".data");
   float CrateCount = 0.0f;
   if (!isNull)
   {
       CrateCount = General.ReadFromFileValue("CrateCountsData/" + LoadString + ".data", 0);
       CrateCount += float.Parse(textBox4.Text.Replace(".", ","));
   }
   else if (isNull)
   {
       CrateCount = float.Parse(textBox4.Text.Replace(".", ","));
   }
   General.WriteToFileValue("CrateCountsData/" + LoadString + ".data", CrateCount, false);
}
*/
        private void RawMatResultsDaa_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = RawMatResultsDaa.Rows[e.RowIndex].Cells[0].Value;
            IDName = RawMatResultsDaa.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (this.Text == "RawTable")
                IDDate = RawMatResultsDaa.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
            else if (this.Text == "ShopTable")
                IDDate = RawMatResultsDaa.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
        }
    }
}
