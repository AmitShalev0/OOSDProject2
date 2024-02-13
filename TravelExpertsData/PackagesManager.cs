using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class PackagesManager
    {
        public static List<PackagesDTO> GetPackages(TravelExpertsContext db) //get all packages
        {
            List<PackagesDTO> packages;
            packages = (from p in db.Packages
                        select new PackagesDTO
                        {
                            PackageId = p.PackageId,
                            PkgName = p.PkgName,
                            PkgStartDate = p.PkgStartDate,
                            PkgEndDate = p.PkgEndDate,
                            PkgDesc = p.PkgDesc,
                            PkgBasePrice = p.PkgBasePrice,
                            PkgAgencyCommission = p.PkgAgencyCommission,
                        }
                        ).ToList();
            return packages;
        }

        public static List<PackagesDTO> GetAvailablePackages(TravelExpertsContext db, int? id)//customer's id
        {
            List<PackagesDTO> packages;
            packages = (from p in db.Packages
                        join b in db.Bookings on p.PackageId equals b.PackageId into packageBookings
                        from pb in packageBookings.DefaultIfEmpty()
                        where pb == null || pb.CustomerId != id
                        select new PackagesDTO
                        {
                            PackageId = p.PackageId,
                            PkgName = p.PkgName,
                            PkgStartDate = p.PkgStartDate,
                            PkgEndDate = p.PkgEndDate,
                            PkgDesc = p.PkgDesc,
                            PkgBasePrice = p.PkgBasePrice,
                            PkgAgencyCommission = p.PkgAgencyCommission,
                        }).Distinct().ToList();
            return packages;
        }

        /// <summary>
        /// retrieve the packages of a certain customer
        /// </summary>
        /// <param name="db">context</param>
        /// <param name="customerId">the logged in customer's id</param>
        /// <returns>packages in the customer's account</returns>
        public static List<PackagesDTO> GetPackagesByCustomer(TravelExpertsContext db, int? customerId)
        {
            List<PackagesDTO> packages;
            packages = (from p in db.Packages
                        join b in db.Bookings
                        on p.PackageId equals b.PackageId
                        join c in db.Customers
                        on b.CustomerId equals c.CustomerId
                        where c.CustomerId == customerId
                        select new PackagesDTO
                        {
                            PackageId = p.PackageId,
                            PkgName = p.PkgName,
                            PkgStartDate = p.PkgStartDate,
                            PkgEndDate = p.PkgEndDate,
                            PkgDesc = p.PkgDesc,
                            PkgBasePrice = p.PkgBasePrice,
                            PkgAgencyCommission = p.PkgAgencyCommission,
                        }

                        ).ToList();
            return packages;
        }

        public static decimal GetTotal(TravelExpertsContext db, int? custId)
        {
            decimal total = 0;
            // Fetch packages from the database
            var packages = (from p in db.Packages
                            join b in db.Bookings on p.PackageId equals b.PackageId
                            join c in db.Customers on b.CustomerId equals c.CustomerId
                            where c.CustomerId == custId
                            select new PackagesDTO
                            {
                                PackageId = p.PackageId,
                                PkgName = p.PkgName,
                                PkgStartDate = p.PkgStartDate,
                                PkgEndDate = p.PkgEndDate,
                                PkgDesc = p.PkgDesc,
                                PkgBasePrice = p.PkgBasePrice,
                                PkgAgencyCommission = p.PkgAgencyCommission
                            }).ToList();

            // Calculate the total PkgBasePrice
            decimal totalBasePrice = packages.Sum(p => p.PkgBasePrice);
            // Calculate the total PkgAgencyCommission, handle null values by providing a default value of 0
            decimal totalCommissionPrice = packages.Sum(p => p.PkgAgencyCommission ?? 0);

            total = totalBasePrice + totalCommissionPrice;

            return total;
        }

        public static List<ProductDTO> GetDetails (TravelExpertsContext db, int pkgId)//get the details for a particular package
        {

            List<ProductDTO> products  = (from p in db.Products
                                       join ps in db.ProductsSuppliers on p.ProductId equals ps.ProductId
                                       join pps in db.PackagesProductsSuppliers on ps.ProductSupplierId equals pps.ProductSupplierId
                                       join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                                       where pps.PackageId == pkgId
                                       select new ProductDTO
                                       {
                                            ProdName= p.ProdName,
                                            SupName = s.SupName,

                                       }
                                       ).ToList();


            return products;
        } 
    }
}
