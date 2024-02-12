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
    public partial class frmAddMofidyPackages : Form
    {
        public frmAddMofidyPackages()
        {
            InitializeComponent();
        }

        //a public property for a PS entity
        public Package package { get; set; } = null!;
        public Product product { get; set; } = null!;

        public Supplier supplier { get; set; } = null!;

        //public PackagesProductsSupplier PPS { get; set; } = null!;

        public PackagesProductsSupplier PPS = new PackagesProductsSupplier();



        private void frmAddMofidyPackages_Load(object sender, EventArgs e)
        {
            if (package == null) //it's Add function
            {
                Text = "Add";
                txtPackageID.Enabled = false;
                package = new();
            }
            else
            {
                txtPackageID.Enabled = false;
                Text = "Modify";
                DisplayPackage();
                DisplayProductsWithPackage();
            }
        }

        private void DisplayPackage()
        {
            txtPackageID.Text = package.PackageId.ToString();
            txtPackageName.Text = package.PkgName.ToString();
            txtDescription.Text = package.PkgDesc.ToString();
            txtCommission.Text = package.PkgAgencyCommission.ToString();
            txtBasePrice.Text = package.PkgBasePrice.ToString();
            dtpStartDate.Value = package.PkgStartDate.Value;
            dtpEndDate.Value = package.PkgEndDate.Value;
        }

        private void DisplayProductsWithPackage()
        {
            dgvCurrentProducts.Columns.Clear();
            dgvProductsToAdd.Columns.Clear();

            //display current products of this package
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                int packageIdToFilter = package.PackageId;

                var query = from p in db.Products
                            join ps in db.ProductsSuppliers on p.ProductId equals ps.ProductId
                            join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                            join pps in db.PackagesProductsSuppliers on ps.ProductSupplierId equals pps.ProductSupplierId
                            join pk in db.Packages on pps.PackageId equals pk.PackageId
                            where pk.PackageId == packageIdToFilter
                            select new
                            {
                                p.ProdName,
                                s.SupName
                            };

                dgvCurrentProducts.DataSource = query.ToList();

                dgvCurrentProducts.Columns[0].HeaderText = "Product Name";
                dgvCurrentProducts.Columns[1].HeaderText = "Supplier Name";

                dgvCurrentProducts.AutoResizeColumns();



                //display other available products

                var query2 = from p in db.Products
                             join ps in db.ProductsSuppliers on p.ProductId equals ps.ProductId
                             join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                             join pps in db.PackagesProductsSuppliers on ps.ProductSupplierId equals pps.ProductSupplierId into ppsGroup
                             from pps in ppsGroup.DefaultIfEmpty()  // Left join
                             where pps == null || pps.PackageId != packageIdToFilter
                             select new
                             {
                                 p.ProductId,
                                 p.ProdName,
                                 s.SupplierId,
                                 s.SupName
                             };

                dgvProductsToAdd.DataSource = query2.ToList();

                dgvProductsToAdd.Columns[0].HeaderText = "Product ID";
                dgvProductsToAdd.Columns[1].HeaderText = "Product Name";
                dgvProductsToAdd.Columns[2].HeaderText = "Supplier ID";
                dgvProductsToAdd.Columns[3].HeaderText = "Supplier Name";

                dgvProductsToAdd.AutoResizeColumns();

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            getData();
            DialogResult = DialogResult.OK;
        }

        private void getData()
        {
            if (package != null)
            {
                package.PkgName = txtPackageName.Text;
                package.PkgDesc = txtDescription.Text;
                package.PkgAgencyCommission = Convert.ToDecimal(txtCommission.Text);
                package.PkgBasePrice = Convert.ToDecimal(txtBasePrice.Text);
                package.PkgStartDate = dtpStartDate.Value;
                package.PkgEndDate = dtpEndDate.Value;
            }
        }



        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                //add a new item to the PackagesProductsSupplier table
                db.PackagesProductsSuppliers.Add(PPS);
                db.SaveChanges();

                DisplayProductsWithPackage();
            }
        }

        private void dgvProductsToAdd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                DataGridViewCell cell = dgvProductsToAdd.Rows[e.RowIndex].Cells[0];//get  productID
                int ProductCode = Convert.ToInt32(cell.Value);

                cell = dgvProductsToAdd.Rows[e.RowIndex].Cells[2];//get supplierID
                int SupplierCode = Convert.ToInt32(cell.Value);

                product = db.Products.Find(ProductCode);//the selected product
                supplier = db.Suppliers.Find(SupplierCode); //the selected supplier


                //find the productsupplierID based on the product and supplier

                int productSupplierId = db.ProductsSuppliers
                    .Where(ps => ps.ProductId == ProductCode && ps.SupplierId == SupplierCode)
                    .Select(ps => ps.ProductSupplierId)
                    .FirstOrDefault();

                //create the PPS object
                PPS = new PackagesProductsSupplier();
                PPS.ProductSupplierId = productSupplierId;
                PPS.PackageId = package.PackageId;

            }

        }

    }
}
