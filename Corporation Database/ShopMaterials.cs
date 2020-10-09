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
    public partial class ShopMaterials : Form
    {
        string DataFilePath = "Shop.Materials.DataBase.Step0.data";
        private bool hasSaved = false;
        public string TakerFirm = null /* Получатель */, GiverFirm = null /* Поставщик */, DateTime = null;

        public ShopMaterials()
        {
            InitializeComponent();
        }

        private void ShopMaterials_Load(object sender, EventArgs e)
        {
            /*General.CheckForExitsFile(DataFilePath);*/
            General.ChangeWidth(ShopMaterialsData);
            General.LoadData(DataFilePath, ShopMaterialsData);
            General.SetGridStyle(ShopMaterialsData, Color.MediumTurquoise);
        }

        private void ShopMaterials_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }

        private void ShopMaterialsData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }

        private void ShopMaterials_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!hasSaved)
            {
                if (MessageBox.Show("Сохранить данные?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    General.SaveData(DataFilePath, ShopMaterialsData);
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

        private void ShopMaterialsData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(ShopMaterialsData);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopMaterialsData.Rows.Clear();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopMaterialsData.Rows.RemoveAt(General.GetRowIndex(ShopMaterialsData));
            General.SetRowIndex(ShopMaterialsData);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopMaterialsData.Rows.Add();
        }

        private void сохрантьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveData(DataFilePath, ShopMaterialsData);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ShopMaterialsData, findtxtbox0.Text, 0);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ShopMaterialsData, findtxtbox0.Text, 0);
        }

        private void ShopMaterialsData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < ShopMaterialsData.ColumnCount; i++)
            {
                ShopMaterialsStep1 R = new ShopMaterialsStep1();
                string RawValue = ShopMaterialsData.Rows[e.RowIndex].Cells[i].Value.ToString();
                if (RawValue == String.Empty || RawValue == " ")
                {
                    return;
                }
                else
                {
                    R.titlebox.Text = RawValue;
                    R.textBoxPoluch.Text = TakerFirm;
                    R.textBoxPost.Text = GiverFirm;
                    R.Date = DateTime;
                    R.ShowDialog(this);
                }
            }
        }
    }
}
