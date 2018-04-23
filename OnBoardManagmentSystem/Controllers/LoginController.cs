using OnBoardManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnBoardManagmentSystem.Controllers
{
    public class LoginController : Controller
    {
        OnBoardDb ctx = new OnBoardDb();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User login)
        {
            User result = ctx.Users.ToList().FirstOrDefault(m => m.U_Username == login.U_Username && m.U_Password == login.U_Password);
            if (result == null)
            {
                ViewBag.msg = "Invalid Username or password";
                return View();
            }
            else if (result.U_Role == "admin")
            {
                //admin
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Mentor mentor = ctx.Mentors.FirstOrDefault(m => result.U_Username.Equals(m.M_Name));
                return RedirectToAction("View", "Mentor", new { id = mentor.M_Id });

            }
        }
    }
}