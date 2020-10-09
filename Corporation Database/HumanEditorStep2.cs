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
    public partial class HumanEditorStep2 : Form
    {
        public string Counterparty = null, Provider = null;
        public HumanEditorStep2()
        {
            InitializeComponent();
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
                PriceValue = float.Parse(textBox1.Text.Replace(".", ","));
                textBox4.Text = Convert.ToString((PriceValue * CountValue).ToString().Replace(",", "."));
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
                CountValue = float.Parse(textBox2.Text.Replace(".", ","));
                textBox4.Text = Convert.ToString((PriceValue * CountValue).ToString().Replace(",", "."));
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char numb = e.KeyChar;
            if (!Char.IsDigit(numb))
                e.Handled = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            General.CreateCounterpartyAccount(Counterparty);

            
            SaledShopMaterials SaledMaterials = new SaledShopMaterials();
            SaledMaterials.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox5.Text, DateTime.Today.ToString(), "Vella", Counterparty);
            SaledMaterials.Close();

            General.DeleteFromSQLDataBase("ResidueShopMaterials", "Имя", titlebox.Text);
            
            CounterpartyAccount CpAcc = new CounterpartyAccount();
            CpAcc.LoadString    = Counterparty;
            CpAcc.ProductName   = titlebox.Text;
            CpAcc.PriceString   = textBox1.Text;
            CpAcc.CountString   = textBox2.Text;
            CpAcc.SumString     = textBox4.Text;
            CpAcc.InsertRecordsBoolean = true;
            CpAcc.Date = dateTimePicker1.Text;
            CpAcc.ShowDialog(this);
        }

        private void HumanEditorStep2_Load(object sender, EventArgs e)
        {
            General.SetWatermark(titlebox, "Имя");
            General.SetWatermark(textBox1, "Цена");
            General.SetWatermark(textBox5, "Кол-во Карбок");
            General.SetWatermark(textBox2, "Кол-во");
            General.SetWatermark(textBox3, "Масса");
            General.SetWatermark(textBox4, "Сумма");
        }

        private void HumanEditorStep1_KeyDown(object sender, KeyEventArgs e)
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
