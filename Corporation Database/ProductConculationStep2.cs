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
using System.Threading;

namespace Corporation_Database
{
    public partial class ProductConculationStep2 : Form
    {
        private string FolderPath = Application.StartupPath + "//RawList";
        public string ProductName;
        private float Mass = 0;
        private float A = 0;
        public ProductConculationStep2()
        {
            InitializeComponent();
        }

        private void DataTextBox_Click(object sender, EventArgs e)
        {
            MassDataTextBox.Text = String.Empty;
        }

        private void ProductConculationStep2_Load(object sender, EventArgs e)
        {
            Caption.Text = "Название: " + ProductName;
            FolderPath = FolderPath + "//" + ProductName;

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            DirectoryInfo Dinfo = new DirectoryInfo(FolderPath);
            FileInfo[] info = Dinfo.GetFiles("*.");
            RawMaterialListBox.Items.Clear();
            MassProductListBox.Items.Clear();
            CostListBox.Items.Clear();
            RawDataComboBox.Items.Clear();
            if (info != null)
            {
                foreach (FileInfo finf in info)
                {
                    string[] RawMassData = File.ReadAllLines(FolderPath + "\\" + finf.Name);
                    RawMaterialListBox.Items.Add(finf.Name);
                    MassProductListBox.Items.Add(RawMassData[0]);
                    CostListBox.Items.Add(RawMassData[1]);
                }
            }

            try
            {
                General.Command = new System.Data.SqlClient.SqlCommand("select ID, Имя, Дата from RawMaterials", General.Connection);
                General.Connection.Open();
                General.Adapt = new System.Data.SqlClient.SqlDataAdapter(General.Command);
                DataSet DataS = new DataSet();
                General.Adapt.Fill(DataS);
                for (int i = 0; i < DataS.Tables[0].Rows.Count; i++)
                {
                    RawDataComboBox.Items.Add(DataS.Tables[0].Rows[i][0] + "|" + DataS.Tables[0].Rows[i][1] + "|" + DataS.Tables[0].Rows[i][2]);
                }
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
            }
            catch (Exception) { }

            Canculate();
        }

        void AddRawData(string Name)
        {
            if (Name == null)
                return;
            else
            {
                General.CheckForExitsFile(FolderPath + "\\" + Name);

                DirectoryInfo Dinfo = new DirectoryInfo(FolderPath);
                FileInfo[] info = Dinfo.GetFiles("*.");
                RawMaterialListBox.Items.Clear();
                if (info != null)
                {
                    foreach (FileInfo finf in info)
                    {
                        RawMaterialListBox.Items.Add(finf.Name);
                    }
                }

                //try
                //{
                //General.UpdateCellData("RawMaterials", "Масса", MassDataTextBox.Text, Convert.ToInt32(ID));
                //}
                //catch (Exception) { }

                //try
                //{
                //    General.DeleteFromSQLDataBase("RawMaterials", "Имя", RawDataTextBox.Text);
                //}
                //catch (Exception)
                //{
                //    //Empty
                //}
            }
        }

        void AddMassData(string Name)
        {
            StreamWriter StreamW = new StreamWriter(FolderPath + "\\" + Name, true, Encoding.UTF8);
            StreamW.WriteLine(MassDataTextBox.Text);

            StreamW.Flush();
            StreamW.Close();

            DirectoryInfo Dinfo = new DirectoryInfo(FolderPath);
            FileInfo[] info = Dinfo.GetFiles("*.");
            MassProductListBox.Items.Clear();
            if (info != null)
            {
                foreach (FileInfo finf in info)
                {
                    string[] RawMassData = File.ReadAllLines(FolderPath + "\\" + finf.Name);
                    MassProductListBox.Items.Add(RawMassData[0]);
                }
            }
        }

        void AddCostData(string Name)
        {
            StreamWriter StreamW = new StreamWriter(FolderPath + "\\" + Name, true, Encoding.UTF8);
            StreamW.WriteLine(CostTextBox.Text);

            StreamW.Flush();
            StreamW.Close();

            DirectoryInfo Dinfo = new DirectoryInfo(FolderPath);
            FileInfo[] info = Dinfo.GetFiles("*.");
            CostListBox.Items.Clear();
            if (info != null)
            {
                foreach (FileInfo finf in info)
                {
                    string[] CostMassData = File.ReadAllLines(FolderPath + "\\" + finf.Name);
                    CostListBox.Items.Add(CostMassData[1]);
                }
            }
        }

