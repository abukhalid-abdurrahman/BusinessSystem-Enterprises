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
    public partial class SplashScreen : Form
    {
        private Timer Time;
        private int SecTime = 3;
        string Arguments = String.Empty;

        private string FirmsP = "Firms.data";
        private string StocksP = "Stocks.data";
        private string BState = "BState.data";
        private string EState = "EState.data";
        private string CState = "CState.data";
        private string CPState = "CPState.data";
        /*
        private string WorkersSalaryDataFilePath = "Expenditure.Workers.Salary.Data.data";
        private string FoodDataFilePath = "Expenditure.Food.Data.data";
        private string FirmDataFilePath = "Expenditure.Firm.Data.data";
        private string FuelDataFilePath = "Expenditure.Fuel.Data.data";
        private string ResultsDataFilePath = "Expenditure.Results.Data.data";
        private string CashDataFilePath = "Cash.Data.data";
        private string RelDataFilePath = "Realization.Data.data";
        private string Shop0DataFilePath = "Shop.Materials.DataBase.Step0.data";
        private string Shop1DataFilePath = "Shop.Materials.DataBase.Results.data";
        private string CounterpartyDataFilePath = "Counterparty.Materials.DataBase.Results.data";
        private string RawMatDataFilePath = "Raw.Materials.DataBase.Results.data";
        private string RawMat0DataFilePath = "Raw.Materials.DataBase.Step0.data";
        private string CounterpartySPASDataFilePath = "Counterparty.SPAS.DataBase.data";
        private string CounterpartyEndOfDataFilePath = "Counterparty.EndOf.DataBase.Results.data";
        private string TransportDataFilePath = "Transport.Data.data";
        */
        public SplashScreen(string argument)
        {
            InitializeComponent();
            Arguments = argument;
        }

        void LoadFile()
        {
            General.CheckForExitsFile(Application.StartupPath + "//" + FirmsP);
            General.CheckForExitsFile(Application.StartupPath + "//" + StocksP);
            General.CheckForExitsFile(Application.StartupPath + "//" + BState);
            General.CheckForExitsFile(Application.StartupPath + "//" + EState);
            General.CheckForExitsFile(Application.StartupPath + "//" + CState);
            General.CheckForExitsFile(Application.StartupPath + "//" + CPState);

            if (General.CheckIsFileNull(BState))
                General.WriteToFileValue(BState, 0, false);

            if (General.CheckIsFileNull(EState))
                General.WriteToFileValue(EState, 0, false);

            if (General.CheckIsFileNull(CState))
                General.WriteToFileValue(CState, 0, false);

            if (General.CheckIsFileNull(CPState))
                General.WriteToFileValue(CPState, 0, false);

            General.CheckForExitsDirectory(Application.StartupPath + "//CounterpartyAgentsList//");
            General.CheckForExitsDirectory(Application.StartupPath + "//Report//");
            /*General.CheckForExitsFile(WorkersSalaryDataFilePath);
              General.CheckForExitsFile(FoodDataFilePath);
              General.CheckForExitsFile(FirmDataFilePath);
              General.CheckForExitsFile(FuelDataFilePath);
              General.CheckForExitsFile(ResultsDataFilePath);
              General.CheckForExitsFile(CashDataFilePath);
              General.CheckForExitsFile(RelDataFilePath);
              General.CheckForExitsFile(Shop0DataFilePath);
              General.CheckForExitsFile(Shop1DataFilePath);
              General.CheckForExitsFile(CounterpartyDataFilePath);
              General.CheckForExitsFile(RawMatDataFilePath);
              General.CheckForExitsFile(RawMat0DataFilePath);
              General.CheckForExitsFile(CounterpartySPASDataFilePath);
              General.CheckForExitsFile(CounterpartyEndOfDataFilePath);
              General.CheckForExitsFile(TransportDataFilePath);
            */
        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            Time = new Timer();
            Time.Interval = SecTime * 1000;
            LoadFile();
            Time.Start();
            Time.Tick += TimerTic;
        }

        void TimerTic(object sender, EventArgs e)
        {
            Time.Stop();
            Login VM = new Login(Arguments);
            VM.Show();
            this.Hide();
        }
    }
}
