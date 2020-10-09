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
    public partial class DatabaseRecordsConfiguration : Form
    {
        public DatabaseRecordsConfiguration()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatabaseRecordsConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                General.SetComboBoxItems(TextBox0, General.ComboBoxItemsType.DataTableColumnsItems, "WorkersTable", "Имя");
            }
            catch (Exception)
            {
                General.Connection.Close();
            }
        }
    }
}
