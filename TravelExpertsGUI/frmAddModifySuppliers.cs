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
    public partial class frmAddModifySuppliers : Form
    {
        public frmAddModifySuppliers()
        {
            InitializeComponent();
        }

        //a public property for a PS entity
        public Supplier supplier { get; set; } = null!;

        private void frmAddModifySuppliers_Load(object sender, EventArgs e)
        {
            if (supplier == null) //it's Add function
            {
                Text = "Add";
                supplier = new();
            }
            else
            {
                Text = "Modify";
                DisplayProduct();
            }
        }

        private void DisplayProduct()
        {
            txtSupplierID.Text = supplier.SupplierId.ToString();
            txtSupplierName.Text = supplier.SupName.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            getData();
            DialogResult = DialogResult.OK;
        }

        private void getData()
        {
            if (supplier != null)
            {
                supplier.SupplierId = Convert.ToInt32(txtSupplierID.Text);
                supplier.SupName = txtSupplierName.Text;
            }
        }
    }
}
