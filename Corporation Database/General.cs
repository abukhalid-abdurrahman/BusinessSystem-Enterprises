using System;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading;

namespace Corporation_Database
{
    class General
    {
        //public static SqlConnection Connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\user\\Desktop\\Corporation Database\\Corporation Database\\MineData.mdf\";Integrated Security=True");
        //public static SqlConnection Connection = new SqlConnection(String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"{0}\";Integrated Security=True", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\VellaDatabase\\MineData.mdf"));
        public static SqlConnection Connection = new SqlConnection(String.Format("Server=(localdb)\\MSSQLLocalDB;AttachDbFilename=\"{0}\"", String.Format(@"{0}\MineData.mdf", Application.StartupPath)));
        public static SqlDataAdapter Adapt;
        public static SqlCommand Command;

        public enum ReportType
        {
            ReportCollection,
            ExpenseReport,
            FormulaReport
        }

        public enum ComboBoxItemsType
        {
            DataTableColumnsItems,
            FolderFilesToItems,
            FilesLinesToItems
        }


        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public static void SetWatermark(Control controlBox, string waterMark)
        {
            SendMessage(controlBox.Handle, EM_SETCUEBANNER, 0, waterMark);
        }

        public static void DeleteDirectory(string dirName)
        {
            if (Directory.Exists(Application.StartupPath + "//" + dirName))
            {
                try
                {
                    Directory.Delete(Application.StartupPath + "//" + dirName);
                }
                catch (IOException)
                {
                    DirectoryInfo DirInfo = new DirectoryInfo(Application.StartupPath + "//" + dirName);
                    FileInfo[] info = DirInfo.GetFiles("*.*");
                    if (info != null)
                    {
                        foreach (FileInfo finf in info)
                        {
                            if (File.Exists(finf.FullName))
                                File.Delete(finf.FullName);
                        }
                    }

                    DirectoryInfo[] dNames = DirInfo.GetDirectories();
                    if (dNames != null)
                    {
                        DirectoryInfo SubDirInfo = null;
                        FileInfo[] SubFileInfo = null;

                        foreach (DirectoryInfo item in dNames)
                        {
                            SubDirInfo = new DirectoryInfo(Application.StartupPath + "//" + dirName + "//" + item);
                            SubFileInfo = SubDirInfo.GetFiles("*.*");
                            if (SubFileInfo != null)
                            {
                                foreach (FileInfo fitem in SubFileInfo)
                                {
                                    if (File.Exists(fitem.FullName))
                                        File.Delete(fitem.FullName);
                                }
                            }
                            Directory.Delete(item.FullName);
                        }
                    }
                    Directory.Delete(Application.StartupPath + "//" + dirName);
                }
            }
        }

        public static void SetTextBoxPlaceholder(string text, TextBox control)
        {
            control.Text = text;
            control.ForeColor = System.Drawing.Color.LightGray;
            control.Font = new System.Drawing.Font("Microsoft Sans Serif", control.Font.Size, System.Drawing.FontStyle.Italic, control.Font.Unit);
        }

        public static void ClearPlaceHolder(TextBox control)
        {
            if(control.Font.Style == System.Drawing.FontStyle.Italic && control.ForeColor == System.Drawing.Color.LightGray)
            {
                control.Text = String.Empty;
                control.ForeColor = System.Drawing.Color.Black;
                control.Font = new System.Drawing.Font("Microsoft Sans Serif", control.Font.Size, System.Drawing.FontStyle.Regular, control.Font.Unit);
            }
        }

        public static float SumColumnDataSQL(string columnName, string tableName)
        {
            float Value = 0.0f;
            try
            {
                General.Command = new SqlCommand(String.Format("select sum({0}) from {1}", columnName, tableName), General.Connection);
                General.Connection.Open();
                Value = float.Parse(General.Command.ExecuteScalar().ToString().Replace(".", ","));
                General.Connection.Close();
            }
            catch(Exception)
            {
                General.Connection.Close();
            }
            return Value;
        }

        public static float ReadFromFileValue(string Path, int Index)
        {
            CheckForExitsFile(Path);
            string[] SData = File.ReadAllLines(Path);
            float ReadedData = float.Parse(SData[Index].Replace(".", ","));
            return ReadedData;
        }

