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
    public partial class RawMaterials : Form
    {
        public string TakerFirm = null /* Получатель */, GiverFirm = null /* Поставщик */, DateTime = null;
        private string DataFilePath = "Raw.Materials.DataBase.Step0.data";
        private bool hasSaved = false; 

        public RawMaterials()
        {
            InitializeComponent();
        }

        private void RawMaterials_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }

        private void RawMatData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }

        private void RawMaterials_Load(object sender, EventArgs e)
        {
            /*General.CheckForExitsFile(DataFilePath);*/
            General.LoadData(DataFilePath, RawMatData);
            General.ChangeWidth(RawMatData);
            General.SetGridStyle(RawMatData, Color.MediumTurquoise);
        }

        private void RawMaterials_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!hasSaved)
            {
                if (MessageBox.Show("Сохранить данные?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    General.SaveData(DataFilePath, RawMatData);
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

        private void RawMatData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(RawMatData);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(RawMatData, findtxtbox01.Text, 0);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawMatData.Rows.Clear();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawMatData.Rows.Add();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawMatData.Rows.RemoveAt(General.GetRowIndex(RawMatData));
            General.SetRowIndex(RawMatData);
        }

        private void сохрантьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveData(DataFilePath, RawMatData);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RawMatData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < RawMatData.ColumnCount; i++)
            {
                RawMatFormStep1 R = new RawMatFormStep1();
                string RawValue = RawMatData.Rows[e.RowIndex].Cells[i].Value.ToString();
                if (RawValue == String.Empty || RawValue == " ")
                {
                    return;
                }
                else
                {
                    R.titlebox.Text = RawValue;
                    R.textBoxPoluch.Text = TakerFirm;
                    R.textBoxPost.Text = GiverFirm;
                    R.DateTime = this.DateTime;
                    R.ShowDialog(this);
                }
            }
        }

        private void findtxtbox01_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(RawMatData, findtxtbox01.Text, 0);
        }
    }
}
