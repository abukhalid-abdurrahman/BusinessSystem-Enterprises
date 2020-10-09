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
    public partial class RawMatFormStep1 : Form
    {
        public string DateTime = null;
        public string LoadString = null;
        public RawMatFormStep1()
        {
            InitializeComponent();
        }

        private void RawMatFormStep1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            General.FormBlock(e, this);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                RawMatFormStep2 R = new RawMatFormStep2();
                ResidueRawMaterials RRM = new ResidueRawMaterials();
                R.LoadRecords();
                RRM.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox5.Text, textBox4.Text, DateTime, textBoxPost.Text, textBoxPoluch.Text);
                R.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox5.Text, textBox4.Text, DateTime, textBoxPost.Text, textBoxPoluch.Text);
                R.ShowDialog(this);
                RRM.Close();
            }
            catch (Exception) { }
            */
            try
            {
                RawMatFormStep2 RawTable = new RawMatFormStep2();
                RawTable.LoadRecords();
                RawTable.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox5.Text, textBox4.Text, DateTime, textBoxPost.Text, textBoxPoluch.Text);
                ProductTableLoadder R = new ProductTableLoadder();
                R.TableName = LoadString;
                R.Text = "RawTable";
                ResidueRawMaterials RRM = new ResidueRawMaterials();
                R.LoadRecords();
                RRM.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox5.Text, textBox4.Text, DateTime, textBoxPost.Text, textBoxPoluch.Text);
                R.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox5.Text, textBox4.Text, DateTime, textBoxPost.Text, textBoxPoluch.Text);
                R.ShowDialog(this);
                RRM.Close();
                RawTable.Close();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
                General.Connection.Close();
            }
        }

        private float PriceValue = 0, CountValue = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Цена
            if (textBox1.Text == String.Empty || textBox1.Text == " " || textBox1.Text == null)
            {
                return;
            }
            else
            {
                try
                {
                    PriceValue = float.Parse(textBox1.Text.Replace(".", ","));
                    textBox4.Text = Convert.ToString((PriceValue * CountValue).ToString().Replace(",", "."));
                }
                catch (Exception)
                {
                    //Nothing
                }
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Кол-во
            if (textBox2.Text == String.Empty || textBox2.Text == " " || textBox2.Text == null)
            {
                return;
            }
            else
            {
                try
                {
                    CountValue = float.Parse(textBox2.Text.Replace(".", ","));
                    textBox4.Text = Convert.ToString((PriceValue * CountValue).ToString().Replace(",", "."));
                }
                catch (Exception)
                {
                    //Nothing
                }
            }
        }

        private void RawMatFormStep1_Load(object sender, EventArgs e)
        {
            titlebox.Text = LoadString;
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