        public static bool CheckIsFileNull(string Path)
        {
            bool Result = true;
            CheckForExitsFile(Path);
            byte[] FileSize = File.ReadAllBytes(Path);
            if(FileSize.Length == 0)
            {
                Result = true;
            }
            else if(FileSize.Length > 0)
            {
                Result = false;
            }
            return Result;
        }
        public static void WriteToFileValue(string Path, object Value, bool Append)
        {
            try
            {
                CheckForExitsFile(Path);
                StreamWriter Writer = new StreamWriter(Path, Append, Encoding.UTF8);
                Writer.Write(Value);
                if (Append)
                    Writer.WriteLine();
                Writer.Flush();
                Writer.Close();
            }
            catch (IOException ex)
            {
                ShowErrorBox(ex);
            }
        }
        public static void ExportToExcel(DataGridView DataControl)
        {
            DataTable DataT = new DataTable();
            try
            {
                try
                {
                    if (DataControl.Columns != null && DataControl.Rows != null)
                    {
                        foreach (DataGridViewColumn item in DataControl.Columns)
                        {
                            DataT.Columns.Add(item.HeaderText);
                        }
                        foreach (DataGridViewRow item in DataControl.Rows)
                        {
                            DataRow DataR = DataT.NewRow();
                            foreach (DataGridViewCell cell in item.Cells)
                            {
                                DataR[cell.ColumnIndex] = cell.Value;
                            }
                            DataT.Rows.Add(DataR);
                        }
                    }
                }
                catch (Exception) { }
            }
            catch (Exception) { }

            try
            {
                if (DataT == null || DataT.Columns.Count == 0)
                    throw new Exception("Экспорт в MS Excel: Пустая таблица!\n");

                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                Excel._Worksheet workSheet = excelApp.ActiveSheet;

                for (var i = 0; i < DataT.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = DataT.Columns[i].Caption;
                }

                for (var i = 0; i < DataT.Rows.Count; i++)
                {
                    for (var j = 0; j < DataT.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = DataT.Rows[i][j];
                    }
                }

                try
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel File (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    saveDialog.FilterIndex = 1;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(saveDialog.FileName))
                        {
                            try
                            {
                                workSheet.SaveAs(saveDialog.FileName);
                                excelApp.Quit();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Экспорт в MS Excel: Не удалось сохранить файл!\n"
                                                    + ex.Message);
                            }
                        }
                        else
                        {
                            excelApp.Visible = true;
                        }
                    }
                }
                catch (Exception) { }
            }
            catch (Exception ex)
            {
                throw new Exception("Экспорт в MS Excel: \n" + ex.Message);
            }
        }

        public static void ShowErrorBox(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowErrorBox(string Error)
        {
            MessageBox.Show(Error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void CheckForExitsFile(string Path)
        {
            FileStream FS = new FileStream(Path, FileMode.OpenOrCreate);
            FS.Flush();
            FS.Close();
        }

        public static void InsertRowToXMLData(string Path, string DataName, params string[] Data)
        {
            string[] Content = null;
            if (!File.Exists(Path))
            {
                StreamWriter SWriter = new StreamWriter(Path, false, Encoding.UTF8);
                SWriter.Write("<?xml version=\"1.0\" standalone=\"yes\"?>\n<NewDataSet>\n</NewDataSet>");
                SWriter.Flush();
                SWriter.Close();
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement xRowRoot = xDoc.CreateElement(DataName);
            for (int i = 0; i < Data.Length; i++)
            {
                Content = Data[i].Split('=');
                XmlElement cellName = xDoc.CreateElement(Content[0]);
                cellName.InnerText = Content[1];
                xRowRoot.AppendChild(cellName);
            }
            xRoot.AppendChild(xRowRoot);
            StreamWriter SXMLWriter = new StreamWriter(Path, false, Encoding.UTF8);
            xDoc.Save(SXMLWriter);
            SXMLWriter.Flush();
            SXMLWriter.Close();
        }

        public static float SumColumnsData(string Path, string ColumnName)
        {
            float Sum = 0.0f;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Path);
            XmlElement xElemRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xElemRoot.SelectNodes(ColumnName);
            foreach (XmlNode xNode in childnodes)
            {
                Sum += float.Parse(xNode.InnerText.Replace(".", ","));
            }
            return Sum;
        }

        public static void CheckForExitsXMLFile(string Path)
        {
            if (!File.Exists(Path))
            {
                StreamWriter SWriter = new StreamWriter(Path, false, Encoding.UTF8);
                SWriter.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<settings>\n</settings>");
                SWriter.Flush();
                SWriter.Close();
            }
        }

        public static void CheckForExitsDirectory(string Path)
        {
            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);
        }

        public static void SetRowIndex(DataGridView DataControl)
        {
            foreach (DataGridViewRow Row in DataControl.Rows)
            {
                Row.HeaderCell.Value = String.Format("{0}", Row.Index + 1);
            }
        }

        public static int GetRowIndex(DataGridView DataControl)
        {
            return DataControl.CurrentCell.RowIndex;
        }

        public static int GetRowsCount(string DataTName)
        {
            int Count = 0;
            Command = new SqlCommand("select count(*) from " + DataTName, Connection);
            Connection.Open();
            Count = (Int32)Command.ExecuteScalar();
            Connection.Close();
            return Count;
        }

        public static void SearchFromDataGridViewControl(DataGridView DataControl, string SearchValueSource, int CellIndex)
        {
            DataControl.ClearSelection();
            String SearchValue = SearchValueSource;
            int RowIndex = -1;
            foreach (DataGridViewRow RowToSearch in DataControl.Rows)
            {
                if (RowToSearch.Cells[CellIndex].Value != null)
                {
                    if (RowToSearch.Cells[CellIndex].Value.ToString().ToLower().Equals(SearchValue.ToLower()))
                    {
                        RowIndex = RowToSearch.Index;
                        DataControl.Rows[RowIndex].Selected = true;
                        DataControl.FirstDisplayedScrollingRowIndex = RowIndex;
                        break;
                    }
                }
            }
        }

        public static void FormBlock(KeyEventArgs e, Form form)
        {
            if (e.KeyCode == Keys.F12)
            {
                Block block = new Block();
                block.Password = "2018";
                block.ShowDialog(form);
            }
        }

        public static void ChangeFontFromForm(Form form, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                FontDialog fontD = new FontDialog();
                fontD.ShowDialog(form);
                form.Font = fontD.Font;
            }
        }

        public static void ChangeFontFromControl(Control element, Form form, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                FontDialog fontD = new FontDialog();
                fontD.ShowDialog(form);
                element.Font = fontD.Font;
            }
        }

        public static void ChangeWidth(DataGridView Control)
        {
            for (int i = 0; i < Control.ColumnCount; i++)
            {
                Control.Columns[i].Width = Control.Width / Control.ColumnCount + 20;
            }
        }

        public static void SetGridStyle(DataGridView DCtrl, System.Drawing.Color SelectionColor)
        {
            for (int i = 0; i < DCtrl.Rows.Count; i++)
            {
                for (int j = 0; j < DCtrl.ColumnCount; j++)
                {
                    DCtrl.Rows[i].Cells[j].Style.WrapMode = DataGridViewTriState.True;
                    DCtrl.Rows[i].Cells[j].Style.SelectionBackColor = SelectionColor;
                    DCtrl.BackgroundColor = System.Drawing.Color.White;
                }
            }
        }
        /*
                public static void LoadData(string DataFilePath, DataGridView DataBase)
                {
                    StreamReader ReaderFile = new StreamReader(DataFilePath, Encoding.UTF8);
                    string[] str0;
                    int N = 0;
                    //try
                    //{
                        string[] str1 = ReaderFile.ReadToEnd().Split('\n');
                        N = str1.Count();
                        DataBase.RowCount = N;
                        for (int i = 0; i < N; i++)
                        {
                            str0 = str1[i].Split('^');
                            for (int j = 0; j < DataBase.ColumnCount; j++)
                            {
                                string ReadedData = str0[j].Replace("[delta-symbol]", "^");
                                DataBase.Rows[i].Cells[j].Value = ReadedData;
                            }
                        }
                    //}
                    //catch (Exception ex) { }
                    //finally
                    //{
                        ReaderFile.Close();
                    //}
                }

                public static string[] LoadData(string DataFilePath)
                {
                    string[] ArrayR = null;
                    StreamReader ReaderFile = new StreamReader(DataFilePath, Encoding.UTF8);
                    try
                    {
                        string[] ArrayLineData = ReaderFile.ReadToEnd().Split('\n');
                        int N = ArrayLineData.Count();
                        for(int i = 0; i < N; i++)
                        {
                            ArrayR = ArrayLineData[i].Split('^');
                        }
                    }
                    catch (Exception) { }
                    finally
                    {
                        ReaderFile.Close();
                    }
                    return ArrayR;
                }
        */
        /*
                public static void SaveData(string DataFilePath, DataGridView DataBase, bool Append)
                {
                    StreamWriter WriteFile = new StreamWriter(DataFilePath, Append, Encoding.UTF8);
                    try
                    {
                        for (int i = 0; i < DataBase.RowCount; i++)
                        {
                            for (int j = 0; j < DataBase.ColumnCount; j++)
                            {
                                string WritedData = DataBase.Rows[i].Cells[j].Value.ToString().Replace("^", "[delta-symbol]");
                                WriteFile.Write(WritedData + "^");
                            }
                            WriteFile.WriteLine();
                        }
                    }
                    catch (Exception) { }
                    finally
                    {
                        WriteFile.Flush();
                        WriteFile.Close();
                    }
                }
        */

        public static void SaveData(string Path, DataGridView DataControl)
        {
            DataSet DataS = new DataSet();
            DataTable DataT = new DataTable();
            foreach (DataGridViewColumn item in DataControl.Columns)
            {
                DataT.Columns.Add(item.Name);
            }
            foreach (DataGridViewRow item in DataControl.Rows)
            {
                DataRow DataR = DataT.NewRow();
                foreach (DataGridViewCell cell in item.Cells)
                {
                    DataR[cell.ColumnIndex] = cell.Value;
                }
                DataT.Rows.Add(DataR);
            }
            DataS.Tables.Add(DataT);
            DataS.Tables[0].TableName = DataControl.Name;
            DataS.WriteXml(Path);
        }

        public static void SaveData(string Path, string TableName)
        {
            try
            {
                DataSet DataS = new DataSet();
                DataTable DataT = new DataTable();
                try
                {
                    LoadSQLData(TableName, DataT);
                }
                catch (Exception) { }
                DataS.Tables.Add(DataT);
                DataS.Tables[0].TableName = TableName;
                try
                {
                    DataS.WriteXml(Path);
                }
                catch (Exception)
                {
                    if (File.Exists(Path))
                        File.Delete(Path);

                    DataS.WriteXml(Path);
                }
            }
            catch (Exception) { }
        }

        public static void LoadData(string Path, DataGridView DataControl)
        {
            if (DataControl.Columns.Count > 0 && DataControl.Rows.Count > 0 )
            {
                DataControl.DataMember = null;
                DataControl.DataSource = null;
                DataControl.Rows.Clear();
                DataControl.Columns.Clear();
            }

            if(File.Exists(Path))
            {
                XmlReader xmlFile;
                xmlFile = XmlReader.Create(Path, new XmlReaderSettings());
                DataSet DataS = new DataSet();
                DataS.ReadXml(xmlFile);
                DataControl.DataSource = DataS.Tables[0];
            }
        }

        public static void SaveGraph(System.Windows.Forms.DataVisualization.Charting.Chart ChartControl)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JPEG Image FIle (*.jpeg)|*.jpeg|PNG Image FIle (*.png)|*.png|GIF Image FIle (*.gif)|*.gif";
            saveDialog.FilterIndex = 1;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveDialog.FilterIndex == 1)
                {
                    ChartControl.SaveImage(saveDialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg);
                }

                if (saveDialog.FilterIndex == 2)
                {
                    ChartControl.SaveImage(saveDialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                }

                if (saveDialog.FilterIndex == 3)
                {
                    ChartControl.SaveImage(saveDialog.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Gif);
                }
            }
        }

        public static void SortData(DataGridView DataControl, int Index, System.ComponentModel.ListSortDirection ListSort)
        {
            DataControl.Sort(DataControl.Columns[Index], ListSort);
        }

        public static void DeleteFromSQLDataBase(string TableName, string ID, object oID)
        {
            Command = new SqlCommand(String.Format("delete from {0} where {1}=@id", TableName, ID), Connection);
            Connection.Open();
            Command.Parameters.AddWithValue("@id", oID);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static void LoadSQLData(string Table, DataGridView DataControl)
        {
            try
            {
                Connection.Open();
                DataTable DataT = new DataTable();
                Adapt = new SqlDataAdapter(String.Format("if exists (select * from sys.tables where name like '{0}')select * from {0}", Table), Connection);
                Adapt.Fill(DataT);
                DataControl.DataSource = DataT;
                Connection.Close();
            }
            catch (Exception)
            {
                Connection.Close();
            }
        }

        public static void LoadSQLData(string Table, string Columns, DataGridView DataControl)
        {
            Connection.Open();
            DataTable DataT = new DataTable();
            Adapt = new SqlDataAdapter(String.Format("select {0} from {1}", Columns, Table), Connection);
            Adapt.Fill(DataT);
            DataControl.DataSource = DataT;
            Connection.Close();
        }

        public static void LoadSQLData(string Table, DataSet DataControl)
        {
            Command = new SqlCommand("select * from " + Table, Connection);
            Connection.Open();
            Adapt = new SqlDataAdapter(Command);
            Adapt.Fill(DataControl);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static void LoadSQLData(string Table, DataTable DataControl)
        {
            Command = new SqlCommand("select * from " + Table, Connection);
            Connection.Open();
            Adapt = new SqlDataAdapter(Command);
            Adapt.Fill(DataControl);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static void GenGraph(string X, string Y, DataTable Table)
        {
            GraphGenerator Graph = new GraphGenerator();
            Graph.XValue = X;
            Graph.YValue = Y;
            Graph.ChartTable = Table;
            Graph.Show();
        }

        public static int RowsCount(string TableName, string ColumnName)
        {
            int Data;
            Connection.Open();
            SqlCommand Command = new SqlCommand(String.Format("select count({0}) from {1}", ColumnName, TableName), Connection);
            Data = (Int32)Command.ExecuteScalar();
            Connection.Close();

            return Data;
        }

        public static void ConnectChart(string DataName, string XValue, string YValue, DataTable ChartTable, System.Windows.Forms.DataVisualization.Charting.Chart ChartControl)
        {
            /*
            ChartControl.Series[DataName].XValueMember = XValue;
            ChartControl.Series[DataName].YValueMembers = YValue;
            ChartControl.DataSource = ChartTable;
            ChartControl.DataBind();
            Connection.Close();
            */
        }

        public static void CreateTable(string TableName, string Columns)
        {
            Command = new SqlCommand(String.Format("if not exists (select * from sys.tables where name like '{0}')create table {0}({1})", TableName, Columns), Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static void CreateCounterpartyAccount(string Name)
        {
            if (!Directory.Exists("CounterpartyAgentsList"))
                Directory.CreateDirectory("CounterpartyAgentsList");

            if (!File.Exists("CounterpartyAgentsList/" + Name))
            {
                CheckForExitsFile("CounterpartyAgentsList/" + Name);
                File.WriteAllText("CounterpartyAgentsList/" + Name, "0");
            }
        }

        public static void DebtManager(float Count, bool Append, string Name)
        {
            float Debt = GetDebt(Name);
            string RootPath = Application.StartupPath + "//CounterpartyAgentsList";

            if (Append)
            {
                Debt += Count;
            }
            else
            {
                Debt -= Count;
            }


            if (Directory.Exists(RootPath))
            {
                if (File.Exists(RootPath + "//" + Name))
                {
                    File.WriteAllText(RootPath+ "//" + Name, Debt.ToString());
                }
                else
                {
                    General.WriteToFileValue(RootPath + "//" + Name, Debt.ToString(), false);
                }
            }
            else
            {
                Directory.CreateDirectory(RootPath);
                if(Directory.Exists(RootPath))
                {
                    if (File.Exists(RootPath + "//" + Name))
                    {
                        File.WriteAllText(RootPath + "//" + Name, Debt.ToString());
                    }
                    else
                    {
                        General.WriteToFileValue(RootPath + "//" + Name, Debt.ToString(), false);
                    }
                }
            }
        }

        public static float GetDebt(string Name)
        {
            string RootPath = Application.StartupPath + "//CounterpartyAgentsList";
            if (Directory.Exists(RootPath))
            {
                if (File.Exists(RootPath + "//" + Name))
                {
                    float Count = float.Parse(File.ReadAllText(RootPath + "//" + Name).ToString().Replace(".", ","));
                    return Count;
                }
                else
                {
                    General.WriteToFileValue(RootPath + "//" + Name, 0, false);
                    return 0;
                }
            }
            else
            {
                Directory.CreateDirectory(RootPath);
                if (File.Exists(RootPath + "//" + Name))
                {
                    float Count = float.Parse(File.ReadAllText(RootPath + "//" + Name).ToString().Replace(".", ","));
                    return Count;
                }
                else
                {
                    General.WriteToFileValue(RootPath + "//" + Name, 0, false);
                    return 0;
                }
            }
        }

        public static void UpdateDebtSQLDataTable(int PaidMoney, int CurrentDebt, string TableName, int id)
        {
            int Residue = CurrentDebt - PaidMoney;
            Command = new SqlCommand(String.Format("update {0} set Должен=@debt, Оплаченно=@paid, Осталось=@residue where ID=@id", TableName), Connection);
            Connection.Open();
            Command.Parameters.AddWithValue("@id", id);
            Command.Parameters.AddWithValue("@debt", CurrentDebt);
            Command.Parameters.AddWithValue("@paid", PaidMoney);
            Command.Parameters.AddWithValue("@residue", Residue);
            Connection.Close();
        }

        public static void UpdateCellData(string TableName, string cellName, string newValue, int id)
        {
            Command = new SqlCommand(String.Format("update {0} set {1}=@cellName where ID=@id", TableName, cellName), Connection);
            Connection.Open();
            Command.Parameters.AddWithValue("@id", id);
            Command.Parameters.AddWithValue("@cellName", newValue);
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public static void SetComboBoxItems(ComboBox cBox, ComboBoxItemsType type, string Content, string name)
        {
            switch (type)
            {
                case ComboBoxItemsType.DataTableColumnsItems:
                    {
                        Command = new SqlCommand("select * from " + Content, Connection);
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            cBox.Items.Add(Reader[name].ToString());
                        }
                        Reader.Close();
                        Connection.Close();
                    }
                    break;
                case ComboBoxItemsType.FolderFilesToItems:
                    {
                        if(Directory.Exists(Content))
                        {
                            DirectoryInfo Dinfo = new DirectoryInfo(Content);
                            FileInfo[] info = Dinfo.GetFiles("*.");
                            cBox.Items.Clear();
                            if(info != null)
                            {
                                foreach (FileInfo finf in info)
                                {
                                    cBox.Items.Add(finf.Name);
                                }
                            }
                        }
                    }
                    break;
                case ComboBoxItemsType.FilesLinesToItems:
                    {
                        if(File.Exists(Content))
                        {
                            string[] items = File.ReadAllLines(Content);
                            cBox.Items.Clear();
                            if(items != null)
                            {
                                cBox.Items.AddRange(items);
                            }
                        }
                    }
                    break;
            }
        }

        public static void SaveBiSyTable(DataGridView DataControl)
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfg.Filter = "BiSyTable (*.bisytable)|*.bisytable";
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                General.SaveData(sfg.FileName, DataControl);
            }
        }

        public static void SendMail(string From, string To,
                                    string Login, string Password,
                                    string Subject, string Header,
                                    string Message)
        {
            string Host = "smtp.gmail.com";

            int Port = 587;

            string Body =
                "<h1>" + Header + "</h1>"
                + "<p>" + Message + "</p>";

            MailMessage MMess = new MailMessage();
            MMess.IsBodyHtml = true;
            MMess.From = new MailAddress(From, From);
            MMess.To.Add(new MailAddress(To));
            MMess.Subject = Subject;
            MMess.Body = Body;

            using (var client = new System.Net.Mail.SmtpClient(Host, Port))
            {
                client.Credentials = new NetworkCredential(Login, Password);

                client.EnableSsl = true;

                try
                {
                    client.Send(MMess);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
        }
    }
}
