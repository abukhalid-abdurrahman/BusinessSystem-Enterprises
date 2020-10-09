using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Corporation_Database
{
    public partial class ProductConculationStep1 : Form
    {
        private object RowID = null;
        private string pName = String.Empty;

        public ProductConculationStep1()
        {
            InitializeComponent();
        }
        public void InsertRecords(string Name)
        {
            //int RowsCountID = 0;
            //RowsCountID = General.GetRowsCount("ConculationData");
            //RowsCountID += 1;
            General.Command = new SqlCommand("insert into ConculationData(Название) values(@name)", General.Connection);
            General.Connection.Open();
            //General.Command.Parameters.AddWithValue("@id", RowsCountID);
            General.Command.Parameters.AddWithValue("@name", Name);
            General.Command.ExecuteNonQuery();
            General.Connection.Close();
            General.LoadSQLData("ConculationData", ConculationDataEditor);
            RowID = null;
        }

        public void LoadRecords()
        {
            try
            {
                General.LoadSQLData("ConculationData", ConculationDataEditor);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void HumanEditorDataResults_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ConculationDataEditor, findtxtbox0.Text, 1);
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ConculationDataEditor, findtxtbox0.Text, 1);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("ConculationData", "ID", RowID);
                General.LoadSQLData("ConculationData", ConculationDataEditor);
                if(pName != null)
                {
                    General.DeleteDirectory("RawList//" + pName);
                }
            }
            RowID = null;
            pName = String.Empty;
            General.SetRowIndex(ConculationDataEditor);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DatabaseRecordsConfiguration DC = new DatabaseRecordsConfiguration();
            DC.dateTimePicker.Enabled = false;
            DC.TextBox1.Enabled = true;
            DC.TextBox0.Enabled = false;
            DC.TextBox2.Enabled = false;
            DC.TextBox3.Enabled = false;
            DC.TextBox4.Enabled = false;
            DC.dateTimePicker.Text = String.Empty;
            DC.TextBox0.Text = String.Empty;
            DC.TextBox2.Text = String.Empty;
            DC.TextBox3.Text = String.Empty;
            DC.TextBox4.Text = String.Empty;
            DC.TextBox1.Text = "Название";
            DC.ShowDialog(this);
            if (DC.TextBox1.Text == null || DC.TextBox1.Text == " " || DC.TextBox1.Text == "Название")
                return;
            else
                InsertRecords(DC.TextBox1.Text);
            General.SetGridStyle(ConculationDataEditor, Color.Coral);
        }

        private void ConculationDataEditor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = ConculationDataEditor.Rows[e.RowIndex].Cells[0].Value;
            pName = ConculationDataEditor.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void ProductConculationStep1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mineDataDataSet3.ConculationData' table. You can move, or remove it, as needed.
            this.conculationDataTableAdapter.Fill(this.mineDataDataSet3.ConculationData);
            LoadRecords();
            General.SetGridStyle(ConculationDataEditor, Color.Aqua);
            General.ChangeWidth(ConculationDataEditor);
        }

        private void ConculationDataEditor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductConculationStep2 PC = new ProductConculationStep2();
            PC.ProductName = ConculationDataEditor.Rows[e.RowIndex].Cells[1].Value.ToString();
            PC.ShowDialog(this);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
