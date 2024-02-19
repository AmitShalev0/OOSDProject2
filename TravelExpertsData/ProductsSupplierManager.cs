using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class ProductsSupplierManager
    {
        /// <summary>
        /// checks to see if the product and supplier combo already exist
        /// </summary>
        /// <param name="PS">productsupplier object</param>
        /// <returns>true is it's unique false if it already exists</returns>
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

        /// <summary>
        /// checks to see if the type of product is already in this package
        /// </summary>
        /// <param name="packageId">package ID</param>
        /// <param name="productId">product ID</param>
        /// <returns>true if it already exists</returns>
        public static bool ProductExists (int packageId, int productId)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {

                return db.PackagesProductsSuppliers.Any(pps => pps.PackageId == packageId && pps.ProductSupplier.ProductId == productId);

            }
                
        }
    }
}
