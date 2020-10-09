using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Corporation_Database
{
    public partial class RawMaterialsRemove : Form
    {
        public string ID = null;
        public string Date = null;
        public string Provider = null;
        public string Recipient = null;
        public float Price = 0.0f;
        public float Summ = 0.0f;
        public float Mass = 0.0f;
        public float Count = 0.0f;
        public float CratesCount = 0.0f;

        public RawMaterialsRemove()
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
            try
            {
                Price = PriceValue;
                Count = Count - CountValue;
                Summ = Summ - SummValue;
                CratesCount = CratesCount - CratesCountBalue;
                Mass = Mass - MassValue;

                if (!File.Exists(Application.StartupPath + "//Raw.Residue.Data.xml"))
                {
                    General.ShowErrorBox("Список продуктов сырья отсутствует!\nВозможно была потеря данных, обратитесь к администрации программы!");
                }
                else
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(Application.StartupPath + "//Raw.Residue.Data.xml");
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlNode childnode = xRoot.SelectSingleNode(String.Format("RawResidue[Имя='{0}']", titlebox.Text));
                    if (childnode != null)
                    {
                            XmlNode nameChildNode = childnode.SelectSingleNode("Имя");
                            string elemNameStr = "NONE";
                            if (nameChildNode != null)
                            {
                                elemNameStr = nameChildNode.InnerText;
                                XmlNode massElem = childnode.SelectSingleNode("Масса");
                                XmlNode countElem = childnode.SelectSingleNode("Количество");
                                XmlNode cratesElem = childnode.SelectSingleNode("КоличествоКаробок");
                                XmlNode pricesElem = childnode.SelectSingleNode("Цена");
                                XmlNode summElem = childnode.SelectSingleNode("Сумма");

                                if (massElem != null && countElem != null && cratesElem != null && pricesElem != null && summElem != null)
                                {
                                    massElem.InnerText = Mass.ToString();
                                    countElem.InnerText = Count.ToString();
                                    cratesElem.InnerText = CratesCount.ToString();
                                    pricesElem.InnerText = Price.ToString();
                                    summElem.InnerText = Summ.ToString();
                                }
                            }
                        }
                    xDoc.Save(Application.StartupPath + "//Raw.Residue.Data.xml");
                }

                /*
                General.UpdateCellData("RawMaterialsResidue", "Цена", Price.ToString().Replace(",", "."), Convert.ToInt32(ID));
                General.UpdateCellData("RawMaterialsResidue", "Количество", Count.ToString().Replace(",", "."), Convert.ToInt32(ID));
                General.UpdateCellData("RawMaterialsResidue", "КоличествоКаробок", CratesCount.ToString().Replace(",", "."), Convert.ToInt32(ID));
                General.UpdateCellData("RawMaterialsResidue", "Масса", Mass.ToString().Replace(",", "."), Convert.ToInt32(ID));
                General.UpdateCellData("RawMaterialsResidue", "Сумма", Summ.ToString().Replace(",", "."), Convert.ToInt32(ID));
                */
                Date = DateControl.Value.ToString();
                if(ProviderTextBox.Text != null)
                    Provider = ProviderTextBox.Text;

                if (RecipientTextBox.Text != null)
                    Recipient = RecipientTextBox.Text;
                
                RemovedRawMaterialsForm RRMF = new RemovedRawMaterialsForm();
                RRMF.InsertRecords(titlebox.Text, MassValue.ToString().Replace(",", "."), PriceValue.ToString().Replace(",", "."), CountValue.ToString().Replace(",", "."), CratesCountBalue.ToString().Replace(",", "."), SummValue.ToString().Replace(",", "."), Date, Provider, Recipient);
                RRMF.ShowDialog(this);
                this.Close();
            }
            catch (Exception) { }
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
        float SummValue = 0.0f;
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SummValue = float.Parse(textBox4.Text.ToString().Replace(".", ","));
            }
            catch (Exception) { }
        }

        private void RawMaterialsRemove_Load(object sender, EventArgs e)
        {
            //textBox1.Text = Price.ToString().Replace(",", ".");
            //textBox2.Text = Count.ToString().Replace(",", ".");
            //textBox5.Text = CratesCount.ToString().Replace(",", ".");
            //textBox3.Text = Mass.ToString().Replace(",", ".");
            //textBox4.Text = Summ.ToString().Replace(",", ".");

            General.SetWatermark(titlebox, "Имя");
            General.SetWatermark(textBox1, "Цена");
            General.SetWatermark(textBox2, "Кол-во");
            General.SetWatermark(textBox5, "Кол-во Каробок");
            General.SetWatermark(textBox3, "Масса");
            General.SetWatermark(textBox4, "Сумма");
            General.SetWatermark(ProviderTextBox, "Поставщик");
            General.SetWatermark(RecipientTextBox, "Получатель");
        }

        float CratesCountBalue = 0.0f;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CratesCountBalue = float.Parse(textBox5.Text.ToString().Replace(".", ","));
            }
            catch (Exception) { }
        }

        float MassValue = 0.0f;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MassValue = float.Parse(textBox3.Text.ToString().Replace(".", ","));
            }
            catch (Exception) { }
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
