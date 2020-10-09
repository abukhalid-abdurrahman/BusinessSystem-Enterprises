using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corporation_Database
{
    public partial class Login : Form
    {
        private string Argument;
        public Login(string args)
        {
            InitializeComponent();
            Argument = args;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == null || DolzhnostComboBox.SelectedItem == null)
                return;
            else if (PasswordTextBox.Text != "" && DolzhnostComboBox.SelectedItem != null)
            {
                VellaMain VM = new VellaMain(Argument);

                if (DolzhnostComboBox.SelectedIndex == 0 && PasswordTextBox.Text == "20152018")
                {
                    this.Hide();
                    VM.Show();
                }

                if (DolzhnostComboBox.SelectedIndex == 1 && PasswordTextBox.Text == "20182015")
                {
                    this.Hide();
                    VM.TabControl.TabPages.Remove(VM.HomePage);
                    VM.TabControl.TabPages.Remove(VM.tabPage1);
                    VM.TabControl.TabPages.Remove(VM.SirioPage);
                    VM.TabControl.TabPages.Remove(VM.DepotPage);
                    VM.TabControl.TabPages.Remove(VM.ShopPage);
                    VM.TabControl.TabPages.Remove(VM.humanPage);
                    VM.Show();
                }

                if (DolzhnostComboBox.SelectedIndex == 2 && PasswordTextBox.Text == "20182018")
                {
                    this.Hide();
                    VM.TabControl.TabPages.Remove(VM.HomePage);
                    VM.TabControl.TabPages.Remove(VM.raskhodPage);
                    VM.TabControl.TabPages.Remove(VM.tabPage5);
                    VM.TabControl.TabPages.Remove(VM.tabPage1);
                    VM.Show();
                }

                if (DolzhnostComboBox.SelectedIndex == 3 && PasswordTextBox.Text == "20002018")
                {
                    this.Hide();
                    VM.TabControl.TabPages.Remove(VM.HomePage);
                    VM.TabControl.TabPages.Remove(VM.tabPage1);
                    VM.TabControl.TabPages.Remove(VM.SirioPage);
                    VM.TabControl.TabPages.Remove(VM.DepotPage);
                    VM.TabControl.TabPages.Remove(VM.ShopPage);
                    VM.TabControl.TabPages.Remove(VM.tabPage5);
                    VM.Show();
                }

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            General.SetWatermark(PasswordTextBox, "Пароль...");
        }
    }
}
