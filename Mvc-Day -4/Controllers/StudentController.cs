﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mvc_Day__4.Context;
using Mvc_Day__4.Models;

namespace Mvc_Day__4.Controllers
{
    public class StudentController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var students = db.Students.Include(e => e.Department);
            return View(students);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = db.Students.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            return View(student);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Departments = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(Student student)
        {
            var exEmail = db.Students.FirstOrDefault(e => e.Email == student.Email);
            if (exEmail != null)
            {
                ModelState.AddModelError("", "Email Already Exist");
                ViewBag._Departments = new SelectList(db.Departments, "DeptId", "DeptName");
                return View();
            }

            ModelState.Remove("Department");
            if (student != null && ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "All Fields required");
            ViewBag._Departments = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }
   
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var student = db.Students.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Departments = new SelectList(db.Departments, "DeptId", "DeptName");
            return View(student);
        }
       
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            ModelState.Remove("Department");
            if (student != null && ModelState.IsValid)
            {
                db.Students.Update(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag._Departments = new SelectList(db.Departments, "DeptId", "DeptName");
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
