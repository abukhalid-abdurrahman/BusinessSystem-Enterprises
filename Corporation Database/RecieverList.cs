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
using System.Threading;

namespace Corporation_Database
{
    public partial class RecieverList : Form
    {
        public string SelectedClient = null;

        public RecieverList()
        {
            InitializeComponent();
        }

        private void RecieverList_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + "//ReList"))
                Directory.CreateDirectory(Application.StartupPath + "//ReList");
            DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "//ReList");
            FileInfo[] info = Dinfo.GetFiles("*.");
            List.Items.Clear();
            if(info != null)
            {
                foreach (FileInfo finf in info)
                {
                    List.Items.Add(finf.Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "" || NameTextBox.Text == " ")
                return;
            else
            {
                General.CheckForExitsFile(Application.StartupPath + "//ReList//" + NameTextBox.Text);
                if (!Directory.Exists(Application.StartupPath + "//ReList"))
                    Directory.CreateDirectory(Application.StartupPath + "//ReList");

                DirectoryInfo Dinfo = new DirectoryInfo(Application.StartupPath + "//ReList");
                FileInfo[] info = Dinfo.GetFiles("*.");
                List.Items.Clear();
                if(info != null)
                {
                    foreach (FileInfo finf in info)
                    {
                        List.Items.Add(finf.Name);
                    }
                }
            }
        }

        private void List_MouseClick(object sender, MouseEventArgs e)
        {
            if(List.SelectedItem != null)
            {
                if(File.Exists(Application.StartupPath + "//ReList//" + List.SelectedItem.ToString()))
                {
                    string[] ClientsContent = File.ReadAllLines(Application.StartupPath + "//ReList//" + List.SelectedItem.ToString());
                    ClientList.Items.Clear();
                    if (ClientsContent != null)
                    {
                        ClientList.Items.AddRange(ClientsContent);
                    }
                }
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(List.SelectedItem != null)
            {
                StreamWriter StreamW = new StreamWriter(Application.StartupPath + "//ReList//" + List.SelectedItem.ToString(), true, Encoding.UTF8);
                StreamW.WriteLine(NameTextBox.Text);

                StreamW.Flush();
                StreamW.Close();
                General.DebtManager(0, false, NameTextBox.Text);
            }

            if(File.Exists(Application.StartupPath + "//ReList//" + List.SelectedItem.ToString()))
            {
                string[] ClientsContent = File.ReadAllLines(Application.StartupPath + "//ReList//" + List.SelectedItem.ToString());
                ClientList.Items.Clear();
                if (ClientsContent != null)
                {
                    ClientList.Items.AddRange(ClientsContent);
                }
            }
        }

        private void ClientList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ClientList.SelectedItem != null)
            {
                SelectedClient = ClientList.SelectedItem.ToString();
                this.Close();
            }
        }
    }
}
