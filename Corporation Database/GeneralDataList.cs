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
using System.Data.SqlClient;
using System.Xml;
using System.Threading;

namespace Corporation_Database
{
    public partial class GeneralDataList : Form
    {
        string f_Path = "NONE", t_Type = "NONE";
        public GeneralDataList()
        {
            InitializeComponent();
        }

        public GeneralDataList(string FileName)
        {
            InitializeComponent();
            f_Path = FileName;
        }

        public GeneralDataList(string FileName, string generalType)
        {
            InitializeComponent();
            f_Path = FileName;
            t_Type = generalType;
        }

        private void LoadData()
        {
            string path = f_Path;
            if (path != "NONE")
            {
                if (File.Exists(path))
                {
                    string[] Data = File.ReadAllLines(path);
                    if (Data != null)
                    {
                        foreach (string it in Data)
                        {
                            try
                            {
                                DataControl.Rows.Add(it, General.SumColumnDataSQL("Масса", it), General.SumColumnDataSQL("Количество", it), General.SumColumnDataSQL("КоличествоКаробок", it), General.SumColumnDataSQL("Цена", it), General.SumColumnDataSQL("Сумма", it));
                            }
                            catch (Exception)
                            {
                                General.Connection.Close();
                            }
                        }
                    }
                }
                else
                    General.ShowErrorBox("Данные отсутствуют!");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(DataControl, findtxtbox0.Text, 1);
        }

        private void RawMatFormStep2_Load(object sender, EventArgs e)
        {
            if (DataControl.Columns.Count > 0)
            {
                DataControl.DataMember = null;
                DataControl.DataSource = null;
                DataControl.Rows.Clear();
                DataControl.Columns.Clear();
            }

            try
            {
                if (t_Type == "RawResidue")
                {
                    if (DataControl.Columns.Count > 0)
                    {
                        DataControl.DataMember = null;
                        DataControl.DataSource = null;
                        DataControl.Rows.Clear();
                        DataControl.Columns.Clear();
                    }
                    if (!File.Exists(Application.StartupPath + "//Raw.Residue.Data.xml"))
                    {
                        General.ShowErrorBox("Список продуктов сырья отсутствует!\nВозможно была потеря данных, обратитесь к администрации программы!");
                    }
                    else
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(Application.StartupPath + "//Raw.Residue.Data.xml");
                        XmlElement xRoot = xDoc.DocumentElement;
                        XmlNodeList RowsCountElement = xRoot.SelectNodes("RawResidue");
                        if (RowsCountElement != null)
                        {
                            foreach (XmlNode xNode in RowsCountElement)
                            {
                                XmlNode nameChildNode = xNode.SelectSingleNode("Имя");
                                string elemNameStr = "NONE";
                                if (nameChildNode != null)
                                {
                                    elemNameStr = nameChildNode.InnerText;
                                    XmlNode massElem = xNode.SelectSingleNode("Масса");
                                    XmlNode countElem = xNode.SelectSingleNode("Количество");
                                    XmlNode cratesElem = xNode.SelectSingleNode("КоличествоКаробок");
                                    XmlNode pricesElem = xNode.SelectSingleNode("Цена");
                                    XmlNode summElem = xNode.SelectSingleNode("Сумма");

                                    if (massElem != null && countElem != null && cratesElem != null && pricesElem != null && summElem != null)
                                    {
                                        if (massElem.InnerText == "NONE" && countElem.InnerText == "NONE" && cratesElem.InnerText == "NONE" && pricesElem.InnerText == "NONE" && summElem.InnerText == "NONE")
                                        {
                                            massElem.InnerText = General.SumColumnDataSQL("Масса", elemNameStr).ToString();
                                            countElem.InnerText = General.SumColumnDataSQL("Количество", elemNameStr).ToString();
                                            cratesElem.InnerText = General.SumColumnDataSQL("КоличествоКаробок", elemNameStr).ToString();
                                            pricesElem.InnerText = General.SumColumnDataSQL("Цена", elemNameStr).ToString();
                                            summElem.InnerText = General.SumColumnDataSQL("Сумма", elemNameStr).ToString();
                                        }
                                    }
                                }
                            }
                        }
                        StreamWriter SWriter = new StreamWriter(Application.StartupPath + "//Raw.Residue.Data.xml", false, Encoding.UTF8);
                        xDoc.Save(SWriter);
                        SWriter.Flush();
                        SWriter.Close();
                        try
                        {
                            General.LoadData(Application.StartupPath + "//Raw.Residue.Data.xml", DataControl);
                        }
                        catch (Exception) { }
                    }
                }
                else if (t_Type == "ShopResidue")
                {
                    if (DataControl.Columns.Count > 0)
                    {
                        DataControl.DataMember = null;
                        DataControl.DataSource = null;
                        DataControl.Rows.Clear();
                        DataControl.Columns.Clear();
                    }
                    if (!File.Exists(Application.StartupPath + "//Shop.Residue.Data.xml"))
                    {
                        General.ShowErrorBox("Список продуктов цеха отсутствует!\nВозможно была потеря данных, обратитесь к администрации программы!");
                    }
                    else
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(Application.StartupPath + "//Shop.Residue.Data.xml");
                        XmlElement xRoot = xDoc.DocumentElement;
                        XmlNodeList RowsCountElement = xRoot.SelectNodes("ShopResidue");
                        if (RowsCountElement != null)
                        {
                            foreach (XmlNode xNode in RowsCountElement)
                            {
                                XmlNode nameChildNode = xNode.SelectSingleNode("Имя");
                                string elemNameStr = "NONE";
                                if (nameChildNode != null)
                                {
                                    elemNameStr = nameChildNode.InnerText;
                                    XmlNode massElem = xNode.SelectSingleNode("Масса");
                                    XmlNode countElem = xNode.SelectSingleNode("Количество");
                                    XmlNode cratesElem = xNode.SelectSingleNode("КоличествоКаробок");
                                    XmlNode pricesElem = xNode.SelectSingleNode("Цена");
                                    XmlNode summElem = xNode.SelectSingleNode("Сумма");

                                    if (massElem != null && countElem != null && cratesElem != null && pricesElem != null && summElem != null)
                                    {
                                        if (massElem.InnerText == "NONE" && countElem.InnerText == "NONE" && cratesElem.InnerText == "NONE" && pricesElem.InnerText == "NONE" && summElem.InnerText == "NONE")
                                        {
                                            massElem.InnerText = General.SumColumnDataSQL("Масса", elemNameStr).ToString();
                                            countElem.InnerText = General.SumColumnDataSQL("Количество", elemNameStr).ToString();
                                            cratesElem.InnerText = General.SumColumnDataSQL("КоличествоКаробок", elemNameStr).ToString();
                                            pricesElem.InnerText = General.SumColumnDataSQL("Цена", elemNameStr).ToString();
                                            summElem.InnerText = General.SumColumnDataSQL("Сумма", elemNameStr).ToString();
                                        }
                                    }
                                }
                            }
                        }
                        StreamWriter SWriter = new StreamWriter(Application.StartupPath + "//Shop.Residue.Data.xml", false, Encoding.UTF8);
                        xDoc.Save(SWriter);
                        SWriter.Flush();
                        SWriter.Close();
                        try
                        {
                            General.LoadData(Application.StartupPath + "//Shop.Residue.Data.xml", DataControl);
                        }
                        catch (Exception) { }
                    }
                }
                else
                {
                    LoadData();
                }
            }
            catch (Exception) { }
            General.SetRowIndex(DataControl);
            General.SetGridStyle(DataControl, Color.CornflowerBlue);
            General.ChangeWidth(DataControl);
        }

