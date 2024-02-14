using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExpertsData;
using TravelExpertsData.Migrations;

namespace TravelExpertsMVC.Controllers
{
    public class BookingController : Controller
    {
        //constructor for the controller for injecting the context db
        private TravelExpertsContext? _db { get; set; }
        //added constructor
        public BookingController(TravelExpertsContext db) { _db = db; }

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
                        TempData["Message"] = $"Successfully updated edited booking {newBooking.BookingId}";
                    }
                    catch (Exception)
                    {
                        TempData["message"] = $"Problem with editing movie booking {newBooking.BookingId}";
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
            return View();
        }

        // POST: BookingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

        

