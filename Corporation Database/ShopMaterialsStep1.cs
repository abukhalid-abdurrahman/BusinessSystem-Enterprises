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
    public partial class ShopMaterialsStep1 : Form
    {
        public string Date = null;
        public string LoadString = null;
        public ShopMaterialsStep1()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
             {
                float Price = float.Parse(textBox1.Text.ToString().Replace(".", ","));
                float Count = float.Parse(textBox2.Text.ToString().Replace(".", ","));
                float Summ = Price * Count;

                ProductTableLoadder ProdTable = new ProductTableLoadder();
                ShopMaterialsNamesList MatNames = new ShopMaterialsNamesList("ShopProductsList.data", "Shop");
                ShopMaterialsStep2 ShopTable = new ShopMaterialsStep2();
                ResidueShopMaterials ResidShopTable = new ResidueShopMaterials();
                //RemovedRawMaterialsForm RemRawShopTable = new RemovedRawMaterialsForm();
                ProdTable.TableName = LoadString;
                ProdTable.LoadRecords();
                //RemRawShopTable.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text, Summ.ToString().Replace(",", "."), Date, textBoxPost.Text, textBoxPoluch.Text);
                ResidShopTable.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text, Date, textBoxPost.Text, textBoxPoluch.Text);
                General.DeleteFromSQLDataBase("RawMaterialsResidue", "Имя", titlebox.Text);
                ShopTable.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text, Date, textBoxPost.Text, textBoxPoluch.Text);
                ProdTable.InsertRecordsShop(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text, Date, textBoxPost.Text, textBoxPoluch.Text);
                //RemRawShopTable.Close();
                ShopTable.Close();
                ResidShopTable.Close();
                MatNames.LoadRecords();
                MatNames.ShowDialog(this);
                ProdTable.Close();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
                General.Connection.Close();
            }
        }

        private void ShopMaterialsStep1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }

        private void OKButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }
    }
}