        /*
        private double getIndexofNumber(string cell)
        {
            double indexofNum = -1;
            foreach (char c in cell)
            {
                indexofNum++;
                if (Char.IsDigit(c))
                {
                    return indexofNum;
                }
            }
            return indexofNum;
        }
        */
        void Canculate()
        {
            //string Content, NumberPart = null, StringPart;
            //string[] RawMassData = null;
            //double ProductsCount;

            //ProductsCount = Convert.ToInt32(MassTextBox.Text);

            //DirectoryInfo Dinfo = new DirectoryInfo(FolderPath);
            //FileInfo[] info = Dinfo.GetFiles("*.");

            //double A = 0;
            //double B = 0;
            //double C = 0;
            //foreach (FileInfo finf in info)
            //{
            //    RawMassData = File.ReadAllLines(FolderPath + "\\" + finf.Name);
            //    Content = RawMassData[0];

            //    double a = getIndexofNumber(Content);

            //    NumberPart = Content.Substring(Convert.ToInt32(a), Content.Length - Convert.ToInt32(a));
            //    StringPart = Content.Substring(0, Convert.ToInt32(a));

            //    if (StringPart == "т")
            //    {
            //        A += Convert.ToInt32(NumberPart);
            //    }
            //    else if (StringPart == "кг")
            //    {
            //        B += Convert.ToInt32(NumberPart);
            //    }
            //    else if (StringPart == "гр")
            //    {
            //        C += Convert.ToInt32(NumberPart);
            //    }
            //}
            ///*
            //if (MassTypeComboBox.SelectedIndex == 0)
            //{
            //    NumberValue *= ProductsCount * 1000000;
            //}
            //else if(MassTypeComboBox.SelectedIndex == 1)
            //{
            //    NumberValue *= ProductsCount * 1000;
            //}
            //else if (MassTypeComboBox.SelectedIndex == 2)
            //{
            //    NumberValue *= ProductsCount;
            //}
            //*/
            //LabelSum.Text = String.Format("{0}Т {1}КГ {2}ГР", A, B, C);

            try
            {

                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(FolderPath);

                DirectoryInfo Dinfo = new DirectoryInfo(FolderPath);
                FileInfo[] info = Dinfo.GetFiles("*.");
                foreach (FileInfo finf in info)
                {
                    string[] CostData = File.ReadAllLines(FolderPath + "\\" + finf.Name);
                    A += float.Parse(CostData[1].Replace(".", ","));
                }

                SumLabel.Text = "Общая Сумма:" + A.ToString().Replace(",", ".") + " Сомони";
            }
            catch (Exception)
            {
                throw;
            }

            General.WriteToFileValue(Application.StartupPath + "//CState.data", A, false);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            RawDataComboBox.Text = String.Empty;
            RawDataComboBox.ForeColor = SystemColors.WindowText;
        }

        private void MassDataTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            MassDataTextBox.Text = String.Empty;
            MassDataTextBox.ForeColor = SystemColors.WindowText;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                string DataFromComboBox = RawDataComboBox.SelectedItem.ToString();
                string[] SplitedDataFromComboBox = DataFromComboBox.Split('|');
                //string IDValue = SplitedDataFromComboBox[0];
                string RawValue = SplitedDataFromComboBox[1];
                */
                /*
                float A = Mass;
                float B = float.Parse(MassDataTextBox.Text.Replace(".", ","));
                float C = A - B;

                General.Command = new SqlCommand("update RawMaterialsResidue set Масса=@mass where ID=@id", General.Connection);
                General.Connection.Open();
                General.Command.Parameters.AddWithValue("@id", IDValue);
                General.Command.Parameters.AddWithValue("@mass", C.ToString().Replace(",", "."));
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
                */
                AddRawData(NameTextBox.Text);
                AddMassData(NameTextBox.Text);
                AddCostData(NameTextBox.Text);
                Canculate();
            }
            catch (Exception) { }

            RawDataComboBox.Text = String.Empty;
            MassDataTextBox.Text = String.Empty;
            CostTextBox.Text = String.Empty;
        }

        private void CostTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            CostTextBox.Text = String.Empty;
            CostTextBox.ForeColor = SystemColors.WindowText;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(RawMaterialListBox.SelectedItem != null)
            {
                File.Delete(FolderPath + "\\" + RawMaterialListBox.SelectedItem.ToString());
            }

            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            DirectoryInfo Dinfo = new DirectoryInfo(FolderPath);
            FileInfo[] info = Dinfo.GetFiles("*.");
            RawMaterialListBox.Items.Clear();
            MassProductListBox.Items.Clear();
            CostListBox.Items.Clear();
            foreach (FileInfo finf in info)
            {
                string[] RawMassData = File.ReadAllLines(FolderPath + "\\" + finf.Name);
                RawMaterialListBox.Items.Add(finf.Name);
                MassProductListBox.Items.Add(RawMassData[0]);
                CostListBox.Items.Add(RawMassData[1]);
            }

            Canculate();
        }

        private void RawDataComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ID = RawDataComboBox.SelectedIndex;

                General.Command = new System.Data.SqlClient.SqlCommand("select Масса from RawMaterials", General.Connection);
                General.Connection.Open();
                General.Adapt = new System.Data.SqlClient.SqlDataAdapter(General.Command);
                DataSet DataS = new DataSet();
                General.Adapt.Fill(DataS);
                Mass = float.Parse(DataS.Tables[0].Rows[ID][0].ToString());
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataPicker D = new DataPicker();
            D.OpenT = DataPicker.ReportType.ExpenseReport;
            D.button2.Enabled = false;
            D.ShowDialog(this);
            string Date = D.MonthComboBox.SelectedItem.ToString();
            if(Date != null)
            {
                string FileName = Application.StartupPath + "//Report//" + Date + "//EState.data";
                float ESumm = General.ReadFromFileValue(FileName, 0);
                float BSumm = General.ReadFromFileValue(Application.StartupPath + "//BState.data", 0);
                A += (BSumm / ESumm);
                General.CheckForExitsDirectory(Application.StartupPath + "//Report//" + Date + "//CalcProductsData");
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + Date + "//CalcProductsData//" + ProductName + ".data");
                SumLabel.Text = "Общая Сумма:" + A.ToString().Replace(",", ".") + " Сомони";
                General.WriteToFileValue(Application.StartupPath + "//Report//" + Date + "//CalcProductsData//" + ProductName + ".data", A.ToString().Replace(".", ","), false);
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {           
        }

        private void NameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            NameTextBox.Text = String.Empty;
            NameTextBox.ForeColor = SystemColors.WindowText;
        }
    }
}
