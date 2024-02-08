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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private Product selectedProduct = null!;

        private void frmProducts_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void loadList()
        {

            dgvData.Columns.Clear();

            //determine which table and add data to the grid

            DisplayProducts();


            //add column for modify button
            DataGridViewButtonColumn modifyColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvData.Columns.Add(modifyColumn);


            // add column for delete button
            DataGridViewButtonColumn deleteColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Delete"
            };
            dgvData.Columns.Add(deleteColumn);

        }

        private void DisplayProducts()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {

                //dgvData.DataSource = db.Products.ToList();

                //dgvData.Columns[0].HeaderText = "Product ID";
                //dgvData.Columns[1].HeaderText = "Product Name";

                //dgvData.AutoResizeColumns();

                var products = db.Products.Select(p => new
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProdName
                }).ToList();

                dgvData.DataSource = products;

                dgvData.Columns[0].HeaderText = "Product ID";
                dgvData.Columns[1].HeaderText = "Product Name";

                dgvData.AutoResizeColumns();

            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // index values for Modify and Delete button columns
            const int MODIFY_INDEX = 2;
            const int DELETE_INDEX = 3;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                if (e.RowIndex > -1)//make sure header row wasn't clicked
                {
                    if (e.ColumnIndex == MODIFY_INDEX || e.ColumnIndex == DELETE_INDEX)
                    {
                        //find the productsupplierID for the relectes row and then find the productsupplier object
                        DataGridViewCell cell = dgvData.Rows[e.RowIndex].Cells[0];//get the first cell of the row
                        int PCode = Convert.ToInt32(cell.Value);
                        selectedProduct = db.Products.Find(PCode);//the selected item

                        dgvData.Refresh();
                    }
                    if (selectedProduct != null)
                    {
                        if (e.ColumnIndex == MODIFY_INDEX)
                        {
                            ModifyProduct();
                        }
                        else if (e.ColumnIndex == DELETE_INDEX)
                        {
                            DeleteProduct();
                        }
                    }
                }
            }
        }

        private void DeleteProduct()
        {
            DialogResult result = MessageBox.Show(
               $"Are you sure you want to delete ProdustSupplier {selectedProduct.ProductId}?",
               "Confirm Delete", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    //List<Product> products = db.Products.ToList();
                    //List<ProductsSupplier> deletingProducts = new List<ProductsSupplier>();
                    //foreach (Product product in products)
                    //{
                    //    ProductsSupplier attachedproducts = new ProductsSupplier();
                    //    attachedproducts.ProductId = selectedProduct.ProductId;
                    //    var entityToRemove = db.ProductsSuppliers.FirstOrDefault( ps => ps.ProductId == attachedproducts.ProductId);
                    //    if (entityToRemove != null)
                    //    {
                    //        db.ProductsSuppliers.Remove(entityToRemove);
                    //        db.SaveChanges();
                    //    }
                    //}


                    //db.Products.Remove(selectedProduct);

                    
                    // Retrieve the IDs of related entities
                    var productSupplierIds = db.ProductsSuppliers
                        .Where(ps => ps.ProductId == selectedProduct.ProductId)
                        .Select(ps => ps.ProductSupplierId)
                        .ToList();

                    // Retrieve related booking details
                    var bookingDetails = db.BookingDetails
                        .Where(bd => bd.ProductSupplierId != null && productSupplierIds.Contains(bd.ProductSupplierId.Value))
                        .ToList();

                    // Delete related booking details
                    db.BookingDetails.RemoveRange(bookingDetails);

                    // Retrieve related entities in PackagesProductsSuppliers
                    var packagesProductsSuppliers = db.PackagesProductsSuppliers
                        .Where(pps => productSupplierIds.Contains(pps.ProductSupplierId))
                        .ToList();

                    // Delete related entities in PackagesProductsSuppliers
                    db.PackagesProductsSuppliers.RemoveRange(packagesProductsSuppliers);

                    // Delete related entities in ProductsSuppliers
                    db.ProductsSuppliers.RemoveRange(db.ProductsSuppliers.Where(ps => ps.ProductId == selectedProduct.ProductId));

                    // Delete the selected product
                    db.Products.Remove(selectedProduct);

                    db.SaveChanges();
                    selectedProduct = null;
                    loadList();
                }
            }
        }

        private void ModifyProduct()
        {
            frmAddModifyProducts frmAddModifyProducts = new()
            {
                product = selectedProduct
            };
            DialogResult result = frmAddModifyProducts.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedProduct = frmAddModifyProducts.product;
                    db.Products.Update(selectedProduct);
                    db.SaveChanges();
                    loadList();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyProducts frmAddModifyProducts = new();
            DialogResult result = frmAddModifyProducts.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedProduct = frmAddModifyProducts.product;
                    db.Products.Add(selectedProduct);
                    db.SaveChanges();
                    loadList();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
