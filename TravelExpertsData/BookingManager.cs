using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsData.Migrations;

namespace TravelExpertsData
{
    public static class BookingManager
    {
        public static void AddBooking(TravelExpertsContext db, int? custId, int PkgId, int? NoOfPassengers, string tripType)
        {
            Booking booking = new Booking();
            booking.BookingDate = DateTime.Now;
            booking.TravelerCount = NoOfPassengers;
            booking.CustomerId = custId;
            booking.PackageId = PkgId;
            booking.TripTypeId = tripType;
            db.Bookings.Add(booking);
            db.SaveChanges();
        }

        public static List<BookingDTO> GetBookingsByCustomer(TravelExpertsContext db, int? customerId)
        {
            List<BookingDTO> bookings;
            bookings = (from b in db.Bookings
                        join p in db.Packages
                        on b.PackageId equals p.PackageId
                        join c in db.Customers
                        on b.CustomerId equals c.CustomerId
                        where c.CustomerId == customerId
                        select new BookingDTO
                        {
                            BookingId = b.BookingId,
                            BookingDate = b.BookingDate,
                            PkgName = p.PkgName,
                            PkgStartDate = p.PkgStartDate,
                            PkgEndDate = p.PkgEndDate,
                            PkgDesc = p.PkgDesc,
                            PkgBasePrice = p.PkgBasePrice,
                            PkgAgencyCommission = p.PkgAgencyCommission,
                            TravelerCount = b.TravelerCount
                        }).ToList();

            return bookings;
        }
    }
}
