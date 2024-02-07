using TravelExpertsData;

namespace TravelExpertsGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext() )
            {
                dgvData.DataSource = db.PackagesProductsSuppliers.ToList();
            }
        }
    }
}
