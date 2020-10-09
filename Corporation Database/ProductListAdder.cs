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
    public partial class ProductListAdder : Form
    {
        string t_Type = "NONE";
        string FileName = "NONE";
        public ProductListAdder()
        {
            InitializeComponent();
        }

        public ProductListAdder(string Type)
        {
            InitializeComponent();
            t_Type = Type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListB.Items.Clear();

            if (TextB.Text != null)
            {
                string PName = TextB.Text;
                StreamWriter SWriter = new StreamWriter(FileName, true, Encoding.UTF8);
                SWriter.Write(PName);
                SWriter.WriteLine();
                SWriter.Flush();
                SWriter.Close();

                if (File.Exists(FileName))
                {
                    string[] Data = File.ReadAllLines(FileName);
                    if(Data != null)
                    {
                        ListB.Items.AddRange(Data);
                    }
                }

                if(t_Type == "Shop")
                {
                    try
                    {
                        General.CreateTable(PName, String.Format("ID int IDENTITY (1, 1) not null, Имя nchar(25) not null, Масса float not null, Цена float not null, Количество float not null, КоличествоКаробок float not null, Сумма float not null, Дата nvarchar(25) not null, Поставщик nchar(30) not null, Получатель nchar(30) not null, constraint PK_{0} primary key clustered([ID] ASC)", PName));
                        ProductConculationStep1 P = new ProductConculationStep1(); P.InsertRecords(PName); P.Close();

                        bool isElementExists = false;

                        if (File.Exists(Application.StartupPath + "//Shop.Residue.Data.xml"))
                        {
                            XmlDocument xDoc = new XmlDocument();
                            xDoc.Load(Application.StartupPath + "//Shop.Residue.Data.xml");
                            XmlElement xRoot = xDoc.DocumentElement;
                            XmlNode childnode = xRoot.SelectSingleNode(String.Format("ShopResidue[Имя='{0}']", PName));
                            if (childnode != null)
                                isElementExists = true;
                        }

                        if (!isElementExists)
                            General.InsertRowToXMLData(Application.StartupPath + "//Shop.Residue.Data.xml", "ShopResidue", "Имя=" + PName, "Масса=NONE", "Количество=NONE", "КоличествоКаробок=NONE", "Цена=NONE", "Сумма=NONE");
                    }
                    catch (Exception ex)
                    {
                        General.ShowErrorBox(ex.Message);
                        General.Connection.Close();
                    }
                }


                if (t_Type == "Raw")
                {
                    try
                    {
                        General.CreateTable(PName, String.Format("ID int IDENTITY (1, 1) not null, Имя nchar(25) not null, Масса float not null, Цена float not null, Количество float not null, КоличествоКаробок float not null, Сумма float not null, Дата nvarchar(25) not null, Поставщик nchar(30) not null, Получатель nchar(30) not null, constraint PK_{0} primary key clustered([ID] ASC)", PName));

                        bool isElementExists = false;

                        if (File.Exists(Application.StartupPath + "//Raw.Residue.Data.xml"))
                        {
                            XmlDocument xDoc = new XmlDocument();
                            xDoc.Load(Application.StartupPath + "//Raw.Residue.Data.xml");
                            XmlElement xRoot = xDoc.DocumentElement;
                            XmlNode childnode = xRoot.SelectSingleNode(String.Format("RawResidue[Имя='{0}']", PName));
                            if (childnode != null)
                                isElementExists = true;
                        }

                        if(!isElementExists)
                            General.InsertRowToXMLData(Application.StartupPath + "//Raw.Residue.Data.xml", "RawResidue", "Имя=" + PName, "Масса=NONE", "Количество=NONE", "КоличествоКаробок=NONE", "Цена=NONE", "Сумма=NONE");
                    }
                    catch (Exception ex)
                    {
                        General.ShowErrorBox(ex.Message);
                        General.Connection.Close();
                    }
                }
            }

            TextB.Text = string.Empty;
        }

        private void ProductListAdder_Load(object sender, EventArgs e)
        {
            if (t_Type == "NONE")
                this.Close();
            else if (t_Type == "Raw")
            {
                this.Text = "Сырьё";
                FileName = Application.StartupPath + "//RawProductsList.data";
            }
            else if (t_Type == "Shop")
            {
                this.Text = "Цех";
                FileName = Application.StartupPath + "//ShopProductsList.data";
            }
            else
                return;

            if (File.Exists(FileName))
            {
                string[] Data = File.ReadAllLines(FileName);
                if(Data != null)
                    ListB.Items.AddRange(Data);
            }
        }

        private void ListB_DoubleClick(object sender, EventArgs e)
        {
            if (ListB.SelectedItem != null)
                this.Close();
        }
    }
}
