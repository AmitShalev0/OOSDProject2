using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertsData;
using TravelExpertsData.Migrations;

namespace TravelExpertsMVC.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        //constructor for the controller for injecting the context db
        private TravelExpertsContext? _db { get; set; }
        //added constructor
        public BookingController(TravelExpertsContext db) { _db = db; }

        [Authorize]
        public ActionResult MyBookings()//gets the packages of a certain customer
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            ViewBag.Total = PackagesManager.GetTotal(_db!, customerId);

            List<BookingDTO> bookings = BookingManager.GetBookingsByCustomer(_db!, customerId);
            return View(bookings);
        }

        // GET: BookingController/Details/5
        //public ActionResult Details(int id)
        //{
        //    var details = BookingManager.GetDetails(_db!, id);
        //    return View(details);
        //}


        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            Booking booking;
            booking = BookingManager.GetBookingById(_db!, id);
            if (booking != null)
                return View(booking);
            else
                return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Booking newBooking)
        {
            if (ModelState.IsValid)
            {
                if (id != 0)
                {
                    try
                    {
                        BookingManager.UpdateBooking(_db!, id, newBooking);
                        TempData["Message"] = $"Successfully updated edited booking {id}";
                    }
                    catch (Exception)
                    {
                        TempData["message"] = $"Problem with editing booking {id}";
                        TempData["IsError"] = true;
                    }
                }
                return RedirectToAction("MyBookings");
            }
            else
            {
                return View(newBooking);
            }
        }

        // GET: BookingController/Delete/5
        public ActionResult Delete(int id)
        {
            Booking booking = null;
            //as for confirm to delete
            try
            {
                booking = BookingManager.GetBookingById(_db!, id);
                if (booking != null)
                {
                    TempData["BookingID"] = booking.BookingId;
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
            }
            return View(booking);
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Booking booking)
        {
            int oldId=0;

            if (TempData["BookingID"] != null)
            {
                oldId = Convert.ToInt32(TempData["BookingID"]);
            }
            try
            {
                BookingManager.DeleteBooking(_db!, id);
                TempData["Message"] = $"Successfully deleted booking {oldId.ToString()}";

                return RedirectToAction("MyBookings");
            }
            catch
            {
                TempData["Message"] = $"Problem with deleting movie {oldId.ToString()}";
                TempData["IsError"] = true;
                return View(booking);
            }
        }
    }
}

        

