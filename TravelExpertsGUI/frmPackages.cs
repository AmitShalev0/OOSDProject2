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
    public partial class frmPackages : Form
    {
        public frmPackages()
        {
            InitializeComponent();
        }

        private Package selectedPackage = null!;

        private void frmPackages_Load(object sender, EventArgs e)
        {
            loadList();
        }

        private void loadList()
        {
            dgvData.Columns.Clear();

            //determine which table and add data to the grid

            DisplayPackages();


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

        private void DisplayPackages()
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                //var query = from p in db.Products
                //            join ps in db.ProductsSuppliers on p.ProductId equals ps.ProductId
                //            join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                //            join pps in db.PackagesProductsSuppliers on ps.ProductSupplierId equals pps.ProductSupplierId
                //            join pk in db.Packages on pps.PackageId equals pk.PackageId
                //            select new
                //            {
                //                pk.PackageId,
                //                pk.PkgName,
                //                pk.PkgDesc,
                //                pk.PkgStartDate,
                //                pk.PkgEndDate,
                //                pk.PkgBasePrice,
                //                pk.PkgAgencyCommission,
                //                p.ProdName,
                //                s.SupName
                //            };

                            //dgvData.DataSource = query.ToList();


                var packages = from p in db.Packages
                               select new
                               {
                                   p.PackageId,
                                   p.PkgName,
                                   p.PkgDesc,
                                   p.PkgStartDate,
                                   p.PkgEndDate,
                                   p.PkgBasePrice,
                                   p.PkgAgencyCommission,
                               };

                dgvData.DataSource = packages.ToList();

                dgvData.Columns[0].HeaderText = "Package ID";
                dgvData.Columns[1].HeaderText = "Package Name";
                dgvData.Columns[2].HeaderText = "Description";
                dgvData.Columns[3].HeaderText = "Start Date";
                dgvData.Columns[4].HeaderText = "End Date";
                dgvData.Columns[5].HeaderText = "Base Price";
                dgvData.Columns[6].HeaderText = "Commission";
                //dgvData.Columns[7].HeaderText = "Product Name";
                //dgvData.Columns[8].HeaderText = "Supplier Name";

                dgvData.AutoResizeColumns();
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            const int MODIFY_INDEX = 7;
            const int DELETE_INDEX = 8;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                if (e.RowIndex > -1)//make sure header row wasn't clicked
                {
                    if (e.ColumnIndex == MODIFY_INDEX || e.ColumnIndex == DELETE_INDEX)
                    {
                        //find the productsupplierID for the relectes row and then find the productsupplier object
                        DataGridViewCell cell = dgvData.Rows[e.RowIndex].Cells[0];//get the first cell of the row
                        int PkCode = Convert.ToInt32(cell.Value);
                        selectedPackage = db.Packages.Find(PkCode);//the selected item
                    }
                    if (selectedPackage != null)
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

        private void DeletePS()
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete ProdustSupplier {selectedPackage.PackageId}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    // Delete related records in PackagesProductsSuppliers table
                    var relatedPPS = db.PackagesProductsSuppliers.Where(pps => pps.PackageId == selectedPackage.PackageId).ToList();
                    db.PackagesProductsSuppliers.RemoveRange(relatedPPS);

                    // Find and delete related bookings
                    var relatedBookings = db.Bookings.Where(b => b.PackageId == selectedPackage.PackageId).ToList();
                    db.Bookings.RemoveRange(relatedBookings);

                    db.Packages.Remove(selectedPackage);
                    db.SaveChanges();
                    loadList();
                }
            }
        }

        private void ModifyPS()
        {
            frmAddMofidyPackages frmAddMofidyPackages = new()
            {
                package = selectedPackage
            };
            DialogResult result = frmAddMofidyPackages.ShowDialog();

            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedPackage = frmAddMofidyPackages.package;
                    db.Packages.Update(selectedPackage);
                    db.SaveChanges();
                    loadList();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddMofidyPackages frmAddMofidyPackages = new();
            DialogResult result = frmAddMofidyPackages.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    selectedPackage = frmAddMofidyPackages.package;
                    db.Packages.Add(selectedPackage);
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
