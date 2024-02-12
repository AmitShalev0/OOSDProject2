using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelExpertsData;

namespace TravelExpertsMVC.Controllers
{
    public class AccountController : Controller
    {

        //constructor for the controller for injecting the context db
        private TravelExpertsContext? _db { get; set; }
        //added constructor
        public AccountController(TravelExpertsContext db) { _db = db; } //when the slipcontrolelr is created it will get the context

        public IActionResult Login(string returnUrl = "")
        {
            if (returnUrl == "/Account/Login")//directly from the login page
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            else if (!string.IsNullOrEmpty(returnUrl))
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Customer customer) //data collected from the form
        {
            try
            {
                Customer? cst = CustomerManager.Authenticate(_db!, customer.CustUserName!, customer.CustPassword!);
                if (cst == null)//no matching username and password found
                {
                    return View();// stay on login page
                }
                //customer not null
                HttpContext.Session.SetInt32("CustomerId", cst.CustomerId); //get the customer ID

                List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, cst.CustFirstName),
                new Claim("LastName", cst.CustLastName),
            };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme); // cookies authentication
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                // ready for signing in
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal);
                // redirect to the protected page that initiated the login if defined
                string? returnUrl = TempData["ReturnUrl"]?.ToString();
                if (string.IsNullOrEmpty(returnUrl))// if not return URL
                {
                    return RedirectToAction("Index", "Home"); // go to home page
                }
                else if (returnUrl == "/Account/Login")//if directly logged in from the login page
                {
                    return RedirectToAction("Index", "Home");
                }
                else return Redirect(returnUrl);//go to the page that initiated the login
            }
            catch (Exception)
            {

                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
            }
            return View(customer);

        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("CustomerId");
            return RedirectToAction("Index", "Home"); // go to home page
        }















        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
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

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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
