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
    public partial class HumanEditorStep1 : Form
    {
        private object RowID = null;
        public string Counterparty = null, Provider = null;

        public HumanEditorStep1()
        {
            InitializeComponent();
        }
        public void LoadRecords()
        {
            try
            {
                General.Connection.Open();
                DataTable DataT = new DataTable();
                General.Adapt = new SqlDataAdapter("select Имя from ShopMaterials", General.Connection);
                General.Adapt.Fill(DataT);
                HumanEditorDataResults.DataSource = DataT;
                General.Connection.Close();
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
            General.SearchFromDataGridViewControl(HumanEditorDataResults, findtxtbox0.Text, 0);
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(HumanEditorDataResults, findtxtbox0.Text, 0);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HumanEditorDataResults.Rows.Clear();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("CounterpartyData", "Имя", RowID);
                General.LoadSQLData("CounterpartyData", HumanEditorDataResults);
            }
            RowID = null;
            General.SetRowIndex(HumanEditorDataResults);
        }

        private void HumanEditorStep2_Load(object sender, EventArgs e)
        {
            LoadRecords();
            /*General.CheckForExitsFile(DataFilePath);*/
            General.SetRowIndex(HumanEditorDataResults);
            General.ChangeWidth(HumanEditorDataResults);
            General.SetGridStyle(HumanEditorDataResults, Color.MediumTurquoise);
        }

        private void HumanEditorDataResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            General.FormBlock(e, this);
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

        private void HumanEditorDataResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HumanEditorStep2 R = new HumanEditorStep2();
            string Caption = null;

            string RawValue = HumanEditorDataResults.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (RawValue == String.Empty || RawValue == " ")
            {
                return;
            }
            else
            {
                Caption = RawValue;
            }
            R.titlebox.Text = Caption;
            R.Counterparty = Counterparty;
            R.Provider = Provider;
            R.ShowDialog(this);
        }

        private void HumanEditorDataResults_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(HumanEditorDataResults);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(HumanEditorDataResults);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RowID);
            UpdateRecordsManager u = new UpdateRecordsManager("CounterpartyData", id);
            u.ShowDialog(this);
            LoadRecords();
        }

        private void HumanEditorDataResults_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = HumanEditorDataResults.Rows[e.RowIndex].Cells[0].Value;
        }
    }
}
