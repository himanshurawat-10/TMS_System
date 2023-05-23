using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMS.Context;
using TMS.Interface;
using TMS.Models;

namespace TMS.Controllers
{
    public class UserController : Controller
    {
        IUser _user;
        MyDBContext _dbContext;

        public UserController(IUser user,MyDBContext dbContext)
        {
            _user = user;
            _dbContext = dbContext;
        }

      
        public IActionResult Index()
        {

            ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Role)));

            ViewData["ManagerId"] = new SelectList(_dbContext.Users.Where(x => (int)x.RoleName == 1), "Id", "UName");
            return View(_user.GetUser());
        }

        public IActionResult Create()
        {
            //  ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Role)));
            ViewData["ManagerId"] = new SelectList(_dbContext.Users.Where(x => (int)x.RoleName == 1), "UId", "Name", null);
            return View();
           
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
             _user.Create(user);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            User obj = _user.GetUserById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Deleted(int UId)
        {
            User obj = _user.GetUserById(UId);
            if (obj != null)
                _user.Delete(obj.UId);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            User obj = _user.GetUserById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            User obj = _user.GetUserById(id);
            if (obj != null)
                _user.Edit(id, user);
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            var user = _user.GetUserById(id);
            
            return View(user);
        }

        public IActionResult Validate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validate(string Email, string Password)
        {
          var user =   _user.ValidateUser(Email, Password);
            if (user != null)
            {
                if ((int)user.RoleName == 0)
                {
                    return RedirectToAction("Emp");
                }
                else if ((int)user.RoleName == 1)
                {
                    return RedirectToAction("Manager");
                }
                else if ((int)user.RoleName == 2)
                {
                    return RedirectToAction("Admin");
                }
                return RedirectToAction("Index");
            }
            else {
                return RedirectToAction("Validate");
            }
         }

        public IActionResult Emp()
        {
            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

    }
}
