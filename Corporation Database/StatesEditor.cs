using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Corporation_Database
{
    public partial class StatesEditor : Form
    {
        public StatesEditor()
        {
            InitializeComponent();
        }

        public string FilePath;

        public void Save()
        {
            try
            {
                General.CheckForExitsFile(FilePath);

                StreamWriter StreamW = new StreamWriter(FilePath, true, Encoding.UTF8);
                StreamW.WriteLine(StateTextBox.Text);
                StreamW.Flush();
                StreamW.Close();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        public void Clear()
        {
            try
            {
                General.CheckForExitsFile(FilePath);

                StreamWriter StreamW = new StreamWriter(FilePath, false, Encoding.UTF8);
                StreamW.Write(String.Empty);
                StreamW.Flush();
                StreamW.Close();
            }
            catch (Exception ex)
            {
                General.ShowErrorBox(ex);
            }
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            Save();
            StateTextBox.Text = String.Empty;
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            Clear();
            StateTextBox.Text = String.Empty;
        }
    }
}
