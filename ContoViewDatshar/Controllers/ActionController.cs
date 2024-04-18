using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContoViewDatshar.Controllers
{
    public class ActionController : Controller
    {
        // GET: Action
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email ,string password)
        {
            if(email == "naganaredla@gmail.com" && password == "vandi123#")
            {
                TempData["Email"] = email;
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.Msg = "Login Failed";
            }
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
    }
}