        private void WorkersMoneyResults_Click(object sender, EventArgs e)
        {
            try
            {
                float Sum = 0;

                Sum = 0;

                for (int i = 0; i < DataControl.Rows.Count; i++)
                {
                    Sum += float.Parse(DataControl.Rows[i].Cells[5].Value.ToString().Replace(".", ","));
                }
                SummMoneyResults.Text = String.Format("СУММА {0} СОМОН", Sum);
                General.WriteToFileValue(Application.StartupPath + "//Report//RawsImported.data", Sum, false);
            }
            catch (Exception) { }
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(DataControl, findtxtbox0.Text, 1);
        }

        private void DataControl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (t_Type == "RawResidue")
            {
                string NameData = DataControl.Rows[e.RowIndex].Cells[0].Value.ToString();
                float Price = float.Parse(DataControl.Rows[e.RowIndex].Cells[4].Value.ToString().Replace(".", ","));
                float Summ = float.Parse(DataControl.Rows[e.RowIndex].Cells[5].Value.ToString().Replace(".", ","));
                float Mass = float.Parse(DataControl.Rows[e.RowIndex].Cells[1].Value.ToString().Replace(".", ","));
                float Count = float.Parse(DataControl.Rows[e.RowIndex].Cells[2].Value.ToString().Replace(".", ","));
                float CratesCount = float.Parse(DataControl.Rows[e.RowIndex].Cells[3].Value.ToString().Replace(".", ","));
                string IDData = String.Empty;
                string DateData = String.Empty;
                string Provider = String.Empty;
                string Recipient = String.Empty;
                RawMaterialsRemove RMR = new RawMaterialsRemove();
                RMR.titlebox.Text = NameData;
                RMR.ID = IDData;
                RMR.Date = DateData;
                RMR.Provider = Provider;
                RMR.Recipient = Recipient;
                RMR.Price = Price;
                RMR.Summ = Summ;
                RMR.Mass = Mass;
                RMR.Count = Count;
                RMR.CratesCount = CratesCount;
                RMR.ShowDialog(this);
            }
            else if(t_Type == "ShopResidue")
            {
                string NameData = DataControl.Rows[e.RowIndex].Cells[0].Value.ToString();
                float Price = float.Parse(DataControl.Rows[e.RowIndex].Cells[4].Value.ToString().Replace(".", ","));
                float Summ = float.Parse(DataControl.Rows[e.RowIndex].Cells[5].Value.ToString().Replace(".", ","));
                float Mass = float.Parse(DataControl.Rows[e.RowIndex].Cells[1].Value.ToString().Replace(".", ","));
                float Count = float.Parse(DataControl.Rows[e.RowIndex].Cells[2].Value.ToString().Replace(".", ","));
                float CratesCount = float.Parse(DataControl.Rows[e.RowIndex].Cells[3].Value.ToString().Replace(".", ","));
                ShopMaterialsRemove SMR = new ShopMaterialsRemove();
                SMR.titlebox.Text = NameData;
                SMR.ID = String.Empty;
                SMR.Date = String.Empty;
                SMR.Provider = String.Empty;
                SMR.Recipient = String.Empty;
                SMR.Price = Price;
                SMR.Summ = Summ;
                SMR.Mass = Mass;
                SMR.Count = Count;
                SMR.CratesCount = CratesCount;
                SMR.ShowDialog(this);
            }
        }

        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (t_Type == "RawResidue")
                {
                    if (!File.Exists(Application.StartupPath + "//Raw.Residue.Data.xml"))
                    {
                        General.ShowErrorBox("Список продуктов сырья отсутствует!\nВозможно была потеря данных, обратитесь к администрации программы!");
                    }
                    else
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(Application.StartupPath + "//Raw.Residue.Data.xml");
                        XmlElement xRoot = xDoc.DocumentElement;
                        XmlNodeList nodeLists = xRoot.SelectNodes("RawResidue");
                        string nameToDelete = string.Empty;
                        if (nodeLists != null)
                        {
                            foreach (XmlNode item in nodeLists)
                            {
                                XmlNode parentN = null;
                                XmlNode countN = item.SelectSingleNode("Количество");
                                if (countN != null)
                                {
                                    float N = float.Parse(countN.InnerText.Replace(".", ","));
                                    if (N == 0)
                                    {
                                        parentN = countN.ParentNode;
                                        nameToDelete = parentN.SelectSingleNode("Имя").InnerText;
                                        xRoot.RemoveChild(parentN);
                                        try
                                        {
                                            General.DeleteFromSQLDataBase("RawMaterialsResidue", "Имя", nameToDelete);
                                        }
                                        catch (Exception) { }
                                    }
                                }
                            }
                        }
                        StreamWriter SWriter = new StreamWriter(Application.StartupPath + "//Raw.Residue.Data.xml", false, Encoding.UTF8);
                        xDoc.Save(SWriter);
                        SWriter.Flush();
                        SWriter.Close();
                        if (DataControl.Columns != null && DataControl.Rows != null)
                        {
                            DataControl.DataMember = null;
                            DataControl.DataSource = null;
                            DataControl.Rows.Clear();
                            DataControl.Columns.Clear();
                        }
                        General.LoadData(Application.StartupPath + "//Raw.Residue.Data.xml", DataControl);
                    }
                }

                if (t_Type == "ShopResidue")
                {
                    if (!File.Exists(Application.StartupPath + "//Shop.Residue.Data.xml"))
                    {
                        General.ShowErrorBox("Список продуктов цеха отсутствует!\nВозможно была потеря данных, обратитесь к администрации программы!");
                    }
                    else
                    {
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(Application.StartupPath + "//Shop.Residue.Data.xml");
                        XmlElement xRoot = xDoc.DocumentElement;
                        XmlNodeList nodeLists = xRoot.SelectNodes("ShopResidue");
                        string nameToDelete = string.Empty;
                        if (nodeLists != null)
                        {
                            foreach (XmlNode item in nodeLists)
                            {
                                XmlNode parentN = null;
                                XmlNode countN = item.SelectSingleNode("Количество");
                                if (countN != null)
                                {
                                    float N = float.Parse(countN.InnerText.Replace(".", ","));
                                    if (N == 0)
                                    {
                                        parentN = countN.ParentNode;
                                        nameToDelete = parentN.SelectSingleNode("Имя").InnerText;
                                        xRoot.RemoveChild(parentN);
                                        try
                                        {
                                            General.DeleteFromSQLDataBase("RawMaterialsResidue", "Имя", nameToDelete);
                                        }
                                        catch (Exception) { }
                                    }
                                }
                            }
                        }
                        StreamWriter SWriter = new StreamWriter(Application.StartupPath + "//Shop.Residue.Data.xml", false, Encoding.UTF8);
                        xDoc.Save(SWriter);
                        SWriter.Flush();
                        SWriter.Close();
                        if (DataControl.Columns != null && DataControl.Rows != null)
                        {
                            DataControl.DataMember = null;
                            DataControl.DataSource = null;
                            DataControl.Rows.Clear();
                            DataControl.Columns.Clear();
                        }
                        General.LoadData(Application.StartupPath + "//Shop.Residue.Data.xml", DataControl);
                    }
                }
            }
            catch (Exception) { throw; }
            /*
            try
            {
                if (t_Type == "RawResidue")
                {
                    if (DataControl.Columns.Count > 0 && DataControl.Rows.Count > 0)
                    {
                        DataControl.Rows.Clear();
                        DataControl.Columns.Clear();
                    }
                    General.LoadData("Raw.Residue.Data.xml", DataControl);
                }
                else if (t_Type == "ShopResidue")
                {
                    if (DataControl.Columns.Count > 0 && DataControl.Rows.Count > 0)
                    {
                        DataControl.Rows.Clear();
                        DataControl.Columns.Clear();
                    }
                    General.LoadData("Shop.Residue.Data.xml", DataControl);
                }
            }
            catch (Exception) { throw; }
            */
        }

        private void CrateSummMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                float Sum = 0;

                Sum = 0;

                for (int i = 0; i < DataControl.Rows.Count; i++)
                {
                    Sum += float.Parse(DataControl.Rows[i].Cells[3].Value.ToString().Replace(".", ","));
                }
                CrateSummMenuItem.Text = String.Format("Кол-во Каробок {0}", Sum);
                General.WriteToFileValue(Application.StartupPath + "//Report//CratesRawImported.data", Sum, false);
            }
            catch (Exception) { }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(DataControl);
        }

        private void хToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
