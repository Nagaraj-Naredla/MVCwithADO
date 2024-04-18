using MVCwithADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCwithADO.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        EmployeesDataContext _context;
        public EmployeesController()
        {
            _context = new EmployeesDataContext();

        }
        public ActionResult Index()
        {
            List<Employees> employees = _context.GetEmployees();
            return View(employees);
        }
        public ActionResult Create() 
        {
            return View(new Employees());
        }
        [HttpPost]
        public ActionResult Create(Employees emps)
        {
            int i= _context.InsertEmployees(emps);
            if(i > 0 )
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Msg = "Record Not Inserted";
                return View();
            }

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Employees emps = _context.GetEmployee(id);
            return View(emps);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employees emps = _context.GetEmployee(id);
            return View(emps);
        }
        [HttpPost]
        public ActionResult Update(Employees emps)
        {
            int i = _context.UpdateEmps(emps);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Msg = "Record Not Updated";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
           // Employees emps = _context.GetEmployee(id);
           // return View(emps);
           return View();
        }
        [HttpPost]
        public ActionResult DeleteEmp(int empID)
        {

            int i = _context.DeleteEmployee(empID);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Msg = "Record Not Deleted";
                return View();
            }
        }
    }
}