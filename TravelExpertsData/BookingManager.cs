using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
