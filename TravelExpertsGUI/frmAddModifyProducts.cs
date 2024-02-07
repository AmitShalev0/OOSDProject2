using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace TravelExpertsMaintenance
{
    public partial class frmAddModifyProducts : Form
    {
        public frmAddModifyProducts()
        {
            InitializeComponent();
        }
        //a public property for a PS entity
        public Product product { get; set; } = null!;

        private void frmAddModifyProducts_Load(object sender, EventArgs e)
        {
            if (product == null) //it's Add function
            {
                Text = "Add";
                btnOk.Text = "Add Product";
                txtProductID.Enabled = false;
                txtProductName.Focus();

                product = new();
            }
            else
            {
                Text = "Modify";
                btnOk.Text = "Modify Product";
                txtProductID.Enabled = false;
                DisplayProduct();
            }
        }

        private void DisplayProduct()
        {
            txtProductID.Text = product.ProductId.ToString();
            txtProductName.Text = product.ProdName.ToString();
            txtProductName.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            getData();
            DialogResult = DialogResult.OK;
        }

        private void getData()
        {
            if (product != null)
            {
                product.ProdName = txtProductName.Text;
            }
        }
    }
}
