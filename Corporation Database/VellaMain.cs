using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Threading;

namespace Corporation_Database
{
    public partial class VellaMain : Form
    {
        private string FirmsP = "Firms.data";
        private string StocksP = "Stocks.data";
        private string WorkersSalaryDataFilePath = "Expenditure.Workers.Salary.Data.data";
        private string FoodDataFilePath = "Expenditure.Food.Data.data";
        private string FirmDataFilePath = "Expenditure.Firm.Data.data";
        private string FuelDataFilePath = "Expenditure.Fuel.Data.data";
        private string ResultsDataFilePath = "Expenditure.Results.Data.data";
        private string CashDataFilePath = "Cash.Data.data";
        private string RelDataFilePath = "Realization.Data.data";
        private string TransportDataFilePath = "Transport.Data.data";
        private object RowID = null;
        private bool hasSaved = false;
        private float MoneySumResults = 0, WorkersSum = 0, FoodSum = 0, FuelSum = 0, FirmSum = 0;
        public string CounterpartyString = null;

        public VellaMain(string ArgumentsFilePath)
        {
            InitializeComponent();
            NotifyPrompt.BalloonTipTitle = "Добро Пожаловать!!!";
            NotifyPrompt.BalloonTipText = "Вас приветствует Sofy!!!";
            NotifyPrompt.ShowBalloonTip(5);

            LoadTablesForSettings(ArgumentsFilePath);
        }

        public VellaMain()
        {
            InitializeComponent();

            NotifyPrompt.BalloonTipTitle = "Добро Пожаловать!!!";
            NotifyPrompt.BalloonTipText = "Вас приветствует Vella!!!";
            NotifyPrompt.ShowBalloonTip(5);
        }

        private void VellaMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            CompressedArchive.DeleteTempDirectory();
        }

        private void VellaMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            General.ChangeFontFromControl(this.TabControl, this, e);

