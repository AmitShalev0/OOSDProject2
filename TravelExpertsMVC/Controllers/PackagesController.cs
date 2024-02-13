using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelExpertsData;

namespace TravelExpertsMVC.Controllers
{
    [Authorize]
    public class PackagesController : Controller
    {
        //constructor for the controller for injecting the context db
        private TravelExpertsContext? _db { get; set; }
        //added constructor
        public PackagesController(TravelExpertsContext db) { _db = db; } //when the Packagescontrolelr is created it will get the context

        // GET: PackagesController
        public ActionResult MyPackages()//gets the packages of a certain customer
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            ViewBag.Total = PackagesManager.GetTotal(_db!, customerId);

            List<PackagesDTO> packages = PackagesManager.GetPackagesByCustomer(_db!, customerId);
            return View(packages);
        }

        [AllowAnonymous]
        public ActionResult AvailablePackages()//get all the available packages for a certain custoemr
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();
            ViewBag.TravellersCount = new SelectList(numbers);//load the drop-down list
            List<TripType> tripTypes = TripTypeManager.GetTripTypes(_db!);
            var ttypes = new SelectList(tripTypes, "TripTypeId", "Ttname").ToList();
            ViewBag.TravelTypes = ttypes;

            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            if (customerId == null)//if guest show all packages
            {
                List<PackagesDTO> Allpackages = PackagesManager.GetPackages(_db!);
                return View(Allpackages);
            }
            else//if customer show all packages that they already haven't purchased
            {
                List<PackagesDTO> packages = PackagesManager.GetAvailablePackages(_db!, customerId);
                return View(packages);
            }  
        }

        [HttpPost]
        public ActionResult AvailablePackages(IFormCollection form,int[] selectedPackages)//picks the id from the form
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();
            ViewBag.TravellersCount = new SelectList(numbers);//load the drop-down list
            List<TripType> tripTypes = TripTypeManager.GetTripTypes(_db!);
            var ttypes = new SelectList(tripTypes, "TripTypeId", "Ttname").ToList();
            ViewBag.TravelTypes = ttypes;
            int? NoOfPassengers = Convert.ToInt32(form["TravellersCount"]);//get the number of passengers
            string tripType = form["TravelTypes"].ToString();//get the trip type

            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            List<PackagesDTO> packages = PackagesManager.GetAvailablePackages(_db!, customerId);

            if (selectedPackages != null && selectedPackages.Length >0)//package was selected
            {
                if (NoOfPassengers.HasValue && NoOfPassengers > 0 && NoOfPassengers <= 10)//a valid number was selected
                {
                    foreach (int PackageId in selectedPackages)//add the packages
                    {
                        BookingManager.AddBooking(_db!, customerId, PackageId, NoOfPassengers, tripType);
                    }
                    return RedirectToAction("MyPackages");
                }
                else
                {
                    ViewBag.ErrorMessage = "Please select a valid number from the dropdown list.";
                    return View(packages);
                }
   
            }
            return View(packages);
        }




        // GET: PackagesController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var products = PackagesManager.GetDetails(_db!, id);
            return View(products);
        }

        public ActionResult GetAvailablePackages()//packages that are not already in customer's account
        {
            return View();
        }





        //// GET: PackagesController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PackagesController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PackagesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PackagesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PackagesController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PackagesController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
