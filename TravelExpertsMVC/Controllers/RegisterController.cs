using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelExpertsData;

namespace TravelExpertsMVC.Controllers
{
    public class RegisterController : Controller
    {
        private TravelExpertsContext? _db { get; set; }
        //added constructor
        public RegisterController(TravelExpertsContext db) { _db = db; }

        // GET: RegisterController
        public ActionResult Register()
        {
            // Define your list of provinces
            var provinces = new List<string> { "AB", "BC", "MB", "NS", "SK", "NL", "PE", "NB", "QC", "ON", "YT", "NT", "NU" };

            // Create a SelectList from the list of provinces
            var selectList = new SelectList(provinces);

            // Assign the SelectList to ViewBag
            ViewBag.Provinces = selectList;

            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer newCustomer)
        {
            // Define your list of provinces
            var provinces = new List<string> { "AB", "BC", "MB", "NS", "SK", "NL", "PE", "NB", "QC", "ON", "YT", "NT", "NU" };

            // Create a SelectList from the list of provinces
            var selectList = new SelectList(provinces);

            // Assign the SelectList to ViewBag
            ViewBag.Provinces = selectList;
            try
            {

                if (!Checks.UserCheck(_db!, newCustomer.CustUserName))//if false means it's already taken
                {
                    ModelState.AddModelError(nameof(newCustomer.CustUserName),
                        $"Username {newCustomer.CustUserName} is already taken");
                }

                // Check if the selected province is valid
                if (!provinces.Contains(newCustomer.CustProv))
                {
                    ModelState.AddModelError(nameof(newCustomer.CustProv), "Please select a valid province.");
                }


                if (ModelState.IsValid)
                {
                    CustomerManager.AddCustomer(_db!, newCustomer);
                    TempData["Message"] = $"Registration Successful.";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return View(newCustomer);
                }

            }
            catch
            {
                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
                return View(newCustomer);
            }
        }
    }
}
