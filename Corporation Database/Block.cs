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
    public partial class Block : Form
    {
        public string Password = null;
        public bool Cancel = false;

        public Block()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cancel = false;
            this.Close();
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (PasswordBox.Text == Password)
            {
                button1.Enabled = true;
                button1.ForeColor = Color.Green;
                label1.ForeColor = Color.Green;
            }
            else if (PasswordBox.Text != Password)
            {
                button1.Enabled = false;
                button1.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
            }
        }

        private void Block_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Block_Formclosed(object sender, FormClosedEventArgs e)
        {
            if (this.PasswordBox.Text != this.Password)
            {
                Block block = new Block();
                block.Password = "2018";
                block.ShowDialog(this.ParentForm);
            }
        }
    }
}
