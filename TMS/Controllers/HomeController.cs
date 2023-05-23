using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TMS.Context;
using TMS.Models;

namespace TMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDBContext db; 

        public HomeController(ILogger<HomeController> logger, MyDBContext dBContext)
        {
            _logger = logger;
            db = dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            User obj = db.Users.FirstOrDefault(x => x.Email.Equals(Email) && x.Password.Equals(Password));

            if (obj != null)
            {
                Role role = obj.RoleName;
                if ((int)role == 3)//admin
                {
                    return RedirectToAction("Login", "User");
                }
                else if ((int)role == 0)//manager
                {
                    return RedirectToAction("Index", ",manager");
                }
                else if ((int)role == 1) //employee
                {
                    return RedirectToAction("Index", "employee");
                }
                else {
                    return RedirectToAction("Validate", "User");
                }

            }

            return View();
        }


    }
}