            General.FormBlock(e, this);
        }

        private void TabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if(e.KeyCode == Keys.F10)
            {
                ProductConculationStep1 PCS = new ProductConculationStep1();
                PCS.ShowDialog(this);
            }

            General.ChangeFontFromControl(this.TabControl, this, e);

            General.FormBlock(e, this);
        }

        private void SiriPageButton_Click(object sender, EventArgs e)
        {
            this.TabControl.SelectedTab = this.SirioPage;
        }

        private void CorpSirioAddButton1_Click(object sender, EventArgs e)
        {
            StatesEditor StateEdit = new StatesEditor();
            StateEdit.FilePath = FirmsP;
            StateEdit.Text = "Фирма";
            StateEdit.label1.Text = "Фирма";
            StateEdit.ShowDialog(this);
        }

        private void CorpSirioAddButton_Click(object sender, EventArgs e)
        {
            RecieverList R = new RecieverList();
            R.ShowDialog(this);
            textBox1.Text = R.SelectedClient;
        }

        private void SkladAddButton_Click(object sender, EventArgs e)
        {
            StatesEditor StateEdit = new StatesEditor();
            StateEdit.FilePath = StocksP;
            StateEdit.Text = "Склад";
            StateEdit.label1.Text = "Склад";
            StateEdit.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatesEditor StateEdit = new StatesEditor();
            StateEdit.FilePath = StocksP;
            StateEdit.Text = "Склад";
            StateEdit.label1.Text = "Склад";
            StateEdit.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StatesEditor StateEdit = new StatesEditor();
            StateEdit.FilePath = FirmsP;
            StateEdit.Text = "Фирма";
            StateEdit.label1.Text = "Фирма";
            StateEdit.ShowDialog(this);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            PoluchFirmaCommonBox.Items.Clear();
            SkladPoluchCommonBox.Items.Clear();
            FirmGetCommonBox.Items.Clear();
            SkladGetCommonBox.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox9.Items.Clear();

            if (!File.Exists(FirmsP) || !File.Exists(StocksP) || !File.Exists(FirmsP) && !File.Exists(StocksP))
            {
                General.CheckForExitsFile(FirmsP);
                General.CheckForExitsFile(StocksP);
            }


            string[] FirmsInfo = File.ReadAllLines(FirmsP, Encoding.UTF8);
            string[] StocksInfo = File.ReadAllLines(StocksP, Encoding.UTF8);

            if(FirmsInfo != null)
            {
                PoluchFirmaCommonBox.Items.AddRange(FirmsInfo);
                FirmGetCommonBox.Items.AddRange(FirmsInfo);
                comboBox2.Items.AddRange(FirmsInfo);
                comboBox4.Items.AddRange(FirmsInfo);
                comboBox5.Items.AddRange(FirmsInfo);
            }

            if(StocksInfo != null)
            {
                SkladPoluchCommonBox.Items.AddRange(StocksInfo);
                SkladGetCommonBox.Items.AddRange(StocksInfo);
                comboBox1.Items.AddRange(StocksInfo);
                comboBox3.Items.AddRange(StocksInfo);
            }

            General.SetComboBoxItems(comboBox9, General.ComboBoxItemsType.FolderFilesToItems, "CounterpartyAgentsList//", "");
            if (comboBox9.SelectedItem != null)
            {
                CounterpartyString = comboBox9.SelectedItem.ToString();
                textBox4.Text = General.GetDebt(CounterpartyString).ToString();
                textBox3.Text = string.Empty;
                textBox5.Text = string.Empty;
            }
        }

        private void VellaMain_Load(object sender, EventArgs e)
        {
            /*
            General.CheckForExitsFile(WorkersSalaryDataFilePath);
            General.CheckForExitsFile(FoodDataFilePath);
            General.CheckForExitsFile(FuelDataFilePath);
            General.CheckForExitsFile(FirmDataFilePath);
            General.CheckForExitsFile(ResultsDataFilePath);
            General.CheckForExitsFile(TransportDataFilePath);
            */

            General.SetRowIndex(RaskhodData);
            General.SetRowIndex(FoodDataPage);
            General.SetRowIndex(FuelDataEditor);
            General.SetRowIndex(FirmDataEditor);
            General.SetRowIndex(ResultsDataEditor);

            PoluchFirmaCommonBox.Items.Clear();
            SkladPoluchCommonBox.Items.Clear();
            FirmGetCommonBox.Items.Clear();
            SkladGetCommonBox.Items.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox9.Items.Clear();

            if (!File.Exists(FirmsP) || !File.Exists(StocksP) || !File.Exists(FirmsP) && !File.Exists(StocksP))
            {
                File.Create(FirmsP);
                File.Create(StocksP);
            }

            string[] FirmsInfo = File.ReadAllLines(FirmsP, Encoding.UTF8);
            string[] StocksInfo = File.ReadAllLines(StocksP, Encoding.UTF8);

            PoluchFirmaCommonBox.Items.AddRange(FirmsInfo);
            SkladPoluchCommonBox.Items.AddRange(StocksInfo);
            FirmGetCommonBox.Items.AddRange(FirmsInfo);
            SkladGetCommonBox.Items.AddRange(StocksInfo);
            comboBox1.Items.AddRange(StocksInfo);
            comboBox2.Items.AddRange(FirmsInfo);
            comboBox3.Items.AddRange(StocksInfo);
            comboBox4.Items.AddRange(FirmsInfo);
            comboBox5.Items.AddRange(FirmsInfo);
            General.SetComboBoxItems(comboBox9, General.ComboBoxItemsType.FolderFilesToItems, "CounterpartyAgentsList//", "");

            this.TabControlChild.TabPages.Remove(RaskhodResultsPage);
            this.TabControl.TabPages.Remove(tabPage1);
            this.TabControl.TabPages.Remove(tabPage2);
            this.TabControl.TabPages.Remove(UnvisibleTab);

            #region Placeholders
            General.SetTextBoxPlaceholder("Кол-во Каробок в Цеху - 0.0", ShopCratesCountTextBox);
            General.SetTextBoxPlaceholder("Общий Расход - 0.0", GeneralExpenseTextBox);
            General.SetTextBoxPlaceholder("Калькуляция - 0.0", GeneralCalculationSumTextBox);
            General.SetTextBoxPlaceholder("Ответ - 0.0", FormulaReportOutputStep1TextBox);
            General.SetTextBoxPlaceholder("К-Агент - 0.0", CounterpartyTextBox);
            General.SetWatermark(textBox1, "Имя получателя");
            #endregion

            //this.TabControl.TabPages.Remove(UnvisibleTab);
            #region Expense-Data
            try
            {
                General.LoadSQLData("ExpenseWorker", RaskhodData);
                General.LoadSQLData("ExpenseFood", FoodDataPage);
                General.LoadSQLData("ExpenseFuel", FuelDataEditor);
                General.LoadSQLData("ExpenseFirm", FirmDataEditor);
                General.LoadSQLData("ExpenseResults", ResultsDataEditor);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }

            General.ChangeWidth(RaskhodData);
            General.ChangeWidth(FoodDataPage);
            General.ChangeWidth(FuelDataEditor);
            General.ChangeWidth(FirmDataEditor);
            General.ChangeWidth(ResultsDataEditor);
            General.ChangeWidth(RealizationDataEditor);

            General.SetGridStyle(FuelDataEditor, Color.LightGreen);
            General.SetGridStyle(RaskhodData, Color.LightCoral);
            General.SetGridStyle(FoodDataPage, Color.LightBlue);
            General.SetGridStyle(FirmDataEditor, Color.LightSalmon);
            General.SetGridStyle(ResultsDataEditor, Color.MediumSlateBlue);
            General.SetGridStyle(RealizationDataEditor, Color.PowderBlue);
            #endregion
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            /*
            RawMaterials RMat = new RawMaterials();
            if (PoluchFirmaCommonBox.SelectedItem == null || FirmGetCommonBox.SelectedItem == null)
            {
                RMat.TakerFirm = "Получатель не выбран!";
                RMat.GiverFirm = "Поставщик не выбран!";
                RMat.DateTime = DatePanel.Value.ToString();
            }
            else
            {
                RMat.TakerFirm = PoluchFirmaCommonBox.SelectedItem.ToString();
                RMat.GiverFirm = FirmGetCommonBox.SelectedItem.ToString();
                RMat.DateTime = DatePanel.Value.ToString();
            }
            RMat.ShowDialog(this);
             * */

            ProductListAdder PLAdder = new ProductListAdder("Raw");
            PLAdder.ShowDialog();

            if(PLAdder.ListB.SelectedItem != null)
            {
                try
                {
                    RawMatFormStep1 R = new RawMatFormStep1();
                    if (PoluchFirmaCommonBox.SelectedItem != null || FirmGetCommonBox.SelectedItem != null || SkladPoluchCommonBox.SelectedItem != null || SkladGetCommonBox.SelectedItem != null)
                    {
                        string DateValue = DatePanel.Value.Day + "." + DatePanel.Value.Month + "." + DatePanel.Value.Year;
                        R.titlebox.Text = "Имя Продукта";
                        R.textBoxPoluch.Text = PoluchFirmaCommonBox.SelectedItem.ToString();
                        R.textBoxPost.Text = FirmGetCommonBox.SelectedItem.ToString();
                        R.DateTime = DateValue;
                        R.LoadString = PLAdder.ListB.SelectedItem.ToString();
                        R.ShowDialog(this);
                    }
                    else
                    {
                        General.ShowErrorBox("Введите данные!!!");
                    }
                }
                catch (Exception ex)
                {
                    General.ShowErrorBox(ex);
                    General.Connection.Close();
                }
            }
            PLAdder.Close();
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            this.TabControl.SelectedTab = ShopPage;
        }

        private void ShopOKButton_Click(object sender, EventArgs e)
        {
            ProductListAdder PLAdder = new ProductListAdder("Shop");
            PLAdder.ShowDialog();

            if (PLAdder.ListB.SelectedItem != null)
            {
                try
                {
                    ShopMaterialsStep1 Shop = new ShopMaterialsStep1();
                    if (comboBox1.SelectedItem != null || comboBox2.SelectedItem != null || comboBox3.SelectedItem != null || comboBox4.SelectedItem != null)
                    {
                        Shop.titlebox.Text = PLAdder.ListB.SelectedItem.ToString();
                        Shop.textBoxPost.Text = comboBox4.SelectedItem.ToString();
                        Shop.textBoxPoluch.Text = comboBox2.SelectedItem.ToString();
                        Shop.Date = dateTimePicker1.Text;
                        Shop.LoadString = PLAdder.ListB.SelectedItem.ToString();
                        Shop.ShowDialog(this);
                    }
                    else
                    {
                        General.ShowErrorBox("Введите данные!!!");
                    }
                }
                catch (Exception ex)
                {
                    General.ShowErrorBox(ex);
                    General.Connection.Close();
                }
                PLAdder.Close();
            }
        }

        private void DepotButton_Paint(object sender, PaintEventArgs e)
        {
            this.TabControl.SelectedTab = DepotPage;
        }

        private void RawPanel_Click(object sender, EventArgs e)
        {
            StorageViewer RMat = new StorageViewer();
            RMat.LoadDataType = "Raw";
            RMat.ShowDialog(this);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            StorageViewer RMat = new StorageViewer();
            RMat.LoadDataType = "Shop";
            RMat.ShowDialog(this);
        }

        private void humanButton_Click(object sender, EventArgs e)
        {
            this.TabControl.SelectedTab = humanPage;
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            HumanEditorStep1 H = new HumanEditorStep1();
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                General.ShowErrorBox("Введите данные!!!");
            }
            else
            {
                H.Counterparty = textBox1.Text;
                //H.Provider = comboBox5.SelectedItem.ToString();
                H.ShowDialog(this);
            }
        }

        private void raskhodPanel_Click(object sender, EventArgs e)
        {
            this.TabControl.SelectedTab = raskhodPage;
        }

        private void RaskhodData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(RaskhodData);
            hasSaved = false;
        }

        private void DepotButton_Click(object sender, EventArgs e)
        {
            this.TabControl.SelectedTab = DepotPage;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseRecordsConfiguration DataRecordConfig = new Corporation_Database.DatabaseRecordsConfiguration();

                DataRecordConfig.dateTimePicker.Enabled = true;
                DataRecordConfig.ShowDialog(this);

                //int RowsCountID = 0;
                //RowsCountID = General.GetRowsCount("ExpenseWorker");
                //RowsCountID += 1;
                General.Command = new SqlCommand("insert into ExpenseWorker(ФИО, Зарплата, Аванс, Остаток, Общий, Дата) values(@fio, @zarplata, @avans, @ostatok, @obshi, @date)", General.Connection);
                General.Connection.Open();
                //General.Command.Parameters.AddWithValue("@id", RowsCountID);
                General.Command.Parameters.AddWithValue("@fio", DataRecordConfig.TextBox0.Text);
                General.Command.Parameters.AddWithValue("@zarplata", DataRecordConfig.TextBox1.Text.Replace(",", "."));
                General.Command.Parameters.AddWithValue("@avans", DataRecordConfig.TextBox2.Text.Replace(",", "."));
                General.Command.Parameters.AddWithValue("@ostatok", DataRecordConfig.TextBox3.Text.Replace(",", "."));
                General.Command.Parameters.AddWithValue("@obshi", DataRecordConfig.TextBox4.Text.Replace(",", "."));
                General.Command.Parameters.AddWithValue("@date", DataRecordConfig.dateTimePicker.Text);
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
                General.LoadSQLData("ExpenseWorker", RaskhodData);
                RowID = null;
                hasSaved = true;
            }
            catch (Exception)
            {
                General.Connection.Close();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            FoodDataPage.Rows.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            General.SaveData(FoodDataFilePath, FoodDataPage);
            hasSaved = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            FuelDataEditor.Rows.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            General.SaveData(FuelDataFilePath, FuelDataEditor);
            hasSaved = true;
        }

        private void FoodDataPage_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(FoodDataPage);
            //General.Connection.Open();
            //DataTable Table = new DataTable();
            //General.LoadSQLData("ExpenseFood", FoodDataPage);
            //General.Adapt.Fill(Table);
            //General.ConnectChart("Итог", "Дата", "Сумма", Table, chart3);
            //General.Connection.Close();
            hasSaved = false;
        }

        private void FuelDataEditor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(FuelDataEditor);
            //General.Connection.Open();
            //DataTable Table = new DataTable();
            //General.LoadSQLData("ExpenseFuel", FuelDataEditor);
            //General.Adapt.Fill(Table);
            //General.ConnectChart("Итог", "Дата", "Сумма", Table, chart4);
            //General.Connection.Close();
            hasSaved = false;
        }

        private void FirmDataEditor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(FirmDataEditor);
            //General.Connection.Open();
            //DataTable Table = new DataTable();
            //General.LoadSQLData("ExpenseFirm", FirmDataEditor);
            //General.Adapt.Fill(Table);
            //General.ConnectChart("Итог", "Дата", "Сумма", Table, chart2);
            //General.Connection.Close();
            hasSaved = false;
        }

        private void ResultsDataEditor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            General.SetRowIndex(ResultsDataEditor);
            hasSaved = false;
        }

        private void RaskhodData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            hasSaved = false;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("ExpenseWorker", "ID", RowID);
                General.LoadSQLData("ExpenseWorker", RaskhodData);
            }
            RowID = null;
            General.SetRowIndex(RaskhodData);
        }

        private void WorkersMoneyResults_Click(object sender, EventArgs e)
        {
            float A = 0;
            WorkersSum = 0;
            for (int i = 0; i < RaskhodData.Rows.Count; i++)
            {
                A = float.Parse(RaskhodData.Rows[i].Cells[5].Value.ToString().Replace(".", ","));
                WorkersSum += A;
            }
            WorkersMoneyResults.Text = String.Format("СУММА {0} СОМОНИ", WorkersSum);
            General.Connection.Open();
            DataTable DataT = new DataTable();
            General.Adapt = new SqlDataAdapter("select ФИО, Общий from ExpenseWorker", General.Connection);
            General.Adapt.Fill(DataT);
            chart1.Series["Итог"].XValueMember = "ФИО";
            chart1.Series["Итог"].YValueMembers = "Общий";
            chart1.DataSource = DataT;
            chart1.DataBind();
            General.Connection.Close();
            WorkersCountLabel.Text = "Сотрудники: " + RaskhodData.Rows.Count.ToString();
            WorkersSumLabel.Text = "Сумма: " + WorkersSum.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(RaskhodData, findtxtbox0.Text, 1);
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.RaskhodData.Width, this.RaskhodData.Height);
                RaskhodData.DrawToBitmap(bm, new Rectangle(0, 0, this.RaskhodData.Width, this.RaskhodData.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(FoodDataPage, findtxtbox1.Text, 1);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument2.Print();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.FoodDataPage.Width, this.FoodDataPage.Height);
                FoodDataPage.DrawToBitmap(bm, new Rectangle(0, 0, this.RaskhodData.Width, this.RaskhodData.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseRecordsConfiguration DataRecordConfig = new Corporation_Database.DatabaseRecordsConfiguration();
                DataRecordConfig.dateTimePicker.Enabled = true;
                //DataRecordConfig.TextBox0.Text = "Имя";
                DataRecordConfig.TextBox2.Text = "Сумма";
                DataRecordConfig.TextBox3.Enabled = false;
                DataRecordConfig.TextBox4.Enabled = false;
                DataRecordConfig.TextBox1.Enabled = false;
                DataRecordConfig.TextBox3.Text = String.Empty;
                DataRecordConfig.TextBox4.Text = String.Empty;
                DataRecordConfig.TextBox1.Text = String.Empty;
                DataRecordConfig.ShowDialog(this);


                //int RowsCountID = 0;
                //RowsCountID = General.GetRowsCount("ExpenseFood");
                //RowsCountID += 1;
                General.Command = new SqlCommand("insert into ExpenseFood(Имя, Дата, Сумма) values(@name, @date, @summ)", General.Connection);
                General.Connection.Open();
                //General.Command.Parameters.AddWithValue("@id", RowsCountID);
                General.Command.Parameters.AddWithValue("@name", DataRecordConfig.TextBox0.Text);
                General.Command.Parameters.AddWithValue("@date", DataRecordConfig.dateTimePicker.Text);
                General.Command.Parameters.AddWithValue("@summ", DataRecordConfig.TextBox2.Text.Replace(",", "."));
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
                General.LoadSQLData("ExpenseFood", FoodDataPage);
                RowID = null;
                hasSaved = true;
            }
            catch (Exception)
            {
                General.Connection.Close();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("ExpenseFood", "ID", RowID);
                General.LoadSQLData("ExpenseFood", FoodDataPage);
            }
            RowID = null;
            General.SetRowIndex(FoodDataPage);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FoodDataPage.Rows.Clear();
        }

        private void FoodResultsLabel_Click(object sender, EventArgs e)
        {
            float A = 0;
            FoodSum = 0;
            for (int i = 0; i < FoodDataPage.Rows.Count; i++)
            {
                A = float.Parse(FoodDataPage.Rows[i].Cells[3].Value.ToString().Replace(".", ","));
                FoodSum += A;
            }
            FoodResultsLabel.Text = String.Format("СУММА {0} СОМОНИ", FoodSum);
            General.Connection.Open();
            DataTable DataT = new DataTable();
            General.Adapt = new SqlDataAdapter("select Дата, Сумма from ExpenseFood", General.Connection);
            General.Adapt.Fill(DataT);
            chart3.Series["Итог"].XValueMember = "Дата";
            chart3.Series["Итог"].YValueMembers = "Сумма";
            chart3.DataSource = DataT;
            chart3.DataBind();
            General.Connection.Close();
            FoodLabel.Text = "Кол-во трат в списке: " + FoodDataPage.Rows.Count.ToString();
            FoodSumLabel.Text = "Сумма: " + FoodSum.ToString();
        }

        private void FuelResultsLabel_Click(object sender, EventArgs e)
        {
            float A = 0;
            FuelSum = 0;
            for (int i = 0; i < FuelDataEditor.Rows.Count; i++)
            {
                A = float.Parse(FuelDataEditor.Rows[i].Cells[3].Value.ToString().Replace(".", ","));
                FuelSum += A;
            }
            FuelResultsLabel.Text = String.Format("СУММА {0} СОМОНИ", FuelSum);
            General.Connection.Open();
            DataTable DataT = new DataTable();
            General.Adapt = new SqlDataAdapter("select Дата, Сумма from ExpenseFuel", General.Connection);
            General.Adapt.Fill(DataT);
            chart4.Series["Итог"].XValueMember = "Дата";
            chart4.Series["Итог"].YValueMembers = "Сумма";
            chart4.DataSource = DataT;
            chart4.DataBind();
            General.Connection.Close();
            FuelLabel.Text = "Кол-во трат в списке: " + FuelDataEditor.Rows.Count.ToString();
            FuelSumLabel.Text = "Сумма: " + FuelSum.ToString();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument3.Print();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.FuelDataEditor.Width, this.FuelDataEditor.Height);
                FuelDataEditor.DrawToBitmap(bm, new Rectangle(0, 0, this.FuelDataEditor.Width, this.FuelDataEditor.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(FuelDataEditor, findtxtbox2.Text, 1);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            FuelDataEditor.Rows.Clear();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("ExpenseFuel", "ID", RowID);
                General.LoadSQLData("ExpenseFuel", FuelDataEditor);
            }
            RowID = null;
            General.SetRowIndex(FuelDataEditor);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseRecordsConfiguration DataRecordConfig = new Corporation_Database.DatabaseRecordsConfiguration();
                DataRecordConfig.dateTimePicker.Enabled = true;
                //DataRecordConfig.TextBox0.Text = "Имя";
                DataRecordConfig.TextBox1.Text = "Сумма";
                DataRecordConfig.TextBox2.Text = String.Empty;
                DataRecordConfig.TextBox4.Text = String.Empty;
                DataRecordConfig.TextBox3.Text = String.Empty;
                DataRecordConfig.TextBox2.Enabled = false;
                DataRecordConfig.TextBox3.Enabled = false;
                DataRecordConfig.TextBox4.Enabled = false;
                DataRecordConfig.ShowDialog(this);


                //int RowsCountID = 0;
                //RowsCountID = General.GetRowsCount("ExpenseFuel");
                //RowsCountID += 1;
                General.Command = new SqlCommand("insert into ExpenseFuel(Имя, Дата, Сумма) values(@name, @date, @summ)", General.Connection);
                General.Connection.Open();
                //General.Command.Parameters.AddWithValue("@id", RowsCountID);
                General.Command.Parameters.AddWithValue("@name", DataRecordConfig.TextBox0.Text);
                General.Command.Parameters.AddWithValue("@date", DataRecordConfig.dateTimePicker.Text);
                General.Command.Parameters.AddWithValue("@summ", DataRecordConfig.TextBox1.Text.Replace(",", "."));
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
                General.LoadSQLData("ExpenseFuel", FuelDataEditor);
                RowID = null;
                hasSaved = true;
            }
            catch (Exception)
            {
                General.Connection.Close();
            }
        }

        private void FirmsResultsSum_Click(object sender, EventArgs e)
        {
            float A = 0;
            FirmSum = 0;
            for (int i = 0; i < FirmDataEditor.Rows.Count; i++)
            {
                A = float.Parse(FirmDataEditor.Rows[i].Cells[4].Value.ToString().Replace(".", ","));
                FirmSum += A;
            }
            FirmsResultsSum.Text = String.Format("СУММА {0} СОМОН", FirmSum);
            General.Connection.Open();
            DataTable DataT = new DataTable();
            General.Adapt = new SqlDataAdapter("select Дата, Сумма from ExpenseFirm", General.Connection);
            General.Adapt.Fill(DataT);
            chart2.Series["Итог"].XValueMember = "Дата";
            chart2.Series["Итог"].YValueMembers = "Сумма";
            chart2.DataSource = DataT;
            chart2.DataBind();
            General.Connection.Close();
            FirmLabel.Text = "Кол-во трат в списке: " + FirmDataEditor.Rows.Count.ToString();
            FirmSumLabel.Text = "Сумма: " + FirmSum.ToString();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument4.Print();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void printDocument4_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.FirmDataEditor.Width, this.FirmDataEditor.Height);
                FirmDataEditor.DrawToBitmap(bm, new Rectangle(0, 0, this.FirmDataEditor.Width, this.FirmDataEditor.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(FirmDataEditor, findtxtbox3.Text, 1);
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            FirmDataEditor.Rows.Clear();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("ExpenseFirm", "ID", RowID);
                General.LoadSQLData("ExpenseFirm", FirmDataEditor);
            }
            RowID = null;
            General.SetRowIndex(FirmDataEditor);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseRecordsConfiguration DataRecordConfig = new Corporation_Database.DatabaseRecordsConfiguration();
                DataRecordConfig.dateTimePicker.Enabled = true;
                //DataRecordConfig.TextBox0.Text = "Имя";
                DataRecordConfig.TextBox1.Text = "Покупка";
                DataRecordConfig.TextBox2.Text = "Сумма";
                DataRecordConfig.TextBox3.Text = String.Empty;
                DataRecordConfig.TextBox4.Text = String.Empty;
                DataRecordConfig.TextBox3.Enabled = false;
                DataRecordConfig.TextBox4.Enabled = false;
                DataRecordConfig.ShowDialog(this);

                //int RowsCountID = 0;
                //RowsCountID = General.GetRowsCount("ExpenseFirm");
                //RowsCountID += 1;
                General.Command = new SqlCommand("insert into ExpenseFirm(Имя, Дата, Покупка, Сумма) values(@name, @date, @buy, @summ)", General.Connection);
                General.Connection.Open();
                //General.Command.Parameters.AddWithValue("@id", RowsCountID);
                General.Command.Parameters.AddWithValue("@name", DataRecordConfig.TextBox0.Text);
                General.Command.Parameters.AddWithValue("@date", DataRecordConfig.dateTimePicker.Text);
                General.Command.Parameters.AddWithValue("@buy", DataRecordConfig.TextBox1.Text);
                General.Command.Parameters.AddWithValue("@summ", DataRecordConfig.TextBox2.Text.Replace(",", "."));
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
                General.LoadSQLData("ExpenseFirm", FirmDataEditor);
                RowID = null;
                hasSaved = true;
            }
            catch (Exception)
            {
                General.Connection.Close();
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            General.SaveData(FirmDataFilePath, FirmDataEditor);
            hasSaved = true;
        }

        private void MoneyResults_Click(object sender, EventArgs e)
        {
            MoneySumResults = 0;
            MoneySumResults = WorkersSum + FoodSum + FuelSum + FirmSum;
            MoneyResults.Text = String.Format("СУММА ОБЩЕГО РАСХОДА {0} СОМОН", MoneySumResults);
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument5.Print();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void printDocument5_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.ResultsDataEditor.Width, this.ResultsDataEditor.Height);
                ResultsDataEditor.DrawToBitmap(bm, new Rectangle(0, 0, this.ResultsDataEditor.Width, this.ResultsDataEditor.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ResultsDataEditor, findtxtbox4.Text, 1);
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            ResultsDataEditor.Rows.Clear();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            if (RowID != null)
            {
                General.DeleteFromSQLDataBase("ExpenseResults", "ID", RowID);
                General.LoadSQLData("ExpenseResults", ResultsDataEditor);
            }
            RowID = null;
            General.SetRowIndex(ResultsDataEditor);
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            DatabaseRecordsConfiguration DataRecordConfig = new Corporation_Database.DatabaseRecordsConfiguration();
            DataRecordConfig.dateTimePicker.Enabled = true;
            DataRecordConfig.TextBox0.Text = "Количество";
            DataRecordConfig.TextBox1.Text = "Итог";
            DataRecordConfig.TextBox2.Text = "Сумма";
            DataRecordConfig.TextBox3.Text = String.Empty;
            DataRecordConfig.TextBox4.Text = String.Empty;
            DataRecordConfig.TextBox3.Enabled = false;
            DataRecordConfig.TextBox4.Enabled = false;
            DataRecordConfig.ShowDialog(this);

            //int RowsCountID = 0;
            //RowsCountID = General.GetRowsCount("ExpenseResults");
            //RowsCountID += 1;
            General.Command = new SqlCommand("insert into ExpenseResults(Дата, Количество, Итог, Сумма) values(@date, @count, @result, @summ)", General.Connection);
            General.Connection.Open();
            //General.Command.Parameters.AddWithValue("@id", RowsCountID);
            General.Command.Parameters.AddWithValue("@date", DataRecordConfig.dateTimePicker.Text);
            General.Command.Parameters.AddWithValue("@count", DataRecordConfig.TextBox0.Text.Replace(",", "."));
            General.Command.Parameters.AddWithValue("@result", DataRecordConfig.TextBox1.Text.Replace(",", "."));
            General.Command.Parameters.AddWithValue("@summ", DataRecordConfig.TextBox2.Text.Replace(",", "."));
            General.Command.ExecuteNonQuery();
            General.Connection.Close();
            General.LoadSQLData("ExpenseResults", ResultsDataEditor);
            RowID = null;
            hasSaved = true;
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            General.SaveData(ResultsDataFilePath, ResultsDataEditor);
            hasSaved = true;
        }

        private void findtxtbox0_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(RaskhodData, findtxtbox0.Text, 1);
        }

        private void findtxtbox1_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(FoodDataPage, findtxtbox1.Text, 1);
        }

        private void findtxtbox2_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(FuelDataEditor, findtxtbox2.Text, 1);
        }

        private void findtxtbox3_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(FirmDataEditor, findtxtbox3.Text, 1);
        }

        private void findtxtbox4_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(ResultsDataEditor, findtxtbox4.Text, 1);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.TabControl.SelectedTab = tabPage5;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BasarAndProdovecForm B = new BasarAndProdovecForm();
            B.ShowDialog(this);
        }

        private void RaskhodData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            RaskhodData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void FoodDataPage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            FoodDataPage.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void FuelDataEditor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            FuelDataEditor.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void FirmDataEditor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            FirmDataEditor.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void ResultsDataEditor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.ShowDialog(this);
            ResultsDataEditor.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = CDialog.Color;
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument7.Print();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void printDocument7_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(this.RealizationDataEditor.Width, this.RealizationDataEditor.Height);
                RealizationDataEditor.DrawToBitmap(bm, new Rectangle(0, 0, this.RealizationDataEditor.Width, this.RealizationDataEditor.Height));
                e.Graphics.DrawImage(bm, 0, 0);
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }


        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            RealizationDataEditor.Rows.Clear();
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            RealizationDataEditor.Rows.RemoveAt(General.GetRowIndex(RealizationDataEditor));
            General.SetRowIndex(RealizationDataEditor);
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            RealizationDataEditor.Rows.Add();
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            General.SaveData(RelDataFilePath, RealizationDataEditor);
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            General.SearchFromDataGridViewControl(RealizationDataEditor, toolStripTextBox2.Text, 0);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            CashFormViewer CFV = new CashFormViewer();
            CFV.ShowDialog(this);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CashFormViewer CFV = new CashFormViewer();
            string Month = dateTimePicker2.Value.Month.ToString();
            string Day = dateTimePicker2.Value.Day.ToString();
            string Year = dateTimePicker2.Value.Year.ToString();
            string DateCash = Day + "." + Month + "." + Year;
            string Combo1 = comboBox9.SelectedItem.ToString();
            if (textBox3.Text == "" || textBox3.Text == " " || textBox3.Text.Length == 0)
                textBox3.Text = "0.0";
            float SumIn = float.Parse(textBox3.Text.Replace(".", ","));

            if (textBox4.Text == "" || textBox4.Text == " " || textBox4.Text.Length == 0)
                textBox4.Text = "0.0";
            float GeneralSum = float.Parse(textBox4.Text.Replace(".", ","));

            if (textBox5.Text == "" || textBox5.Text == " " || textBox5.Text.Length == 0)
                textBox5.Text = "0.0";
            float SumToPay = float.Parse(textBox5.Text.Replace(".", ","));

            if (textBox7.Text == "" || textBox7.Text == " " || textBox7.Text.Length == 0)
                textBox7.Text = "0.0";
            float Bonus = float.Parse(textBox6.Text.Replace(".", ","));

            if (SumIn == float.NaN)
                SumIn = 0.0f;

            if (SumToPay == float.NaN)
                SumToPay = 0.0f;

            if (Bonus == float.NaN)
                Bonus = 0.0f;

            CFV.InsertRecords(Combo1, GeneralSum.ToString().Replace(",", "."), SumIn.ToString().Replace(",", "."), SumToPay.ToString().Replace(",", "."), Bonus.ToString().Replace(",", "."), DateCash);
            CFV.ShowDialog(this);

            General.DebtManager(SumIn, false, CounterpartyString);
        }

        private void BlockB()
        {
            Block block = new Block();
            block.Password = "2018";
            block.ShowDialog(this);
        }

        private void BLOCK_Click(object sender, EventArgs e)
        {
            BlockB();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            BlockB();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            BlockB();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            BlockB();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            BlockB();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            BlockB();
        }

        private void solaryMaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(RaskhodData, 2, ListSortDirection.Descending);
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(FoodDataPage);
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            General.SortData(FoodDataPage, 2, ListSortDirection.Descending);
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            General.SortData(FoodDataPage, 2, ListSortDirection.Ascending);
        }

        private void FoodDataPage_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = FoodDataPage.Rows[e.RowIndex].Cells[0].Value;
        }

        private void toolStripMenuItem31_Click_1(object sender, EventArgs e)
        {
            General.ExportToExcel(FuelDataEditor);
        }

        private void toolStripMenuItem29_CheckStateChanged(object sender, EventArgs e)
        {
            General.SortData(FuelDataEditor, 2, ListSortDirection.Descending);
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            General.SortData(FuelDataEditor, 2, ListSortDirection.Ascending);
        }

        private void FuelDataEditor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = FuelDataEditor.Rows[e.RowIndex].Cells[0].Value;
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            General.SortData(FirmDataEditor, 2, ListSortDirection.Descending);
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            General.SortData(FirmDataEditor, 2, ListSortDirection.Ascending);
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(FirmDataEditor);
        }

        private void FirmDataEditor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = FirmDataEditor.Rows[e.RowIndex].Cells[0].Value;
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(ResultsDataEditor);
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            General.SortData(ResultsDataEditor, 1, ListSortDirection.Descending);
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            General.SortData(ResultsDataEditor, 1, ListSortDirection.Ascending);
        }

        private void ResultsDataEditor_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = ResultsDataEditor.Rows[e.RowIndex].Cells[0].Value;
        }

        private void genGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("ExpenseWorker", RaskhodData);
            General.Adapt.Fill(Table);
            General.GenGraph("ФИО", "Общий", Table);
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("ExpenseFood", FoodDataPage);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Сумма", Table);
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("ExpenseFuel", FuelDataEditor);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Сумма", Table);
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("ExpenseFirm", FirmDataEditor);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Сумма", Table);
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            DataTable Table = new DataTable();
            General.LoadSQLData("ExpenseResults", ResultsDataEditor);
            General.Adapt.Fill(Table);
            General.GenGraph("Дата", "Сумма", Table);
        }

        private void panel9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void RaskhodData_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //General.Connection.Open();
            //DataTable Table = new DataTable();
            //General.LoadSQLData("ExpenseWorker", RaskhodData);
            //General.Adapt.Fill(Table);
            //General.ConnectChart("Итог", "ФИО", "Общий", Table, chart1);
            //General.Connection.Close();
        }

        private void FoodDataPage_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //General.Connection.Open();
            //DataTable Table = new DataTable();
            //General.LoadSQLData("ExpenseFood", FoodDataPage);
            //General.Adapt.Fill(Table);
            //General.ConnectChart("Итог", "Дата", "Сумма", Table, chart3);
            //General.Connection.Close();
        }

        private void FuelDataEditor_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //General.Connection.Open();
            //DataTable Table = new DataTable();
            //General.LoadSQLData("ExpenseFuel", FuelDataEditor);
            //General.Adapt.Fill(Table);
            //General.ConnectChart("Итог", "Дата", "Сумма", Table, chart4);
            //General.Connection.Close();
        }

        private void FirmDataEditor_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //General.Connection.Open();
            //DataTable Table = new DataTable();
            //General.LoadSQLData("ExpenseFirm", FirmDataEditor);
            //General.Adapt.Fill(Table);
            //General.ConnectChart("Итог", "Дата", "Сумма", Table, chart2);
            //General.Connection.Close();
        }

        private void калонкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void точкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        private void областьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
        }

        private void линииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void областӣToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart3.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
        }

        private void калонкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chart3.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void точкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chart3.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        private void линииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chart3.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void калонкиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chart4.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void точкиToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chart4.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        private void областьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            chart4.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
        }

        private void линииToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chart4.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void калонкиToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chart2.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void точкиToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chart2.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
        }

        private void областьToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chart4.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
        }

        private void линииToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chart2.Series["Итог"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            CounterpartyString = comboBox9.SelectedItem.ToString();
            textBox4.Text = General.GetDebt(CounterpartyString).ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text.Length >= 10)
                {
                    General.ShowErrorBox("Черезмерно длинное значение суммы!!! Сократите значение!!!");
                    return;
                }
                else
                {
                    float DebtSum = float.Parse(textBox4.Text.Replace(".", ","));
                    float InputedSum = float.Parse(textBox3.Text.Replace(".", ","));
                    float Ostatok = 0.0f;

                    Ostatok = DebtSum - InputedSum;

                    textBox5.Text = Ostatok.ToString().Replace(",", ".");
                }
            }
            catch (Exception){}
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            General.SortData(FuelDataEditor, 2, ListSortDirection.Descending);
        }

        private void RRMFBtn_Click(object sender, EventArgs e)
        {
            RemovedRawMaterialsForm RRM = new RemovedRawMaterialsForm();
            RRM.ShowDialog(this);
        }

        private void ReportCollectionEvent(string Date)
        {
            try
            {
                ImportedRawsChart.Series["Итог"].Points.Clear();
                RemovedRawsChart.Series["Итог"].Points.Clear();
                ResidueRawsChart.Series["Итог"].Points.Clear();
                ImportedShopMaterialsChart.Series["Итог"].Points.Clear();
                SaledShopMaterialsChart.Series["Итог"].Points.Clear();
                ResidueShopMaterialsChart.Series["Итог"].Points.Clear();
                DebtChart.Series["Итог"].Points.Clear();
                GeneralProfitChart.Series["Итог"].Points.Clear();

                #region Raws
                try
                {
                    float ImportedRawsSummData = General.ReadFromFileValue("Report//" + Date + "//RawsImported.data", 0);
                    ImportedRawsSummLabel.Text = "Сумма: " + ImportedRawsSummData;
                    General.LoadData("Report//" + Date + "//RawsImportedReportData.data", LoadedRawImportedData);
                    for (int i = 0; i < LoadedRawImportedData.RowCount; i++)
                    {
                        ImportedRawsChart.Series["Итог"].Points.AddXY(LoadedRawImportedData.Rows[i].Cells[7].Value.ToString(), LoadedRawImportedData.Rows[i].Cells[6].Value.ToString());
                    }
                }
                catch (Exception) { }

                try
                {
                    float RemovedRawsSummData = General.ReadFromFileValue("Report//" + Date + "//RawsRemoved.data", 0);
                    RemovedRawsLabel.Text = "Сумма: " + RemovedRawsSummData;
                    General.LoadData("Report//" + Date + "//RawsRemovedReportData.data", LoadedRawRemovedData);
                    for (int i = 0; i < LoadedRawRemovedData.RowCount; i++)
                    {
                        RemovedRawsChart.Series["Итог"].Points.AddXY(LoadedRawRemovedData.Rows[i].Cells[7].Value.ToString(), LoadedRawRemovedData.Rows[i].Cells[6].Value.ToString());
                    }
                }
                catch (Exception) { }

                try
                {
                    float ResidueRawsMaterials = General.ReadFromFileValue("Report//" + Date + "//RawsResidue.data", 0);
                    ResidueRawsSummLabel.Text = "Сумма: " + ResidueRawsMaterials;
                    General.LoadData("Report//" + Date + "//RawsResidueReportData.data", LoadRawResidueData);
                    for (int i = 0; i < LoadRawResidueData.RowCount; i++)
                    {
                        ResidueRawsChart.Series["Итог"].Points.AddXY(LoadRawResidueData.Rows[i].Cells[7].Value.ToString(), LoadRawResidueData.Rows[i].Cells[6].Value.ToString());
                    }
                }
                catch (Exception) { }
                #endregion

                #region Shop
                try
                {
                    float ImportedShopMAterialsData = General.ReadFromFileValue("Report//" + Date + "//ShopMaterials.data", 0);
                    ImportedShopMaterialsLabel.Text = "Сумма: " + ImportedShopMAterialsData;
                    General.LoadData("Report//" + Date + "//ImportedShopData.data", LoadedShopData);
                    for (int i = 0; i < LoadedShopData.RowCount; i++)
                    {
                        ImportedShopMaterialsChart.Series["Итог"].Points.AddXY(LoadedShopData.Rows[i].Cells[1].Value.ToString(), LoadedShopData.Rows[i].Cells[3].Value.ToString());
                    }
                }
                catch (Exception) { }

                try
                {
                    float SaledShopMaterials = General.ReadFromFileValue("Report//" + Date + "//ShopSaled.data", 0);
                    SaledShopMaterialsLabel.Text = "Сумма: " + SaledShopMaterials;
                    General.LoadData("Report//" + Date + "//SaledShopMaterialsData.data", LoadedShopSaledData);
                    for (int i = 0; i < LoadedShopSaledData.RowCount; i++)
                    {
                        SaledShopMaterialsChart.Series["Итог"].Points.AddXY(LoadedShopSaledData.Rows[i].Cells[1].Value.ToString(), LoadedShopSaledData.Rows[i].Cells[3].Value.ToString());
                    }
                }
                catch (Exception) { }

                try
                {
                    float ResidueShopMaterialsData = General.ReadFromFileValue("Report//" + Date + "//ShopResidue.data", 0);
                    ResidueShopMaterialsLabel.Text = "Сумма: " + ResidueShopMaterialsData;
                    General.LoadData("Report//" + Date + "//ResidueShopMaterialsData.data", LoadedResidueShopData);
                    for (int i = 0; i < LoadedResidueShopData.RowCount; i++)
                    {
                        ResidueShopMaterialsChart.Series["Итог"].Points.AddXY(LoadedResidueShopData.Rows[i].Cells[1].Value.ToString(), LoadedResidueShopData.Rows[i].Cells[3].Value.ToString());
                    }
                }
                catch (Exception) { }
                #endregion

                #region Counterparty
                int CounterPartyCount = 0;
                try
                {
                    DirectoryInfo Dinfo = new DirectoryInfo("CounterpartyAgentsList");
                    FileInfo[] info = Dinfo.GetFiles("*.");
                    CounterPartyCount = info.Length;
                }
                catch (Exception) { }
                CounterpartyCount.Text = "Кол-во: " + CounterPartyCount;
                #endregion

                #region Expense
                try
                {
                    float ExpenseResults = General.ReadFromFileValue("Report//" + Date + "//EState.data", 0);
                    label26.Text = "Сумма:" + ExpenseResults;
                }
                catch (Exception) { }
                #endregion

                #region Cash
                try
                {
                    General.LoadData("Report//" + Date + "//CashRecordsData.data", LoadedCashData);
                }
                catch (Exception) { }

                try
                {
                    for (int i = 0; i < LoadedCashData.RowCount; i++)
                    {
                        GeneralProfitChart.Series["Итог"].Points.AddXY(LoadedCashData.Rows[i].Cells[5].Value.ToString(), LoadedCashData.Rows[i].Cells[3].Value.ToString());
                        DebtChart.Series["Итог"].Points.AddXY(LoadedCashData.Rows[i].Cells[5].Value.ToString(), LoadedCashData.Rows[i].Cells[4].Value.ToString());
                    }
                }
                catch (Exception) { }

                try
                {
                    float CounterPartyResults = General.ReadFromFileValue("Report//" + Date + "//CPState.data", 0);
                    GeneralProfitLabel.Text = "Сумма: " + CounterPartyResults;
                }
                catch (Exception) { }

                try
                {
                    float DebtData = General.ReadFromFileValue("Report//" + Date + "//Debt.data", 0);
                    DebtSumLabel.Text = "Сумма: " + DebtData;
                }
                catch (Exception) { }

                #endregion
            }
            catch (Exception) {}
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab == tabPage3)
            {
                DataPicker DPicker = new DataPicker();
                DPicker.ShowDialog(this);
                if(DPicker.MonthComboBox.SelectedItem != null)
                {
                    ReportCollectionEvent(DPicker.MonthComboBox.SelectedItem.ToString());
                }
            }
        }

        private void TabControlChild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControlChild.SelectedTab == tabGraphPage)
            {
                MoneySumResults = 0;
                MoneySumResults = WorkersSum + FoodSum + FuelSum + FirmSum;
                General.WriteToFileValue("EState.data", MoneySumResults, false);
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            //ResidueRawMaterials RRM = new ResidueRawMaterials();
            //RRM.ShowDialog(this);
            GeneralDataList GDList = new GeneralDataList(Application.StartupPath + "//RawProductsList.data", "RawResidue");
            GDList.ShowDialog(this);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            /*
            ResidueShopMaterials RSM = new ResidueShopMaterials();
            RSM.ShowDialog(this);
            */
            GeneralDataList GDList = new GeneralDataList(Application.StartupPath + "//ShopProductsList.data", "ShopResidue");
            GDList.ShowDialog(this);
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            SaledShopMaterials SSM = new SaledShopMaterials();
            SSM.ShowDialog(this);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            /*
            RawMatFormStep2 R = new RawMatFormStep2();
            R.ShowDialog(this);
            */
            ShopMaterialsNamesList SMNL = new ShopMaterialsNamesList(Application.StartupPath + "//RawProductsList.data", "Imported");
            SMNL.ShowDialog(this);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            /*
            ShopMaterialsStep2 SM = new ShopMaterialsStep2();
            SM.ShowDialog(this);
            */
            ShopMaterialsNamesList SMNL = new ShopMaterialsNamesList(Application.StartupPath + "//ShopProductsList.data", "Imported");
            SMNL.ShowDialog(this);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoneySumResults = 0;
            MoneySumResults = WorkersSum + FoodSum + FuelSum + FirmSum;
            SaveStatementForm S = new SaveStatementForm();
            S.SaveT = SaveStatementForm.ReportType.ExpenseReport;
            S.MoneySumResults = MoneySumResults;
            S.ShowDialog(this);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            DataPicker D = new DataPicker();
            D.button2.Enabled = false;
            D.ShowDialog(this);
            string DateD = D.MonthComboBox.Text;
            if(DateD != null)
            {
                float CrateCount = General.ReadFromFileValue("Report//" + DateD + "//BState", 0);
                float ExpenseResults = General.ReadFromFileValue("Report//" + DateD + "//EState.data", 0);
                float CanculationResults = General.ReadFromFileValue("CState.data", 0);
                float CounterPartyResults = General.ReadFromFileValue("Report//" + DateD + "//CPState.data", 0);




                float A1 = (CrateCount / ExpenseResults);
                float A2 = (CanculationResults + A1);
                float B = (CrateCount * A2);
                float C = (CounterPartyResults - B);

                label21.Text = "Сумма: " + CounterPartyResults;
                label19.Text = "Сумма: " + CanculationResults;
                label17.Text = "Сумма: " + ExpenseResults;
                label16.Text = "Каробки: " + CrateCount;
                label25.Text = "Результат: " + C;
            }
            */
        }

        public void ReadExpensesData(string Path)
        {
            chart1.Series["Итог"].Points.Clear();
            chart3.Series["Итог"].Points.Clear();
            chart4.Series["Итог"].Points.Clear();
            chart2.Series["Итог"].Points.Clear();

            try
            {
                #region Workers
                try
                {
                    float WorkersSumm = General.ReadFromFileValue("Report//" + Path + "//ExpenseWorker.data", 0);
                    WorkersSumLabel.Text = "Сумма: " + WorkersSumm;
                    General.LoadData(Application.StartupPath + "//Report//" + Path + "//ExpenseWorkerData.data", LoadedWorkersData);
                    for (int i = 0; i < LoadedWorkersData.RowCount; i++)
                    {
                        chart1.Series["Итог"].Points.AddXY(LoadedWorkersData.Rows[i].Cells[1].Value.ToString(), LoadedWorkersData.Rows[i].Cells[5].Value.ToString());
                    }
                }
                catch (Exception) { }
                #endregion

                #region Food
                try
                {
                    float FoodSumm = General.ReadFromFileValue("Report//" + Path + "//ExpenseFood.data", 0);
                    FoodSumLabel.Text = "Сумма: " + FoodSumm;
                    General.LoadData(Application.StartupPath + "//Report//" + Path + "//ExpenseFoodData.data", LoadedFoodData);
                    for (int i = 0; i < LoadedFoodData.RowCount; i++)
                    {
                        chart3.Series["Итог"].Points.AddXY(LoadedFoodData.Rows[i].Cells[1].Value.ToString(), LoadedFoodData.Rows[i].Cells[6].Value.ToString());
                    }
                }
                catch (Exception) { }
                #endregion

                #region Fuel
                try
                {
                    float FuelSumm = General.ReadFromFileValue("Report//" + Path + "//ExpenseFuel.data", 0);
                    FuelSumLabel.Text = "Сумма: " + FuelSumm;
                    General.LoadData(Application.StartupPath + "//Report//" + Path + "//ExpenseFuelData.data", LoadedFuelData);
                    for (int i = 0; i < LoadedFuelData.RowCount; i++)
                    {
                        chart4.Series["Итог"].Points.AddXY(LoadedFuelData.Rows[i].Cells[1].Value.ToString(), LoadedFuelData.Rows[i].Cells[5].Value.ToString());
                    }
                }
                catch (Exception) { }
                #endregion

                #region Firm
                try
                {
                    float FirmSumm = General.ReadFromFileValue("Report//" + Path + "//ExpenseFirm.data", 0);
                    FirmSumLabel.Text = "Сумма: " + FirmSumm;
                    General.LoadData(Application.StartupPath + "//Report//" + Path + "//ExpenseFirmData.data", LoadedFirmExpenseData);
                    for (int i = 0; i < LoadedFirmExpenseData.RowCount; i++)
                    {
                        chart2.Series["Итог"].Points.AddXY(LoadedFirmExpenseData.Rows[i].Cells[1].Value.ToString(), LoadedFirmExpenseData.Rows[i].Cells[6].Value.ToString());
                    }
                }
                catch (Exception) { }
                #endregion
            }
            catch (Exception) { }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataPicker D = new DataPicker();
            D.OpenT = DataPicker.ReportType.ExpenseReport;
            D.ShowDialog(this);
            ReadExpensesData(D.MonthComboBox.SelectedItem.ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text.Length >= 10)
                {
                    General.ShowErrorBox("Черезмерно длинное значение суммы!!! Сократите значение!!!");
                    return;
                }
                else
                {
                    float DebtSum = float.Parse(textBox4.Text.Replace(".", ","));
                    float InputedSumm = float.Parse(textBox6.Text.Replace(".", ","));
                    double Ostatok = 0.0f;

                    Ostatok = (DebtSum * InputedSumm) / 100;

                    textBox7.Text = Ostatok.ToString().Replace(",", ".");

                    float A1 = float.Parse(textBox5.Text.Replace(".", ","));
                    float A2 = A1 - (float)Ostatok;
                    textBox5.Text = A2.ToString().Replace(",", ".");
                }
            }
            catch (Exception) { }
        }

        private void ShopCratesCountTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            General.ClearPlaceHolder(ShopCratesCountTextBox);
        }

        private void GeneralExpenseTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            General.ClearPlaceHolder(GeneralExpenseTextBox);
        }

        private void GeneralCalculationSumTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            General.ClearPlaceHolder(GeneralCalculationSumTextBox);
        }

        private void FormulaReportOutputStep1TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            General.ClearPlaceHolder(FormulaReportOutputStep1TextBox);
        }

        private void CounterpartyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            General.ClearPlaceHolder(CounterpartyTextBox);
        }

        private void FormulaReportResultsTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            General.ClearPlaceHolder(FormulaReportResultsTextBox);
        }

        private void CalculateFormulaReport(string DateD)
        {
            if (DateD != null)
            {
                try
                {
                    string[] ShopNamesData = File.ReadAllLines(Application.StartupPath + "//ShopProductsList.data");
                    float SCalcResults = 0;
                    
                    float CrateCount = 0;
                    float ExpenseResults = General.ReadFromFileValue(Application.StartupPath + "//Report//" + DateD + "//EState.data", 0);
                    float CanculationResults = 0;
                    float CounterPartyResults = General.ReadFromFileValue(Application.StartupPath + "//Report//" + DateD + "//CPState.data", 0);
                    foreach (string it in ShopNamesData)
                    {
                        try
                        {
                            General.Command = new SqlCommand("select sum(КоличествоКаробок) from " + it, General.Connection);
                            General.Connection.Open();
                            float SCrateCount = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                            General.Connection.Close();
                            CrateCount += SCrateCount;

                            float SCalcSumm = General.ReadFromFileValue(Application.StartupPath + "//Report//" + DateD + "//CalcProductsData//" + it + ".data", 0);
                            CanculationResults += SCalcSumm;
                            SCalcResults += (SCrateCount * SCalcSumm);
                        }
                        catch (Exception)
                        {
                            General.Connection.Close();
                        }
                    }
                    /*
                    float CrateCount = General.ReadFromFileValue("Report//" + DateD + "//BState.data", 0);
                    float ExpenseResults = General.ReadFromFileValue("Report//" + DateD + "//EState.data", 0);
                    float CanculationResults = General.ReadFromFileValue("CState.data", 0);
                    float CounterPartyResults = General.ReadFromFileValue("Report//" + DateD + "//CPState.data", 0);

                    float A1 = (CrateCount / ExpenseResults);
                    float A2 = (CanculationResults + A1);
                    float B = (CrateCount * A2);
                    */
                    float C = (SCalcResults - CounterPartyResults);
                    
                    General.SetTextBoxPlaceholder("Кол-во Каробок в Цеху - " + CounterPartyResults.ToString(), ShopCratesCountTextBox);
                    General.SetTextBoxPlaceholder("Общий Расход - " + ExpenseResults, GeneralExpenseTextBox);
                    General.SetTextBoxPlaceholder("Калькуляция - " + CanculationResults, GeneralCalculationSumTextBox);
                    General.SetTextBoxPlaceholder("Ответ - " + SCalcResults, FormulaReportOutputStep1TextBox);
                    General.SetTextBoxPlaceholder("К-Агент - " + CounterPartyResults, CounterpartyTextBox);
                    if(C > 0)
                        FormulaReportResultsTextBox.Text = "Результаты отчета - " + C;
                    else if(C < 0)
                        FormulaReportResultsTextBox.Text = "Результаты отчета - (" + C + ")";

                    string str0 = ShopCratesCountTextBox.Text;
                    string str1 = GeneralExpenseTextBox.Text;
                    string str2 = GeneralCalculationSumTextBox.Text;
                    string str3 = FormulaReportOutputStep1TextBox.Text;
                    string str4 = CounterpartyTextBox.Text;
                    string str5 = FormulaReportResultsTextBox.Text;
                    General.WriteToFileValue(Application.StartupPath + "//Report//" + DateD + "//FormulaReportResults.data", str0, true);
                    General.WriteToFileValue(Application.StartupPath + "//Report//" + DateD + "//FormulaReportResults.data", str1, true);
                    General.WriteToFileValue(Application.StartupPath + "//Report//" + DateD + "//FormulaReportResults.data", str2, true);
                    General.WriteToFileValue(Application.StartupPath + "//Report//" + DateD + "//FormulaReportResults.data", str3, true);
                    General.WriteToFileValue(Application.StartupPath + "//Report//" + DateD + "//FormulaReportResults.data", str4, true);
                    General.WriteToFileValue(Application.StartupPath + "//Report//" + DateD + "//FormulaReportResults.data", str5, true);

                }
                catch (Exception ex) { General.ShowErrorBox(ex); }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            DataPicker Dt = new DataPicker();
            Dt.button2.Enabled = false;
            Dt.ShowDialog(this);
            string content = Dt.MonthComboBox.SelectedItem.ToString();
            if (Directory.Exists(Application.StartupPath + "//Report//" + content))
            {
                CalculateFormulaReport(content);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            DataPicker Dt = new DataPicker();
            Dt.button2.Enabled = false;
            Dt.ShowDialog(this);
            string content = Dt.MonthComboBox.SelectedItem.ToString();
            if (Directory.Exists(Application.StartupPath + "//Report//" + content + "//"))
            {
                try
                {
                    string[] StrData = File.ReadAllLines(Application.StartupPath + "//Report//" + content + "//FormulaReportResults.data");
                    General.SetTextBoxPlaceholder(StrData[0], ShopCratesCountTextBox);
                    General.SetTextBoxPlaceholder(StrData[1], GeneralExpenseTextBox);
                    General.SetTextBoxPlaceholder(StrData[2], GeneralCalculationSumTextBox);
                    General.SetTextBoxPlaceholder(StrData[3], FormulaReportOutputStep1TextBox);
                    General.SetTextBoxPlaceholder(StrData[4], CounterpartyTextBox);
                    FormulaReportResultsTextBox.Text = StrData[5];
                }
                catch (Exception) { }
            }
        }

        private void RefreshButton_MouseHover(object sender, EventArgs e)
        {
            if (this.Cursor == Cursors.Arrow)
                Prompt.Show("При добавлении новых данных,\nданная программа не может импортировать их в базу данных автоматически,\nпо этому их нужно импортировать в ручную.", RefreshButton);
            else
                Prompt.Hide(RefreshButton);
        }

        private void openToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfg.Filter = "BiSyTable (*.bisytable)|*.bisytable";
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                General.SaveData(sfg.FileName, DataTableView);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(DataTableView);
        }

        bool NormalMode = true;
        string TableNameThatWasLoadedFromList = string.Empty;

        private void button27_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Filter = "BiSyTable (*.bisytable)|*.bisytable";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                General.LoadData(ofd.FileName, DataTableView);
                NormalMode = false;
            }
        } 

        private void LoadTablesForSettings(string FilePath)
        {
            if (FilePath.Length > 0)
            {
                if(FilePath != "NONE")
                {
                    if(File.Exists(FilePath))
                    {
                        string Extension = Path.GetExtension(FilePath).ToLower();
                        this.TabControl.SelectedTab = tabPage4;
                        if (Extension == ".bisytable")
                        {
                            General.LoadData(FilePath, DataTableView);
                            NormalMode = false;
                        }
                        if (Extension == ".bisyarchive")
                        {
                            try
                            {
                                CompressedArchive.DeleteTempDirectory();
                                CompressedArchive.CreateTempDirectory();
                                CompressedArchive.LoadArchiveData();

                                ParentTables.Items.Clear();
                                ChildTables.Items.Clear();
                                if (DataTableView.Columns.Count > 0 && DataTableView.Rows.Count > 0)
                                {
                                    DataTableView.DataMember = null;
                                    DataTableView.DataSource = null;
                                    DataTableView.Rows.Clear();
                                    DataTableView.Columns.Clear();
                                }

                                string[] DataList =
                                {
                                    "Сырьё",
                                    "Сырьё - Пришедшое",
                                    "Сырьё - Удалённое",
                                    "Сырьё - Остаток",
                                    "Цех",
                                    "Цех - Пришедшое",
                                    "Цех - Проданное",
                                    "Цех - Остаток",
                                    "Контрагент",
                                    "Расход - Сотрудники",
                                    "Расход - Питание",
                                    "Расход - Топливо",
                                    "Расход - Нужды Фирмы",
                                    "Касса"
                            };

                                ParentTables.Items.AddRange(DataList);

                                NormalMode = false;
                            }
                            catch (Exception) { }
                            NormalMode = false;
                        }
                    }
                }
            }
        }

        private void ParentTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ParentTables.SelectedItem != null)
            {
                TableNameThatWasLoadedFromList = ParentTables.SelectedItem.ToString();
                if (NormalMode)
                {
                    if (ParentTables.SelectedItem.ToString() == "Сырьё")
                    {
                        if (File.Exists(Application.StartupPath + "\\RawProductsList.data"))
                        {
                            try
                            {
                                string[] Data = File.ReadAllLines(Application.StartupPath + "\\RawProductsList.data");
                                ChildTables.Items.Clear();
                                ChildTables.Items.AddRange(Data);
                            }
                            catch (Exception) { General.Connection.Close(); }
                        }
                    }

                    if (ParentTables.SelectedItem.ToString() == "Цех")
                    {
                        if (File.Exists(Application.StartupPath + "\\ShopProductsList.data"))
                        {
                            try
                            {
                                string[] Data = File.ReadAllLines(Application.StartupPath + "\\ShopProductsList.data");
                                ChildTables.Items.Clear();
                                ChildTables.Items.AddRange(Data);
                            }
                            catch (Exception) { General.Connection.Close(); }
                        }
                    }

                    if (ParentTables.SelectedItem.ToString() == "Контрагент")
                    {
                        if (Directory.Exists(Application.StartupPath + "\\CounterpartyAgentsList"))
                        {
                            try
                            {
                                DirectoryInfo Dinfo = new DirectoryInfo("CounterpartyAgentsList");
                                FileInfo[] info = Dinfo.GetFiles("*.");
                                ChildTables.Items.Clear();
                                foreach (FileInfo finf in info)
                                {
                                    ChildTables.Items.Add(finf.Name);
                                }
                            }
                            catch (Exception) { General.Connection.Close(); }
                        }
                    }

                    if (ParentTables.SelectedItem.ToString() == "Сырьё - Пришедшое")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("RawMaterials", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Сырьё - Удалённое")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("RemovedRawMaterials", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Сырьё - Остаток")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("RawMaterialsResidue", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Цех - Пришедшое")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("ShopMaterials", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Цех - Проданное")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("SaledShopMaterials", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Цех - Остаток")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("ResidueShopMaterials", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Расход - Сотрудники")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("ExpenseWorker", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Расход - Питание")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("ExpenseFood", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Расход - Топливо")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("ExpenseFuel", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Расход - Нужды Фирмы")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("ExpenseFirm", DataTableView);
                    }

                    if (ParentTables.SelectedItem.ToString() == "Касса")
                    {
                        ChildTables.Items.Clear();
                        General.LoadSQLData("CashData", DataTableView);
                    }
                }
                else
                {
                    //Данные были загружены с архива или файла
                    if (Directory.Exists(Application.StartupPath + "//tempData"))
                    {
                        if (ParentTables.SelectedItem.ToString() == "Сырьё")
                        {
                            if (Directory.Exists(Application.StartupPath + "\\tempData\\raw"))
                            {
                                try
                                {
                                    DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "\\tempData\\raw");
                                    FileInfo[] info = Dinfo.GetFiles("*.*");
                                    ChildTables.Items.Clear();
                                    foreach (FileInfo finf in info)
                                    {
                                        ChildTables.Items.Add(finf.Name);
                                    }
                                }
                                catch (Exception) { General.Connection.Close(); }
                            }
                        }

                        if (ParentTables.SelectedItem.ToString() == "Цех")
                        {
                            if (Directory.Exists(Application.StartupPath + "\\tempData\\shop"))
                            {
                                try
                                {
                                    DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "\\tempData\\shop");
                                    FileInfo[] info = Dinfo.GetFiles("*.*");
                                    ChildTables.Items.Clear();
                                    foreach (FileInfo finf in info)
                                    {
                                        ChildTables.Items.Add(finf.Name);
                                    }
                                }
                                catch (Exception) { General.Connection.Close(); }
                            }
                        }

                        if (ParentTables.SelectedItem.ToString() == "Контрагент")
                        {
                            if (Directory.Exists(Application.StartupPath + "\\tempData\\counterparty"))
                            {
                                try
                                {
                                    DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "\\tempData\\counterparty");
                                    FileInfo[] info = Dinfo.GetFiles("*.*");
                                    ChildTables.Items.Clear();
                                    if (info != null)
                                    {
                                        foreach (FileInfo finf in info)
                                        {
                                            ChildTables.Items.Add(finf.Name);
                                        }
                                    }
                                }
                                catch (Exception) { General.Connection.Close(); }
                            }
                        }

                        if (ParentTables.SelectedItem.ToString() == "Расход - Сотрудники")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\expenseWorker.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\expenseWorker.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Расход - Питание")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\expenseFood.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\expenseFood.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Расход - Топливо")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\expenseFuel.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\expenseFuel.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Расход - Нужды Фирмы")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\expenseFirm.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\expenseFirm.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Касса")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\cash.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\cash.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Сырьё - Пришедшое")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\rawMaterials.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\rawMaterials.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Сырьё - Удалённое")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\removedRawMaterials.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\removedRawMaterials.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Сырьё - Остаток")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\rawMaterialsResidue.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\rawMaterialsResidue.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Цех - Пришедшое")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\shopMaterials.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\shopMaterials.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Цех - Проданное")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\saledShopMaterials.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\saledShopMaterials.bisytable", DataTableView);
                        }

                        if (ParentTables.SelectedItem.ToString() == "Цех - Остаток")
                        {
                            ChildTables.Items.Clear();
                            if (File.Exists(Application.StartupPath + "\\tempData\\residueShopMaterials.bisytable"))
                                General.LoadData(Application.StartupPath + "\\tempData\\residueShopMaterials.bisytable", DataTableView);
                        }
                    }
                }
            }
        }

        private void ChildTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ChildTables.SelectedItem != null)
            {
                TableNameThatWasLoadedFromList = ChildTables.SelectedItem.ToString();

                if (NormalMode)
                {
                    string TableName = ChildTables.SelectedItem.ToString();

                    try
                    {
                        General.LoadSQLData(TableName, DataTableView);
                    }
                    catch (Exception) { General.Connection.Close(); }
                }
                else
                {
                    //Данные были загружены с архива или файла
                    string SubDirectory = String.Empty;
                    if(ParentTables.SelectedItem.ToString() == "Сырьё")
                    {
                        SubDirectory = "raw";
                    }
                    if (ParentTables.SelectedItem.ToString() == "Цех")
                    {
                        SubDirectory = "shop";
                    }
                    if (ParentTables.SelectedItem.ToString() == "Контрагент")
                    {
                        SubDirectory = "counterparty";
                    }
                    if(Directory.Exists(Application.StartupPath + "//tempData//" + SubDirectory))
                    {
                        if(File.Exists(Application.StartupPath + "//tempData//" + SubDirectory + "//" + ChildTables.SelectedItem.ToString()))
                        {
                            General.LoadData(Application.StartupPath + "//tempData//" + SubDirectory + "//" + ChildTables.SelectedItem.ToString(), DataTableView);
                        }
                    }
                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            NormalMode = true;
            ParentTables.Items.Clear();
            ChildTables.Items.Clear();
            if(DataTableView.Columns.Count > 0 && DataTableView.Rows.Count > 0)
            {
                DataTableView.DataMember = null;
                DataTableView.DataSource = null;
                DataTableView.Rows.Clear();
                DataTableView.Columns.Clear();
            }

            string[] DataList =
                {
                        "Сырьё",
                        "Сырьё - Пришедшое",
                        "Сырьё - Удалённое",
                        "Сырьё - Остаток",
                        "Цех",
                        "Цех - Пришедшое",
                        "Цех - Проданное",
                        "Цех - Остаток",
                        "Контрагент",
                        "Расход - Сотрудники",
                        "Расход - Питание",
                        "Расход - Топливо",
                        "Расход - Нужды Фирмы",
                        "Касса"
                     };

            ParentTables.Items.AddRange(DataList);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            #region Очистка MS-SQL Таблиц
            string[] BaseTablesName = { "CashData", "ConculationData", "CounterpartyData", "ExpenseFirm", "ExpenseFood", "ExpenseFuel", "ExpenseResults", "ExpenseWorker", "ExpenseWorkers", "RawMaterials", "RawMaterialsResidue", "RemovedRawMaterials", "ResidueShopMaterials", "SaledShopMaterials", "ShopMaterials" };
            List<string> TablesNames = new List<string>();
            TablesNames.AddRange(BaseTablesName);

            try
            {
                DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "CounterpartyAgentsList");
                FileInfo[] info = Dinfo.GetFiles("*.");
                if(info != null)
                {
                    foreach (FileInfo finf in info)
                    {
                        TablesNames.Add(finf.Name);
                    }
                }
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                string[] RawNamesData = File.ReadAllLines(Application.StartupPath + "//RawProductsList.data");
                if(RawNamesData != null)
                {
                    foreach (string item in RawNamesData)
                    {
                        TablesNames.Add(item);
                    }
                }
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                string[] ShopNamesData = File.ReadAllLines(Application.StartupPath + "//ShopProductsList.data");
                if (ShopNamesData != null)
                {
                    foreach (string item in ShopNamesData)
                    {
                        TablesNames.Add(item);
                    }
                }
            }
            catch (Exception) { General.Connection.Close(); }

            foreach(string item in TablesNames)
            {
                General.Command = new SqlCommand(String.Format("delete from {0}", item), General.Connection);
                General.Connection.Open();
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
            }
            #endregion

            #region Очистка данных хронящихся в файлах
            try
            {
                DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "//CounterpartyAgentsList");
                FileInfo[] info = Dinfo.GetFiles("*.");
                if (info != null)
                {
                    foreach (FileInfo finf in info)
                    {
                        File.Delete(finf.Name);
                    }
                }
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//ShopProductsList.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//RawProductsList.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Shop.Residue.Data.xml");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Raw.Residue.Data.xml");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Firms.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Stocks.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Report//RawRemoved.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Report//ShopSaled.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Report//RawsImported.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Report//CratesRawImported.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//CPState.data");
            }
            catch (Exception) { General.Connection.Close(); }

            try
            {
                File.Delete(Application.StartupPath + "//Debt.data");
            }
            catch (Exception) { General.Connection.Close(); }
            #endregion
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string ClearN = String.Empty;
            if(TableNameThatWasLoadedFromList.Length > 0)
            {
                if(TableNameThatWasLoadedFromList == "Сырьё")
                {
                    ClearN = String.Empty;
                }
                if (TableNameThatWasLoadedFromList == "Сырьё - Пришедшое")
                {
                    ClearN = "RawMaterials";
                }
                if (TableNameThatWasLoadedFromList == "Сырьё - Удалённое")
                {
                    ClearN = "RemovedRawMaterials";
                }
                if (TableNameThatWasLoadedFromList == "Сырьё - Остаток")
                {
                    ClearN = "RawMaterialsResidue";
                }
                if (TableNameThatWasLoadedFromList == "Цех")
                {
                    ClearN = String.Empty;
                }
                if (TableNameThatWasLoadedFromList == "Цех - Пришедшое")
                {
                    ClearN = "ShopMaterials";
                }
                if (TableNameThatWasLoadedFromList == "Цех - Проданное")
                {
                    ClearN = "SaledShopMaterials";
                }
                if (TableNameThatWasLoadedFromList == "Цех - Остаток")
                {
                    ClearN = "ResidueShopMaterials";
                }
                if (TableNameThatWasLoadedFromList == "Контрагент")
                {
                    ClearN = "CounterpartyData";
                }
                if (TableNameThatWasLoadedFromList == "Расход - Сотрудники")
                {
                    ClearN = "ExpenseWorker";
                }
                if (TableNameThatWasLoadedFromList == "Расход - Питание")
                {
                    ClearN = "ExpenseFood";
                }
                if (TableNameThatWasLoadedFromList == "Расход - Топливо")
                {
                    ClearN = "ExpenseFuel";
                }
                if (TableNameThatWasLoadedFromList == "Расход - Нужды Фирмы")
                {
                    ClearN = "ExpenseFirm";
                }
                if (TableNameThatWasLoadedFromList == "Касса")
                {
                    ClearN = "CashData";
                }
                else
                {
                    ClearN = TableNameThatWasLoadedFromList;
                }

                try
                {
                    General.Command = new SqlCommand(String.Format("delete from {0}", ClearN), General.Connection);
                    General.Connection.Open();
                    General.Command.ExecuteNonQuery();
                    General.Connection.Close();
                }
                catch (Exception) { }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            CompressedArchive.CreateTempDirectory();
            CompressedArchive.CreateTempSubDirectories("raw", "shop", "counterparty");
            if (Directory.Exists(Application.StartupPath + "//tempData"))
            {
                try
                {
                    General.SaveData(Application.StartupPath + "//tempData//cash.bisytable", "CashData");
                    General.SaveData(Application.StartupPath + "//tempData//conculation.bisytable", "ConculationData");
                    General.SaveData(Application.StartupPath + "//tempData//counterparty.bisytable", "CounterpartyData");
                    General.SaveData(Application.StartupPath + "//tempData//expenseFirm.bisytable", "ExpenseFirm");
                    General.SaveData(Application.StartupPath + "//tempData//expenseFood.bisytable", "ExpenseFood");
                    General.SaveData(Application.StartupPath + "//tempData//expenseFuel.bisytable", "ExpenseFuel");
                    General.SaveData(Application.StartupPath + "//tempData//expenseWorker.bisytable", "ExpenseWorker");
                    General.SaveData(Application.StartupPath + "//tempData//rawMaterials.bisytable", "RawMaterials");
                    General.SaveData(Application.StartupPath + "//tempData//rawMaterialsResidue.bisytable", "RawMaterialsResidue");
                    General.SaveData(Application.StartupPath + "//tempData//removedRawMaterials.bisytable", "RemovedRawMaterials");
                    General.SaveData(Application.StartupPath + "//tempData//residueShopMaterials.bisytable", "ResidueShopMaterials");
                    General.SaveData(Application.StartupPath + "//tempData//saledShopMaterials.bisytable", "SaledShopMaterials");
                    General.SaveData(Application.StartupPath + "//tempData//shopMaterials.bisytable", "ShopMaterials");

                    try
                    {
                        if(Directory.Exists(Application.StartupPath + "//CounterpartyAgentsList"))
                        {
                            DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "//CounterpartyAgentsList");
                            FileInfo[] info = Dinfo.GetFiles("*.");
                            if (info != null)
                            {
                                foreach (FileInfo item in info)
                                {
                                    if(Directory.Exists(Application.StartupPath + "//tempData//counterparty"))
                                    {
                                        General.SaveData(Application.StartupPath + "//tempData//counterparty//" + item.Name + ".bisytable", item.Name);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception) { }

                    if (File.Exists(Application.StartupPath + "//RawProductsList.data"))
                    {
                        string[] RawArrayDataNames = File.ReadAllLines(Application.StartupPath + "//RawProductsList.data");
                        foreach (string item in RawArrayDataNames)
                        {
                            try
                            {
                                if (Directory.Exists(Application.StartupPath + "//tempData//raw"))
                                        General.SaveData(Application.StartupPath + "//tempData//raw//" + item + ".bisytable", item);
                            }
                            catch (Exception) { }
                        }
                    }

                    if (File.Exists(Application.StartupPath + "//ShopProductsList.data"))
                    {
                        string[] ShopArrayDataNames = File.ReadAllLines(Application.StartupPath + "//ShopProductsList.data");
                        foreach (string item in ShopArrayDataNames)
                        {
                            try
                            {
                                if (Directory.Exists(Application.StartupPath + "//tempData//shop"))
                                        General.SaveData(Application.StartupPath + "//tempData//shop//" + item + ".bisytable", item);
                            }
                            catch (Exception) { }
                        }
                    }
                }
                catch (Exception) { }
            }
            CompressedArchive.SaveArchiveData();
            CompressedArchive.DeleteTempDirectory();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                CompressedArchive.DeleteTempDirectory();
                CompressedArchive.CreateTempDirectory();
                CompressedArchive.LoadArchiveData();

                ParentTables.Items.Clear();
                ChildTables.Items.Clear();
                if (DataTableView.Columns.Count > 0 && DataTableView.Rows.Count > 0)
                {
                    DataTableView.DataMember = null;
                    DataTableView.DataSource = null;
                    DataTableView.Rows.Clear();
                    DataTableView.Columns.Clear();
                }

                string[]  DataList = 
                    {
                        "Сырьё",
                        "Сырьё - Пришедшое",
                        "Сырьё - Удалённое",
                        "Сырьё - Остаток",
                        "Цех",
                        "Цех - Пришедшое",
                        "Цех - Проданное",
                        "Цех - Остаток",
                        "Контрагент",
                        "Расход - Сотрудники",
                        "Расход - Питание",
                        "Расход - Топливо",
                        "Расход - Нужды Фирмы",
                        "Касса"
                     };

                ParentTables.Items.AddRange(DataList);

                NormalMode = false;
            }
            catch (Exception)
            {
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(RaskhodData);
        }

        private void saveAs1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(FoodDataPage);
        }

        private void saveAs2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(FuelDataEditor);
        }

        private void SaveAs3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SaveBiSyTable(FirmDataEditor);
        }

        private void InsertWorkers_Click(object sender, EventArgs e)
        {
            string wName = WorkerNameTextBox.Text;
            string wSurname = WorkerSurnameTextBox.Text;
            string wFirstN = WorkerFirstNameTextBox.Text;
            int wAge = int.Parse(WorkerAgeTextBox.Text);
            string wApp = WorkerAppointmentTextBox.Text;

            try
            {
                General.Command = new SqlCommand("insert into WorkersTable(Имя, Фамилия, Отчество, Возраст, Должность) values(@a, @b, @c, @d, @e)", General.Connection);
                General.Connection.Open();
                General.Command.Parameters.AddWithValue("@a", wName);
                General.Command.Parameters.AddWithValue("@b", wSurname);
                General.Command.Parameters.AddWithValue("@c", wFirstN);
                General.Command.Parameters.AddWithValue("@d", wAge);
                General.Command.Parameters.AddWithValue("@e", wApp);
                General.Command.ExecuteNonQuery();
                General.Connection.Close();
            }
            catch (Exception)
           {
                General.Connection.Close();
            }

            TableViewer tableViewer = new TableViewer("WorkersTable");
            tableViewer.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            TableViewer tableViewer = new TableViewer("WorkersTable");
            tableViewer.Show();
        }

        private void solaryMinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.SortData(RaskhodData, 2, ListSortDirection.Ascending);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General.ExportToExcel(RaskhodData);
        }

        private void RaskhodData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RowID = RaskhodData.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //HumanEditorStep3 H = new HumanEditorStep3();
            //H.ShowDialog(this);
            CounterpartyAccountList CpAccList = new CounterpartyAccountList();
            CpAccList.ShowDialog(this);
        }
    }
}
