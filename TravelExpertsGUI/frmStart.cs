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
            //frmProductsSupplier frmProductsSupplier = new frmProductsSupplier();
            //DialogResult result = frmProductsSupplier.ShowDialog();

            // Create an instance of frmProducts
            frmProductsSupplier productsSupplierForm = new frmProductsSupplier();
            //productsSupplierForm.FormBorderStyle = FormBorderStyle.None;

            // Call the OpenFormInPanel method to open frmProducts within a panel
            TravelExpertsGUI.PanelAction.OpenFormInPanel.openFormInPanel(this, productsSupplierForm, pnlForms);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            //frmProducts frmProducts = new frmProducts();
            //DialogResult result = frmProducts.ShowDialog();

            // Create an instance of frmProducts
            frmProducts productsForm = new frmProducts();
            productsForm.FormBorderStyle = FormBorderStyle.None;

            // Call the OpenFormInPanel method to open frmProducts within a panel
            TravelExpertsGUI.PanelAction.OpenFormInPanel.openFormInPanel(this, productsForm, pnlForms);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            //frmSuppliers frmSuppliers = new frmSuppliers();
            //DialogResult result = frmSuppliers.ShowDialog();

            // Create an instance of frmProducts
            frmSuppliers suppliersForm = new frmSuppliers();
            suppliersForm.FormBorderStyle = FormBorderStyle.None;

            // Call the OpenFormInPanel method to open frmProducts within a panel
            TravelExpertsGUI.PanelAction.OpenFormInPanel.openFormInPanel(this, suppliersForm, pnlForms);
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            //frmPackages frmPackages = new frmPackages();
            //DialogResult result = frmPackages.ShowDialog();

            // Create an instance of frmProducts
            frmPackages packagesForm = new frmPackages();
            packagesForm.FormBorderStyle = FormBorderStyle.None;

            // Call the OpenFormInPanel method to open frmProducts within a panel
            TravelExpertsGUI.PanelAction.OpenFormInPanel.openFormInPanel(this, packagesForm, pnlForms);
        }
    }
}
