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

namespace Corporation_Database
{
    public partial class BasarAndProdovecForm : Form
    {
        string DataFilePath = "Counterparty.SPAS.DataBase.data";
        private bool hasSaved = false;

        public BasarAndProdovecForm()
        {
            InitializeComponent();
        }

        private void humanEditorData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }

        private void BasarAndProdovecForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }

        private void BasarAndProdovecForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!hasSaved)
            {
                if (MessageBox.Show("Сохранить данные?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    General.SaveData(DataFilePath, humanEditorData);
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

        private void BasarAndProdovecForm_Load(object sender, EventArgs e)
        {
            /*General.CheckForExitsFile(DataFilePath);*/
            General.LoadData(DataFilePath, humanEditorData);
            General.ChangeWidth(humanEditorData);
            General.SetGridStyle(humanEditorData, Color.MediumTurquoise);
        }

        private void humanEditorData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(humanEditorData);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            humanEditorData.Rows.Clear();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            humanEditorData.Rows.RemoveAt(General.GetRowIndex(humanEditorData));
            General.SetRowIndex(humanEditorData);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            humanEditorData.Rows.Add();
        }

        private void сохрантьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveData(DataFilePath, humanEditorData);
        }

        private void findtxtbox01_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(humanEditorData, findtxtbox01.Text, 0);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(humanEditorData, findtxtbox01.Text, 0);
        }

        private void humanEditorData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            humanEditorData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
