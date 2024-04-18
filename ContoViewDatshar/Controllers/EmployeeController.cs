using ContoViewDatshar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContoViewDatshar.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            // "Strongly Typed Views:
            // step1: Prepare the Data
            List<Emp> emps = EmpDataContext.GetEmployees();

            //Pass The Data
            return View(emps);
        }
    }
}