using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corporation_Database
{
    public partial class TableViewer : Form
    {
        private string tableName;
        private object rowID = null;

        public TableViewer()
        {
            InitializeComponent();
        }

        public TableViewer(string TableName)
        {
            InitializeComponent();
            tableName = TableName;
        }

        void LoadData(string t)
        {
            try
            {
                General.LoadSQLData(t, DataControl);
                General.SetRowIndex(DataControl);
            }
            catch (Exception)
            {
                General.Connection.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(DataControl);
        }

        private void exportExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(DataControl);
        }

        private void DataControl_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                rowID = DataControl.Rows[e.RowIndex].Cells[0].Value;
        }

        private void DataControl_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                rowID = DataControl.Rows[e.RowIndex].Cells[0].Value;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                General.DeleteFromSQLDataBase(tableName, "ID", rowID);
                LoadData(tableName);
            }
            catch (Exception)
            {
                General.Connection.Close();
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(DataControl, searchTextBox.Text, 1);
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(DataControl, searchTextBox.Text, 1);
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TableViewer_Load(object sender, EventArgs e)
        {
            if(tableName != null)
                LoadData(tableName);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(rowID);
            if(tableName != null)
            {
                UpdateRecordsManager u = new UpdateRecordsManager(tableName, id);
                u.ShowDialog(this);
                LoadData(tableName);
            }
        }
    }
}
