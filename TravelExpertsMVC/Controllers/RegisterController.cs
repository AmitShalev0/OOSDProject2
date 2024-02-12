using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer newCustomer)
        {
            try
            {

                if (!Checks.EmailCheck(_db!, newCustomer.CustUserName))//if false means it's already taken
                {
                    ModelState.AddModelError(nameof(newCustomer.CustUserName),
                        $"Username {newCustomer.CustUserName} is already taken");
                }


                if (ModelState.IsValid)
                {
                    CustomerManager.AddCustomer(_db!, newCustomer);
                    TempData["Message"] = $"Registration Successful.";
                    return RedirectToAction("Index", "Home");
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
