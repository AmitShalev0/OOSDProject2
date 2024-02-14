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

        //public static List<BookingDetailsDTO> GetDetails(TravelExpertsContext db, int bkngId)
        //{

        //    List<BookingDetailsDTO> bookingDetails;
        //    bookingDetails = (from b in db.Bookings
        //                      join bd in db.BookingDetails
        //                      on b.BookingId equals bd.BookingId
        //                      join r in db.Regions
        //                      on bd.RegionId equals r.RegionId
        //                      where bd.BookingId == bkngId
        //                      select new BookingDetailsDTO
        //                      {
        //                          BookingDetailId = bd.BookingDetailId,
        //                          ItineraryNo = bd.ItineraryNo,
        //                          RegionName = r.RegionName,
        //                          Description = bd.Description,
        //                          Destination = bd.Destination
        //                      }).ToList();

        //    return bookingDetails;
        //}

        public static Booking GetBookingById (TravelExpertsContext db, int id)
        {
            Booking booking = db.Bookings.Find(id);
            return booking;
        }

        public static void UpdateBooking(TravelExpertsContext db, int id, Booking newBooking)
        {
            Booking? booking = db.Bookings.Find(id);
            if (booking != null)
            {
                //booking.BookingNo = newBooking.BookingNo;
                //booking.BookingDate = newBooking.BookingDate;
                //booking.BookingDetails = newBooking.BookingDetails;
                booking.TravelerCount = newBooking.TravelerCount;
                booking.TripTypeId = newBooking.TripTypeId;
                //booking.PackageId = newBooking.PackageId;
                //booking.CustomerId = newBooking.CustomerId;
                db.SaveChanges();
            }
        }

        public static void DeleteBooking (TravelExpertsContext db, int id)
        {
            Booking? booking = db.Bookings.Find(id);
            if (booking != null)
            {
                db.Bookings.Remove(booking);
                db.SaveChanges();
            }
        }
    }
}
