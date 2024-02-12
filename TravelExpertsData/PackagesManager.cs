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
        public static List<PackagesDTO> GetPackages(TravelExpertsContext db)
        {
            List<PackagesDTO> packages;
            packages = (from p in db.Packages
                        select new PackagesDTO
                        {
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
                                PkgName = p.PkgName,
                                PkgStartDate = p.PkgStartDate,
                                PkgEndDate = p.PkgEndDate,
                                PkgDesc = p.PkgDesc,
                                PkgBasePrice = p.PkgBasePrice,
                                PkgAgencyCommission = p.PkgAgencyCommission,
                            }).ToList();
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
    }
}
