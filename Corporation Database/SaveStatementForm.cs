using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace Corporation_Database
{
    public partial class SaveStatementForm : Form
    {
        public enum ReportType
        {
            ReportCollection,
            ExpenseReport,
            FormulaReport
        }

        public ReportType SaveT;
        public float MoneySumResults = 0;
        public SaveStatementForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            switch (SaveT)
            {
                case ReportType.ReportCollection:
                    SaveCollectionReport();
                    break;
                case ReportType.ExpenseReport:
                    SaveExpenseReport();
                    break;
            }
        }

        void SaveExpenseReport()
        {
            string DateData = DatePicker.Text;
            General.CheckForExitsDirectory(Application.StartupPath + "//Report//" + DateData);

            General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//EState.data", MoneySumResults, false);
            try
            {
                General.Command = new SqlCommand("select sum(Общий) from ExpenseWorker", General.Connection);
                General.Connection.Open();
                float ExpenseWorkerSumm = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//ExpenseWorker.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//ExpenseWorker.data", ExpenseWorkerSumm, false);
                string ExpenseWorkerData = Application.StartupPath + "//Report//" + DateData + "//ExpenseWorkerData.data";
                General.LoadSQLData("ExpenseWorker", DView);
                General.SaveData(ExpenseWorkerData, DView);
            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Сумма) from ExpenseFood", General.Connection);
                General.Connection.Open();
                float ExpenseFooodSumm = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//ExpenseFood.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//ExpenseFood.data", ExpenseFooodSumm, false);
                string ExpenseFoodData = Application.StartupPath + "//Report//" + DateData + "//ExpenseFoodData.data";
                General.LoadSQLData("ExpenseFood", DView);
                General.SaveData(ExpenseFoodData, DView);
            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Сумма) from ExpenseFuel", General.Connection);
                General.Connection.Open();
                float ExpenseFuel = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//ExpenseFuel.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//ExpenseFuel.data", ExpenseFuel, false);
                string ExpenseFuelData = Application.StartupPath + "//Report//" + DateData + "//ExpenseFuelData.data";
                General.LoadSQLData("ExpenseFuel", DView);
                General.SaveData(ExpenseFuelData, DView);
            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Сумма) from ExpenseFirm", General.Connection);
                General.Connection.Open();
                float ExpenseFirmSumm = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//ExpenseFirm.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//ExpenseFirm.data", ExpenseFirmSumm, false);
                string ExpenseFirmData = Application.StartupPath + "//Report//" + DateData + "//ExpenseFirmData.data";
                General.LoadSQLData("ExpenseFirm", DView);
                General.SaveData(ExpenseFirmData, DView);
            }
            catch (Exception) { }
        }

        void SaveCollectionReport()
        {
            string DateData = DatePicker.Text;
            General.CheckForExitsDirectory(Application.StartupPath + "//Report//" + DateData);

            #region Raws
            try
            {
                General.Command = new SqlCommand("select sum(Сумма) from RawMaterials", General.Connection);
                General.Connection.Open();
                float ImportedRawSum = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//RawsImported.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//RawsImported.data", ImportedRawSum, false);
                string ReportRawMaterialsDataFileDATA = Application.StartupPath + "//Report//" + DateData + "//RawsImportedReportData.data";
                General.LoadSQLData("RawMaterials", DView);
                General.SaveData(ReportRawMaterialsDataFileDATA, DView);
            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Сумма) from RemovedRawMaterials", General.Connection);
                General.Connection.Open();
                float RemovedRawsSummData = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//RawsRemoved.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//RawsRemoved.data", RemovedRawsSummData, false);
                string ReportRawMaterialsRemovedDataFileDATA = Application.StartupPath + "//Report//" + DateData + "//RawsRemovedReportData.data";
                General.LoadSQLData("RemovedRawMaterials", DView);
                General.SaveData(ReportRawMaterialsRemovedDataFileDATA, DView);
            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Сумма) from RawMaterialsResidue", General.Connection);
                General.Connection.Open();
                float ResidueRawsMaterials = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//RawsResidue.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//RawsResidue.data", ResidueRawsMaterials, false);
                string ReportRawMaterialsResidueDataFileDATA = Application.StartupPath + "//Report//" + DateData + "//RawsResidueReportData.data";
                General.LoadSQLData("RawMaterialsResidue", DView);
                General.SaveData(ReportRawMaterialsResidueDataFileDATA, DView);
            }
            catch (Exception) { }
            #endregion

            #region Shop
            try
            {
                General.Command = new SqlCommand("select sum(КоличествоКаробок) from ShopMaterials", General.Connection);
                General.Connection.Open();
                float CrateCount = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//BState.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//BState.data", CrateCount, false);
            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Цена) from ShopMaterials", General.Connection);
                General.Connection.Open();
                float ImportedShopMAterialsData = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//ShopMaterials.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//ShopMaterials.data", ImportedShopMAterialsData, false);
                string ImportedShopMAterialsDataFile = Application.StartupPath + "//Report//" + DateData + "//ImportedShopData.data";
                General.LoadSQLData("ShopMaterials", DView);
                General.SaveData(ImportedShopMAterialsDataFile, DView);
            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Цена) from SaledShopMaterials", General.Connection);
                General.Connection.Open();
                float SaledShopMaterials = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//ShopSaled.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//ShopSaled.data", SaledShopMaterials, false);
                string SaledShopMAterialsDataFile = Application.StartupPath + "//Report//" + DateData + "//SaledShopMaterialsData.data";
                General.LoadSQLData("SaledShopMaterials", DView);
                General.SaveData(SaledShopMAterialsDataFile, DView);

            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Цена) from ResidueShopMaterials", General.Connection);
                General.Connection.Open();
                float ResidueShopMaterialsData = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//ShopResidue.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//ShopResidue.data", ResidueShopMaterialsData, false);
                string ResidueShopMAterialsDataFile = Application.StartupPath + "//Report//" + DateData + "//ResidueShopMaterialsData.data";
                General.LoadSQLData("ResidueShopMaterials", DView);
                General.SaveData(ResidueShopMAterialsDataFile, DView);
            }
            catch (Exception) { }
            #endregion

            #region Cash
            try
            {
                General.Command = new SqlCommand("select sum(Оплаченно) from CashData", General.Connection);
                General.Connection.Open();
                float CounterPartyResults = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//CPState.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//CPState.data", CounterPartyResults, false);
            }
            catch (Exception) { }

            try
            {
                General.Command = new SqlCommand("select sum(Должен) from CashData", General.Connection);
                General.Connection.Open();
                float DebtData = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
                General.CheckForExitsFile(Application.StartupPath + "//Report//" + DateData + "//Debt.data");
                General.WriteToFileValue(Application.StartupPath + "//Report//" + DateData + "//Debt.data", DebtData, false);
            }
            catch (Exception) { }

            try
            {
                string CashData = Application.StartupPath + "//Report//" + DateData + "//CashRecordsData.data";
                General.LoadSQLData("CashData", DView);
                General.SaveData(CashData, DView);
            }
            catch (Exception) { }
            #endregion
        }
    }
}
