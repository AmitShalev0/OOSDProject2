using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExpertsMaintenance
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnProductsSupplier_Click(object sender, EventArgs e)
        {
            frmProductsSupplier frmProductsSupplier = new frmProductsSupplier();
            DialogResult result = frmProductsSupplier.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
         {  
           
           frmProducts frmProducts = new frmProducts();
           DialogResult result = frmProducts.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliers frmSuppliers = new frmSuppliers();
            DialogResult result = frmSuppliers.ShowDialog();
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            frmPackages frmPackages = new frmPackages();
            DialogResult result = frmPackages.ShowDialog();
        }
    }
}
