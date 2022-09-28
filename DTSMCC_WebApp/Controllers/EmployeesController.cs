using DTSMCC_WebApp.Context;
using DTSMCC_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_WebApp.Controllers
{
    public class EmployeesController : Controller
    {
        MyContext myContext;

        public EmployeesController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        // Read
        public IActionResult Index()
        {
            var getData = myContext.Employees.Include(x => x.Jobs).ToList();
            return View(getData);
        }

        // Read by Id
        public IActionResult IndexId(int id)
        {
            var getDataId = myContext.Employees.Find(id);
            return View(getDataId);
        }

        // Create
        // - Get
        

        // - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees employees)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Add(employees);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // Update
        // - Get
        public IActionResult Update(int id)
        {
            var updResult = myContext.Employees.Find(id);
            if (updResult == null)
            {
                return NotFound();
            }
            return View(updResult);
        }
        
        // - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Employees employees)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Update(employees);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        
        // Delete
        // - Get
        public IActionResult Delete(int id)
        {
            var delResult = myContext.Employees.Find(id);
            if (delResult == null)
            {
                return NotFound();
            }
            return View(delResult);
        }
        
        // - Post
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deletedone(Employees employees)
        {
                myContext.Employees.Remove(employees);
                var result = myContext.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
