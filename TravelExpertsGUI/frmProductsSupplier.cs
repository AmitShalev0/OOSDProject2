using TravelExpertsData;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TravelExpertsMaintenance
{
    public partial class frmProductsSupplier : Form
    {
        public int? whichTable;
        private ProductsSupplier selectedPS = null!;


        public frmProductsSupplier()
        {
            InitializeComponent();
        }

        //when the form loads 
        private void frmMain_Load(object sender, EventArgs e)
        {
            //loadTables();
            loadList();
        }

        private void loadList()
        {
            dgvData.Columns.Clear();

            //determine which table and add data to the grid

                DisplayProductsSupplier();


            //add column for modify button
            DataGridViewButtonColumn modifyColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "Modify",
                Text = "Modify"
            };
            dgvData.Columns.Add(modifyColumn);


            // add column for delete button
            DataGridViewButtonColumn deleteColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "Delete",
                Text = "Delete"
            };
            dgvData.Columns.Add(deleteColumn);
        }

        private void DisplayProductsSupplier()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                var query = from ps in db.ProductsSuppliers
                            join p in db.Products on ps.ProductId equals p.ProductId
                            join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                            select new
                            {
                                ps.ProductSupplierId,
                                p.ProductId,
                                p.ProdName,
                                s.SupplierId,
                                s.SupName
                            };
                // Order the results by ProductsSupplierID
                query = query.OrderBy(item => item.ProductSupplierId);

                dgvData.DataSource = query.ToList();

                dgvData.Columns[0].HeaderText = "Product Supplier ID";
                dgvData.Columns[1].HeaderText = "Product ID";
                dgvData.Columns[2].HeaderText = "Product Name";
                dgvData.Columns[3].HeaderText = "Supplier ID";
                dgvData.Columns[4].HeaderText = "Supplier Name";


                dgvData.AutoResizeColumns();

            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            // index values for Modify and Delete button columns
            const int MODIFY_INDEX = 5;
            const int DELETE_INDEX = 6;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                if (e.RowIndex > -1)//make sure header row wasn't clicked
                {
                    if (e.ColumnIndex == MODIFY_INDEX || e.ColumnIndex == DELETE_INDEX)
                    {
                        //find the productsupplierID for the relectes row and then find the productsupplier object
                        DataGridViewCell cell = dgvData.Rows[e.RowIndex].Cells[0];//get the first cell of the row
                        int PSCode = Convert.ToInt32(cell.Value);
                        selectedPS = db.ProductsSuppliers.Find(PSCode);//the selected item
                    }
                    if (selectedPS != null)
                    {
                        if (e.ColumnIndex == MODIFY_INDEX)
                        {
                            ModifyPS();
                        }
                        else if (e.ColumnIndex == DELETE_INDEX)
                        {
                            DeletePS();
                        }
                    }
                }
            }
        }

        private void ModifyPS()
        {
            frmAddModifyPS frmAddModifyPS = new()
            {
                productsSupplier = selectedPS
            };
            DialogResult result = frmAddModifyPS.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedPS = frmAddModifyPS.productsSupplier;
                    db.ProductsSuppliers.Update(selectedPS);
                    db.SaveChanges();
                    loadList();
                }
            }
        }
        private void DeletePS()
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete ProdustSupplier {selectedPS.ProductSupplierId}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    db.ProductsSuppliers.Remove(selectedPS);
                    db.SaveChanges();
                    loadList();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyPS frmAddModifyPS = new();
            DialogResult result = frmAddModifyPS.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedPS = frmAddModifyPS.productsSupplier;
                    db.ProductsSuppliers.Add(selectedPS);
                    db.SaveChanges();
                    loadList();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }//form class
}//namespace
