using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class BookingManager
    {
        public static void AddBooking(TravelExpertsContext db, int? custId, int PkgId, int? NoOfPassengers)
        {
            Booking booking = new Booking();
            booking.BookingDate = DateTime.Now;
            booking.TravelerCount = NoOfPassengers;
            booking.CustomerId = custId;
            booking.PackageId = PkgId;
            db.Bookings.Add(booking);
            db.SaveChanges();
        }
    }
}
