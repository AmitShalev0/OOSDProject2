using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravelExpertsMaintenance
{
    public partial class frmAddModifyPS : Form
    {
        //a public property for a PS entity
        public ProductsSupplier productsSupplier { get; set; } = null!;
        //ProductsSupplier PS;

        public frmAddModifyPS()
        {
            InitializeComponent();
        }

        //load product name and supplier name into comboboxes
        private void frmAddModify_Load_1(object sender, EventArgs e)
        {
            //loading the combo boxes
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                cboProduct.DataSource = db.Products.ToList();
                cboProduct.DisplayMember = "ProdName".ToString();
                cboProduct.ValueMember = "ProductId";


                cboSupplier.DataSource = db.Suppliers.ToList();
                cboSupplier.DisplayMember = "SupName".ToString();
                cboSupplier.ValueMember = "SupplierId";


                if (productsSupplier == null) //it's Add function
                {
                    Text = "Add";
                    txtProductSupplierID.ReadOnly = true;

                    productsSupplier = new();
                }
                else
                {
                    Text = "📝";
                    txtProductSupplierID.ReadOnly = true;
                    DisplayProductSupplier();
                }



            }

        }

        private void DisplayProductSupplier()
        {
            txtProductSupplierID.Text = productsSupplier.ProductSupplierId.ToString();
            cboProduct.SelectedValue = productsSupplier.ProductId;
            cboSupplier.SelectedValue = productsSupplier.SupplierId;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            getData();
            if (ProductsSupplierManager.UniqueCombo(productsSupplier))//combo is unique
                {
                    DialogResult = DialogResult.OK;
                }
            else
                {
                    MessageBox.Show("This Product and Supplier combination already exists.");
                    return;
                }
                
        }

        private void getData()
        {
            
            if (productsSupplier != null)
            {
                productsSupplier.ProductId = Convert.ToInt32(cboProduct.SelectedValue);
                productsSupplier.SupplierId = Convert.ToInt32(cboSupplier.SelectedValue);
            }

        }


    }
}
