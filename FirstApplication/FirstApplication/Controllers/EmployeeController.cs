using FirstApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        //this is added to store employees
        static List<Employee> employees=new List<Employee>();
        public ActionResult Index(Employee employee)
        {

            if(employee.EmployeeName!=null)
            {
                employees.Add(employee);
                return RedirectToAction("EmployeeList");
            }

            //this is added to update submit button value
            ViewBag.buttonName = "Create";
            return View();
        }

        public ActionResult EmployeeList()
        {
            return View(employees);
        }
        
        public ActionResult Edit(int id)
        {
            
            var employee = employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            //this is added to update submit button value
            ViewBag.buttonName = "Update";
            TempData["update"] = true;
            return View("Index", employee);
        }
    }
}