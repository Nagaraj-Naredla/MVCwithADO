using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDBfirstApproach.Models;

namespace EFDBfirstApproach.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CompanyDBEntities _entities = new CompanyDBEntities();
        public ActionResult Index()
        {
            List<Employee> emps = _entities.Employees.ToList();
            return View(emps);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp) 
        {
            _entities.Employees.Add(emp);
            _entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Employee emps = _entities.Employees.Find(id);
            return View(emps);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            _entities.Entry(emp).State=System.Data.Entity.EntityState.Modified;
            _entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Employee emps = _entities.Employees.Find(id);
            return View(emps);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            int empID = Convert.ToInt32(id);
            Employee emps = _entities.Employees.Find(empID);
            _entities.Employees.Remove(emps);
            _entities.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) 
        {
            Employee emps = _entities.Employees.Find(id);
            return View(emps);
        }
    }
}