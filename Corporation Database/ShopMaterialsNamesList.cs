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
    public partial class ShopMaterialsNamesList : Form
    {
        string f_FileName, t_Type;
        public ShopMaterialsNamesList()
        {
            InitializeComponent();
        }

        public ShopMaterialsNamesList(string FileName, string i_Type)
        {
            InitializeComponent();
            f_FileName = FileName;
            t_Type = i_Type;
        }

        public void LoadRecords()
        {
            try
            {
                General.CheckForExitsFile(f_FileName);
                string[] Names = File.ReadAllLines(f_FileName);
                AccountTableList.Rows.Clear();
                if(Names != null)
                {
                    foreach (string finf in Names)
                    {
                        AccountTableList.Rows.Add(finf);
                    }
                }
            }
            catch (Exception) { }
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

        private void AccountTableList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(t_Type == "Imported")
            {
                string DataName = AccountTableList.Rows[e.RowIndex].Cells[0].Value.ToString();
                ProductTableLoadder pTable = new ProductTableLoadder();
                pTable.TableName = DataName;
                if (f_FileName == Application.StartupPath + "//RawProductsList.data")
                    pTable.Text = "RawTable";
                else if (f_FileName == Application.StartupPath + "//ShopProductsList.data")
                    pTable.Text = "ShopTable";
                pTable.ShowDialog(this);
            }
            else if(t_Type == "Shop")
            {
                string DataName = AccountTableList.Rows[e.RowIndex].Cells[0].Value.ToString();
                ProductTableLoadder pTable = new ProductTableLoadder();
                pTable.TableName = DataName;
                pTable.Text = "ShopTable";
                pTable.ShowDialog(this);
            }
        }

        private void generalListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f_FileName == Application.StartupPath + "//RawProductsList.data")
            {
                GeneralDataList GDList = new GeneralDataList(Application.StartupPath + "//RawProductsList.data", "RawResidue");
                GDList.ShowDialog(this);
            }
            else if (f_FileName == Application.StartupPath + "//ShopProductsList.data")
            {
                GeneralDataList GDList = new GeneralDataList(Application.StartupPath + "//ShopProductsList.data", "ShopResidue");
                GDList.ShowDialog(this);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(AccountTableList);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
