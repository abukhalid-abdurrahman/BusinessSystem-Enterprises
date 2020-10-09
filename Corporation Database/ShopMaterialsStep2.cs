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
    public partial class ShopMaterialsStep2 : Form
    {
        private string DataFilePath = "Shop.Materials.DataBase.Results.data";
        private string DataFilePath2 = "Counterparty.Materials.DataBase.Results.data";
        private bool hasSaved = true, Appendi = true;
        private object RowID = null;

        public ShopMaterialsStep2()
        {
            InitializeComponent();
        }

        public void LoadRecords()
        {
            try
            {
                General.LoadSQLData("ShopMaterials", ShopMatResultsDaa);
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
            General.Command = new SqlCommand("insert into ShopMaterials(Имя, Масса, Цена, Количество, КоличествоКаробок, Дата, Поставщик, Получатель) values(@name, @mass, @price, @count, @cratecount, @date, @provider, @recipient)", General.Connection);
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
            //General.LoadSQLData("ShopMaterials", ShopMatResultsDaa);
            RowID = null;
            hasSaved = true;
        }

        private void ShopMaterialsStep2_Load(object sender, EventArgs e)
        {
            LoadRecords();
            General.SetRowIndex(ShopMatResultsDaa);
            /*General.CheckForExitsFile(DataFilePath);*/
            General.ChangeWidth(ShopMatResultsDaa);
            General.SetGridStyle(ShopMatResultsDaa, Color.MediumTurquoise);
        }

        private void ShopMatResultsDaa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(ShopMatResultsDaa);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("ShopMaterials", "ID", RowID);
                General.LoadSQLData("ShopMaterials", ShopMatResultsDaa);
            }
            RowID = null;
            General.SetRowIndex(ShopMatResultsDaa);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopMatResultsDaa.Rows.Add();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ShopMatResultsDaa, findtxtbox0.Text, 1);
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ShopMatResultsDaa, findtxtbox0.Text, 1);
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
                Bitmap bm = new Bitmap(this.ShopMatResultsDaa.Width, this.ShopMatResultsDaa.Height);
                ShopMatResultsDaa.DrawToBitmap(bm, new Rectangle(0, 0, this.ShopMatResultsDaa.Width, this.ShopMatResultsDaa.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void ShopMatResultsDaa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!hasSaved)
                {
                    if (MessageBox.Show("Сохранить данные?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        General.SaveData(DataFilePath, ShopMatResultsDaa);
                        General.SaveData(DataFilePath2, ShopMatResultsDaa);
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                    this.Close();
            }

            General.FormBlock(e, this);
        }

        private void ShopMaterialsStep2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!hasSaved)
                {
                    if (MessageBox.Show("Сохранить данные?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        General.SaveData(DataFilePath, ShopMatResultsDaa);
                        General.SaveData(DataFilePath2, ShopMatResultsDaa);
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                    this.Close();
            }

            General.FormBlock(e, this);
        }

        private void WorkersMoneyResults_Click(object sender, EventArgs e)
        {
            float Sum = 0;

            for (int i = 0; i < ShopMatResultsDaa.Rows.Count; i++)
            {
                Sum += float.Parse(ShopMatResultsDaa.Rows[i].Cells[3].Value.ToString().Replace(".", ","));
            }
            WorkersMoneyResults.Text = String.Format("СУММА {0} СОМОН", Sum);
            General.WriteToFileValue("Report//ShopMaterials.data", Sum, false);
        }

        private void ShopMatResultsDaa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            ShopMatResultsDaa.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("ShopMaterials", ShopMatResultsDaa);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Количество", Table);
        }

        private void solaryMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(ShopMatResultsDaa, 3, ListSortDirection.Descending);
        }

        private void solaryMinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(ShopMatResultsDaa, 3, ListSortDirection.Ascending);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(ShopMatResultsDaa);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProductConculationStep1 PCS1 = new ProductConculationStep1();
            PCS1.ShowDialog(this);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crateCountToolStrip_Click(object sender, EventArgs e)
        {
            long Sum = 0;

            for (int i = 0; i < ShopMatResultsDaa.Rows.Count; i++)
            {
                Sum += Convert.ToInt32(ShopMatResultsDaa.Rows[i].Cells[5].Value);
            }
            crateCountToolStrip.Text = String.Format("КОЛ-ВО КАРОБОК {0} ШТУК", Sum);
            General.WriteToFileValue("BState.data", Sum, false);
        }

        private void ShopMatResultsDaa_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            /*
            string NameData = ShopMatResultsDaa.Rows[e.RowIndex].Cells[1].Value.ToString();
            string IDData = ShopMatResultsDaa.Rows[e.RowIndex].Cells[0].Value.ToString();
            string DateData = ShopMatResultsDaa.Rows[e.RowIndex].Cells[6].Value.ToString();
            string Provider = ShopMatResultsDaa.Rows[e.RowIndex].Cells[7].Value.ToString();
            string Recipient = ShopMatResultsDaa.Rows[e.RowIndex].Cells[8].Value.ToString();
            ShopMaterialsRemove SMR = new ShopMaterialsRemove();
            SMR.titlebox.Text = NameData;
            SMR.ID = IDData;
            SMR.Date = DateData;
            SMR.Provider = Provider;
            SMR.Recipient = Recipient;
            SMR.ShowDialog(this);
            */
        }

        private void EditStripMenu_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RowID);
            UpdateRecordsManager u = new UpdateRecordsManager("ShopMaterials", id);
            u.ShowDialog(this);
            LoadRecords();
        }

        private void ShopMatResultsDaa_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = ShopMatResultsDaa.Rows[e.RowIndex].Cells[0].Value;
        }
    }
}
