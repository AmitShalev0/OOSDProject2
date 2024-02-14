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
        //    var products = BookingManager.GetDetails(_db!, id);
        //    return View(products);
        //}

        // GET: BookingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BookingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
