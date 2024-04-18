using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContoViewDatshar.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewData["StudentID"] = 101;
            ViewData["StudentName"] = "Nagaraj";
            ViewData["Marks"] = new int[] { 65, 76, 45, 87, 98, 34 };
            return View();
        }
        public ActionResult Index1()
        {
            ViewBag.StudentID = 101;
            ViewBag.StudentName = "Nagaraj";
            ViewBag.Marks = new int[] { 65, 76, 45, 87, 98, 34 };
            return View();
        }
    }
}