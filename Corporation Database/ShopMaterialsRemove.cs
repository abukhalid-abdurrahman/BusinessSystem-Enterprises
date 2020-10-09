using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class ShopMaterialsRemove : Form
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

        public ShopMaterialsRemove()
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

                if (!File.Exists(Application.StartupPath + "//Shop.Residue.Data.xml"))
                {
                    General.ShowErrorBox("Список продуктов цеха отсутствует!\nВозможно была потеря данных, обратитесь к администрации программы!");
                }
                else
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(Application.StartupPath + "//Shop.Residue.Data.xml");
                    XmlElement xRoot = xDoc.DocumentElement;
                    XmlNode childnode = xRoot.SelectSingleNode(String.Format("ShopResidue[Имя='{0}']", titlebox.Text));
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
                    xDoc.Save(Application.StartupPath + "//Shop.Residue.Data.xml");
                }

                //General.UpdateCellData("ResidueShopMaterials", "Масса", textBox3.Text, Convert.ToInt32(ID));
                //General.UpdateCellData("ResidueShopMaterials", "Цена", textBox1.Text, Convert.ToInt32(ID));
                //General.UpdateCellData("ResidueShopMaterials", "Количество", textBox2.Text, Convert.ToInt32(ID));
                //General.UpdateCellData("ResidueShopMaterials", "КоличествоКаробок", textBox5.Text, Convert.ToInt32(ID));
                //General.UpdateCellData("ResidueShopMaterials", "Сумма", textBox4.Text, Convert.ToInt32(ID));


                Date = DateControl.Text.ToString();
                if (ProviderTextBox.Text != null)
                    Provider = ProviderTextBox.Text;

                if (RecipientTextBox.Text != null)
                    Recipient = RecipientTextBox.Text;


                SaledShopMaterials RRMF = new SaledShopMaterials();
                RRMF.InsertRecords(titlebox.Text, textBox3.Text, textBox1.Text, textBox2.Text, textBox5.Text, Date, Provider, Recipient);
                RRMF.ShowDialog(this);

            try
            {
                General.CreateTable(Recipient, String.Format("ID int IDENTITY (1, 1) not null, Продукт nchar(25) not null, Цена float not null, Количество float not null, Сумма float not null, Дата nvarchar(15), constraint PK_{0} primary key clustered([ID] ASC)", Recipient));
                InsertRecordsToCouterparty(titlebox.Text, PriceValue, CountValue, SummValue, Date);

            }
            catch (Exception)
            {
                General.Connection.Close();
            }
            this.Close();

            }
            catch (Exception) { }
        }
        public void InsertRecordsToCouterparty(string sProductStr, float sPrice, float sCount, float sSumm, string sDateStr)
        {
                General.Command = new SqlCommand(String.Format("insert into {0}(Продукт, Цена, Количество, Сумма, Дата) values(@name, @price, @count, @summ, @date)", Recipient), General.Connection);
                General.Connection.Open();
                General.Command.Parameters.AddWithValue("@name", sProductStr);
                General.Command.Parameters.AddWithValue("@price", sPrice);
                General.Command.Parameters.AddWithValue("@count", sCount);
                General.Command.Parameters.AddWithValue("@summ", sSumm);
                General.Command.Parameters.AddWithValue("@date", sDateStr);
                General.Command.ExecuteNonQuery();
                General.Connection.Close();

                General.DebtManager(Convert.ToInt32(sSumm), true, Recipient);
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

        float MassValue = 0.0f;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MassValue = float.Parse(textBox3.Text.ToString().Replace(".", ","));
            }
            catch (Exception) { }
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

        private void ShopMaterialsRemove_Load(object sender, EventArgs e)
        {
            General.SetComboBoxItems(RecipientTextBox, General.ComboBoxItemsType.FolderFilesToItems, Application.StartupPath + "//CounterpartyAgentsList", "");
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
