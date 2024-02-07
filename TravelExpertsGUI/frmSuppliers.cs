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
    public partial class frmSuppliers : Form
    {
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private Supplier selectedSupplier = null!;

        private void frmSuppliers_Load(object sender, EventArgs e)
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

                var supplier = db.Suppliers.Select(s => new
                {
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupName
                }).ToList();

                dgvData.DataSource = supplier;

                dgvData.Columns[0].HeaderText = "Product ID";
                dgvData.Columns[1].HeaderText = "Product Name";

                dgvData.AutoResizeColumns();

            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //index values for Modify and Delete button columns
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
                        int SCode = Convert.ToInt32(cell.Value);
                        selectedSupplier = db.Suppliers.Find(SCode);//the selected item

                        dgvData.Refresh();
                    }
                    if (selectedSupplier != null)
                    {
                        if (e.ColumnIndex == MODIFY_INDEX)
                        {
                            ModifySupplier();
                        }
                        else if (e.ColumnIndex == DELETE_INDEX)
                        {
                            DeleteSupplier();
                        }
                    }
                }
            }
        }

        private void ModifySupplier()
        {
            frmAddModifySuppliers frmAddModifySuppliers = new()
            {
                supplier = selectedSupplier
            };
            DialogResult result = frmAddModifySuppliers.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedSupplier = frmAddModifySuppliers.supplier;
                    db.Suppliers.Update(selectedSupplier);
                    db.SaveChanges();
                    loadList();
                }
            }
        }

        private void DeleteSupplier()
        {
            DialogResult result = MessageBox.Show(
                          $"Are you sure you want to delete ProdustSupplier {selectedSupplier.SupplierId}?",
                          "Confirm Delete", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    db.Suppliers.Remove(selectedSupplier);
                    db.SaveChanges();
                    selectedSupplier = null;
                    loadList();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifySuppliers frmAddModifySuppliers = new();
            DialogResult result = frmAddModifySuppliers.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedSupplier = frmAddModifySuppliers.supplier;
                    db.Suppliers.Add(selectedSupplier);
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
