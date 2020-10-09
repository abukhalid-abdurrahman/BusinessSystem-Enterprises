using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corporation_Database
{
    public partial class DataPicker : Form
    {
        public DataPicker()
        {
            InitializeComponent();
        }

        public enum ReportType
        {
            ReportCollection,
            ExpenseReport,
            FormulaReport
        }

        public ReportType OpenT;

        private void button1_Click(object sender, EventArgs e)
        {
            if (MonthComboBox.SelectedItem != null)
                this.Close();
            else
                General.ShowErrorBox("Введите данные!!!");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveStatementForm S = new SaveStatementForm();
            switch (OpenT)
            {
                case ReportType.ReportCollection:
                    S.SaveT = SaveStatementForm.ReportType.ReportCollection;
                    break;
                case ReportType.ExpenseReport:
                    S.SaveT = SaveStatementForm.ReportType.ExpenseReport;
                    break;
                case ReportType.FormulaReport:
                    S.SaveT = SaveStatementForm.ReportType.FormulaReport;
                    break;
            }
            S.ShowDialog();
        }

        private void MonthComboBox_Click(object sender, EventArgs e)
        {
            MonthComboBox.Items.Clear();
            try
            {
                DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "//Report");
                DirectoryInfo[] info = Dinfo.GetDirectories();
                if(info != null)
                {
                    foreach (DirectoryInfo item in info)
                    {
                        MonthComboBox.Items.Add(item.Name);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
