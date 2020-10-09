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
using System.Threading;

namespace Corporation_Database
{
    public partial class CounterpartyAccountList : Form
    {
        private string SelectedItemString = null;
        public CounterpartyAccountList()
        {
            InitializeComponent();
        }

        public void LoadRecords()
        {
            try
            {
                DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "//CounterpartyAgentsList");
                FileInfo[] info = Dinfo.GetFiles("*.");
                AccountTableList.Rows.Clear();
                if(info != null)
                {
                    foreach (FileInfo finf in info)
                    {
                        AccountTableList.Rows.Add(finf.Name);
                    }
                }
            }
            catch (Exception) { }
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
                Bitmap bm = new Bitmap(this.AccountTableList.Width, this.AccountTableList.Height);
                AccountTableList.DrawToBitmap(bm, new Rectangle(0, 0, this.AccountTableList.Width, this.AccountTableList.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(AccountTableList, findtxtbox0.Text, 0);
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(AccountTableList, findtxtbox0.Text, 0);
        }

        private void HumanEditorStep2_Load(object sender, EventArgs e)
        {
            LoadRecords();
            General.SetRowIndex(AccountTableList);
            General.ChangeWidth(AccountTableList);
            General.SetGridStyle(AccountTableList, Color.MediumTurquoise);
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

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(AccountTableList);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccountTableList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedItemString = AccountTableList.Rows[e.RowIndex].Cells[0].Value.ToString();
            CounterpartyAccount cp_acc = new CounterpartyAccount();
            cp_acc.CreateTable = true;
            cp_acc.insertRecords = false;
            cp_acc.LoadString = SelectedItemString;
            cp_acc.ShowDialog(this);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(AccountTableList);
        }
    }
}
