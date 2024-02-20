using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelExpertsData;

namespace TravelExpertsMVC.Controllers
{
    
    public class PackagesController : Controller
    {
        //constructor for the controller for injecting the context db
        private TravelExpertsContext? _db { get; set; }
        //added constructor
        public PackagesController(TravelExpertsContext db) { _db = db; } //when the Packagescontrolelr is created it will get the context

        //// GET: PackagesController
        //public ActionResult MyPackages()//gets the packages of a certain customer
        //{
        //    int? customerId = HttpContext.Session.GetInt32("CustomerId");
        //    ViewBag.Total = PackagesManager.GetTotal(_db!, customerId);

        //    List<PackagesDTO> packages = PackagesManager.GetPackagesByCustomer(_db!, customerId);
        //    return View(packages);
        //}

        
        public ActionResult AvailablePackages()//get all the available packages for a certain custoemr
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();
            ViewBag.TravellersCount = new SelectList(numbers);//load the drop-down list
            try
            {
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
            catch
            {

                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
                return View();
            } 
        }

        [Authorize]
        [HttpPost]
        public ActionResult AvailablePackages(IFormCollection form, int[] selectedPackages)//picks the id from the form
        {

            try
            {
                List<int> numbers = Enumerable.Range(1, 10).ToList();
                var Tnumbers = new SelectList(numbers).ToList();
                ViewBag.TravellersCount = Tnumbers;//load the drop-down list
                List<TripType> tripTypes = TripTypeManager.GetTripTypes(_db!);
                var ttypes = new SelectList(tripTypes, "TripTypeId", "Ttname").ToList();
                ViewBag.TravelTypes = ttypes;
                var Tcount = (form["TravellersCount"]);//get the number of passengers
                string tripType = form["TravelTypes"].ToString();//get the trip type
                int? customerId = HttpContext.Session.GetInt32("CustomerId");
                List<PackagesDTO> packages = PackagesManager.GetAvailablePackages(_db!, customerId);

                if (selectedPackages != null && selectedPackages.Length > 0)//package was selected
                {
                    TempData["SelectedPackages"] = selectedPackages;
                    if (Tcount != "")//a valid number was selected
                    {
                        int NoOfPassengers = Convert.ToInt32(Tcount);
                        if (tripType != "")
                        {
                            foreach (int PackageId in selectedPackages)//add the packages
                            {
                                BookingManager.AddBooking(_db!, customerId, PackageId, NoOfPassengers, tripType);
                            }
                            return RedirectToAction("MyBookings", "Booking");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Please select the travel type";
                            return View(packages);
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Please select the number of travellers";
                        return View(packages);
                    }

                }
                else
                {
                    ViewBag.ErrorMessage = "Please select a package.";
                    return View(packages);
                }
                return View(packages);
            }
            catch 
            {
                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
                return View();
            }
        }




        // GET: PackagesController/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                var products = PackagesManager.GetDetails(_db!, id);
                return View(products);
            }
            catch 
            {
                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
                return RedirectToAction("Index", "Home");
            }
        }

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

        //// GET: PackagesController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    Package? package = null;
        //    package = PackagesManager.GetPackageById(_db!, id);
        //    if (package != null)
        //        return View(package);
        //    else
        //        return View();

        //}

        //// POST: PackagesController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Package newPackageData)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (id != 0)
        //        {
        //            try
        //            {
        //                PackagesManager.UpdatePackage(_db!, id, newPackageData);
        //                TempData["Message"] = $"Successfully updated movie {newPackageData.PkgName}";
        //            }
        //            catch (Exception)
        //            {
        //                TempData["message"] = $"Problem with updating movie {newPackageData.PkgName}";
        //                TempData["IsError"] = true;
        //            }
        //        }
        //        return RedirectToAction("MyPackages");
        //    }
        //    else
        //    {
        //        return View(newPackageData);
        //    }
        //}
    }
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




   