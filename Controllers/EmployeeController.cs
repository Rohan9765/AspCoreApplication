using AspCoreApplication.Data;
using AspCoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;

        public EmployeeController(ApplicationContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            var result = _context.Employees.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            var result = new Employee()
            {
                Name = Employee.Name,
                City = Employee.City,
                State = Employee.State,
                Salary = Employee.Salary
            };
            _context.Employees.Add(result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            var Result = _context.Employees.SingleOrDefault(e => e.id == id);
            _context.Employees.Remove(Result);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var Result = _context.Employees.SingleOrDefault(e => e.id == id);
            var emp = new Employee()
            {
                Name = Result.Name,
                City= Result.City,
                State=Result.State,
                Salary= Result.Salary
            };

            return View (emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee Employee)
        {

            var emp = new Employee()
            {
                id= Employee.id,
                Name = Employee.Name,
                City = Employee.City,
                State = Employee.State,
                Salary = Employee.Salary
            };
            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
