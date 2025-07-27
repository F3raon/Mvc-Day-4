using Microsoft.AspNetCore.Mvc;
using Mvc_Day__4.Context;
using Mvc_Day__4.Models;

namespace Mvc_Day__4.Controllers
{
    public class DepartmentController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var departments = db.Departments;
            return View(departments);
        }
    
        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return RedirectToAction("Index");
            }
            return View(department);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null)
            {
                return RedirectToAction("Index");
            }
            return View(dept);
        }
       
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null)
            {
                return RedirectToAction("Index");
            }
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
