using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Corporation_Database
{
    public partial class UpdateRecordsManager : Form
    {

        private string tname = String.Empty;
        private int id = 0;

        public UpdateRecordsManager()
        {
            InitializeComponent();
        }

        public UpdateRecordsManager(string TableName, int ID)
        {
            InitializeComponent();
            tname = TableName;
            id = ID;
            LoadRecords();
        }

        private void LoadRecords()
        {
            idBox.Text = "ID - " + id;
            switch (tname)
            {
                case "CashData":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if(Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            try
                            {
                                string[] dateData = Reader[6].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "CounterpartyData":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            try
                            {
                                string[] dateData = Reader[6].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "ConculationData":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            textBox1.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "ExpenseFirm":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[3].ToString();
                            textBox3.Text = Reader[4].ToString();
                            try
                            {
                                string[] dateData = Reader[2].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "ExpenseFood":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[3].ToString();
                            try
                            {
                                string[] dateData = Reader[2].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "ExpenseFuel":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            try
                            {
                                string[] dateData = Reader[6].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "ExpenseWorker":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            try
                            {
                                string[] dateData = Reader[6].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "RawMaterials":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox6.Enabled = true;
                            textBox7.Enabled = true;
                            textBox8.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            textBox6.Text = Reader[6].ToString();
                            textBox7.Text = Reader[8].ToString();
                            textBox8.Text = Reader[9].ToString();
                            try
                            {
                                string[] dateData = Reader[7].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "RawMaterialsResidue":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox6.Enabled = true;
                            textBox7.Enabled = true;
                            textBox8.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            textBox6.Text = Reader[6].ToString();
                            textBox7.Text = Reader[8].ToString();
                            textBox8.Text = Reader[9].ToString();
                            try
                            {
                                string[] dateData = Reader[7].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "RemovedRawMaterials":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox6.Enabled = true;
                            textBox7.Enabled = true;
                            textBox8.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            textBox6.Text = Reader[6].ToString();
                            textBox7.Text = Reader[8].ToString();
                            textBox8.Text = Reader[9].ToString();
                            try
                            {
                                string[] dateData = Reader[7].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "ResidueShopMaterials":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox6.Enabled = true;
                            textBox7.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            textBox6.Text = Reader[7].ToString();
                            textBox7.Text = Reader[8].ToString();
                            try
                            {
                                string[] dateData = Reader[6].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "SaledShopMaterials":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox6.Enabled = true;
                            textBox7.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            textBox6.Text = Reader[7].ToString();
                            textBox7.Text = Reader[8].ToString();
                            try
                            {
                                string[] dateData = Reader[6].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "ShopMaterials":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox6.Enabled = true;
                            textBox7.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                            textBox6.Text = Reader[7].ToString();
                            textBox7.Text = Reader[8].ToString();
                            try
                            {
                                string[] dateData = Reader[6].ToString().Split('.');
                                int Day = int.Parse(dateData[0]);
                                int Month = int.Parse(dateData[1]);
                                int Year = int.Parse(dateData[2]);
                                DateTime dTime = new DateTime(Year, Month, Day);
                                DateTimePicker.Value = dTime;
                            }
                            catch (Exception ex)
                            {
                                General.ShowErrorBox(ex.Message);
                                Reader.Close();
                                General.Connection.Close();
                            }
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                case "WorkersTable":
                    {
                        General.Command = new SqlCommand(String.Format("select * from {0} where ID={1}", tname, id), General.Connection);
                        General.Connection.Open();
                        SqlDataReader Reader = General.Command.ExecuteReader();
                        if (Reader.Read())
                        {
                            DateTimePicker.Enabled = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox1.Text = Reader[1].ToString().Trim();
                            textBox2.Text = Reader[2].ToString();
                            textBox3.Text = Reader[3].ToString();
                            textBox4.Text = Reader[4].ToString();
                            textBox5.Text = Reader[5].ToString();
                        }
                        Reader.Close();
                        General.Connection.Close();
                    }
                    break;
                default:
                    General.ShowErrorBox("WRONG TABLE NAME!!!");
                    this.Close();
                    break;
            }
        }

        private void UpdateData()
        {
            string SelectedDate = DateTimePicker.Text;
            switch (tname)
            {
                case "CashData":
                    {
                        float val = float.Parse(textBox3.Text.Replace(".", ","));
                        General.UpdateCellData(tname, "Поставщик", textBox1.Text, id);
                        General.UpdateCellData(tname, "Должен", textBox2.Text, id);
                        General.UpdateCellData(tname, "Оплаченно", textBox3.Text, id);
                        General.UpdateCellData(tname, "Осталось", textBox4.Text, id);
                        General.UpdateCellData(tname, "Бонус", textBox5.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                        if(val != 0)
                        {
                            if (val > 0)
                            {
                                General.DebtManager(val, true, textBox1.Text);
                            }
                            else if(val < 0)
                            {
                                General.DebtManager(val, false, textBox1.Text);
                            }
                        }
                    }
                    break;
                case "CounterpartyData":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Цена", textBox2.Text, id);
                        General.UpdateCellData(tname, "Количество", textBox3.Text, id);
                        General.UpdateCellData(tname, "Поставщик", textBox4.Text, id);
                        General.UpdateCellData(tname, "Контрагент", textBox5.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "ConculationData":
                    {
                        General.UpdateCellData(tname, "Название", textBox1.Text, id);
                    }
                    break;
                case "ExpenseFirm":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Покупка", textBox2.Text, id);
                        General.UpdateCellData(tname, "Сумма", textBox3.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "ExpenseFood":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Сумма", textBox2.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "ExpenseFuel":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Сумма", textBox2.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "ExpenseWorker":
                    {
                        General.UpdateCellData(tname, "ФИО", textBox1.Text, id);
                        General.UpdateCellData(tname, "Зарплата", textBox2.Text, id);
                        General.UpdateCellData(tname, "Аванс", textBox3.Text, id);
                        General.UpdateCellData(tname, "Остаток", textBox4.Text, id);
                        General.UpdateCellData(tname, "Общий", textBox5.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "RawMaterials":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Масса", textBox2.Text, id);
                        General.UpdateCellData(tname, "Цена", textBox3.Text, id);
                        General.UpdateCellData(tname, "Количество", textBox4.Text, id);
                        General.UpdateCellData(tname, "КоличествоКаробок", textBox5.Text, id);
                        General.UpdateCellData(tname, "Сумма", textBox6.Text, id);
                        General.UpdateCellData(tname, "Поставщик", textBox7.Text, id);
                        General.UpdateCellData(tname, "Получатель", textBox8.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "RawMaterialsResidue":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Масса", textBox2.Text, id);
                        General.UpdateCellData(tname, "Цена", textBox3.Text, id);
                        General.UpdateCellData(tname, "Количество", textBox4.Text, id);
                        General.UpdateCellData(tname, "КоличествоКаробок", textBox5.Text, id);
                        General.UpdateCellData(tname, "Сумма", textBox6.Text, id);
                        General.UpdateCellData(tname, "Поставщик", textBox7.Text, id);
                        General.UpdateCellData(tname, "Получатель", textBox8.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "RemovedRawMaterials":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Масса", textBox2.Text, id);
                        General.UpdateCellData(tname, "Цена", textBox3.Text, id);
                        General.UpdateCellData(tname, "Количество", textBox4.Text, id);
                        General.UpdateCellData(tname, "КоличествоКаробок", textBox5.Text, id);
                        General.UpdateCellData(tname, "Сумма", textBox6.Text, id);
                        General.UpdateCellData(tname, "Поставщик", textBox7.Text, id);
                        General.UpdateCellData(tname, "Получатель", textBox8.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "ResidueShopMaterials":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Масса", textBox2.Text, id);
                        General.UpdateCellData(tname, "Цена", textBox3.Text, id);
                        General.UpdateCellData(tname, "Количество", textBox4.Text, id);
                        General.UpdateCellData(tname, "КоличествоКаробок", textBox5.Text, id);
                        General.UpdateCellData(tname, "Поставщик", textBox6.Text, id);
                        General.UpdateCellData(tname, "Получатель", textBox7.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "SaledShopMaterials":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Масса", textBox2.Text, id);
                        General.UpdateCellData(tname, "Цена", textBox3.Text, id);
                        General.UpdateCellData(tname, "Количество", textBox4.Text, id);
                        General.UpdateCellData(tname, "КоличествоКаробок", textBox5.Text, id);
                        General.UpdateCellData(tname, "Поставщик", textBox6.Text, id);
                        General.UpdateCellData(tname, "Получатель", textBox7.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "ShopMaterials":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Масса", textBox2.Text, id);
                        General.UpdateCellData(tname, "Цена", textBox3.Text, id);
                        General.UpdateCellData(tname, "Количество", textBox4.Text, id);
                        General.UpdateCellData(tname, "КоличествоКаробок", textBox5.Text, id);
                        General.UpdateCellData(tname, "Поставщик", textBox6.Text, id);
                        General.UpdateCellData(tname, "Получатель", textBox7.Text, id);
                        General.UpdateCellData(tname, "Дата", SelectedDate, id);
                    }
                    break;
                case "WorkersTable":
                    {
                        General.UpdateCellData(tname, "Имя", textBox1.Text, id);
                        General.UpdateCellData(tname, "Фамилия", textBox2.Text, id);
                        General.UpdateCellData(tname, "Отчество", textBox3.Text, id);
                        General.UpdateCellData(tname, "Возраст", textBox4.Text, id);
                        General.UpdateCellData(tname, "Должность", textBox5.Text, id);
                    }
                    break;
                default:
                    General.ShowErrorBox("WRONG TABLE NAME!!!");
                    this.Close();
                    break;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            UpdateData();
            this.Close();
        }
    }
}
