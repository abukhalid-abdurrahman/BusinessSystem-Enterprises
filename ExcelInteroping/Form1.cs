using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace ExcelInteroping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            var lines = new List<string>();

            string[] columnNames = DataT.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();

            var header = string.Join(";", columnNames);
            lines.Add(header);

            var valueLines = DataT.AsEnumerable()
                               .Select(row => string.Join(";", row.ItemArray));
            lines.AddRange(valueLines);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV File (*.csv)|*.csv|All files (*.*)|*.*";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveDialog.FilterIndex = 1;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllLines(saveDialog.FileName, lines);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
