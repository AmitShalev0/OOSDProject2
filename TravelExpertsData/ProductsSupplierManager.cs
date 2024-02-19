using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class ProductsSupplierManager
    {
        public static bool UniqueCombo(ProductsSupplier PS)
        {
            
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                bool isUnique = true;
                List<ProductsSupplier> productsSuppliers = db.ProductsSuppliers.ToList();
                foreach (ProductsSupplier p in productsSuppliers)
                {
                    if (p.ProductId == PS.ProductId && p.SupplierId==PS.SupplierId)
                    {
                        isUnique = false;
                    }
                }
            return isUnique;
            }
            
        }
    }
}
