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
    public partial class StorageViewer : Form
    {
        public string LoadDataType = "NONE";
        public StorageViewer()
        {
            InitializeComponent();
        }

        private void TabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void StorageViewer_Load(object sender, EventArgs e)
        {
            if (LoadDataType == "Raw")
            {
                General.LoadSQLData("RawMaterials", ImportedMaterials);
                General.LoadSQLData("RemovedRawMaterials", RemovedMaterials);
                General.LoadSQLData("RawMaterialsResidue", ResidueMaterials);
            }
            else if(LoadDataType == "Shop")
            {
                General.LoadSQLData("ShopMaterials", ImportedMaterials);
                General.LoadSQLData("SaledShopMaterials", RemovedMaterials);
                General.LoadSQLData("ResidueShopMaterials", ResidueMaterials);
            }

            General.ChangeWidth(ImportedMaterials);
            General.ChangeWidth(RemovedMaterials);
            General.ChangeWidth(ResidueMaterials);
            General.SetRowIndex(ImportedMaterials);
            General.SetRowIndex(RemovedMaterials);
            General.SetRowIndex(ResidueMaterials);
            General.SetGridStyle(ImportedMaterials, Color.Aqua);
            General.SetGridStyle(RemovedMaterials, Color.LightBlue);
            General.SetGridStyle(ResidueMaterials, Color.LightSalmon);
        }
    }
}
