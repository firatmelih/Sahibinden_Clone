﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Car.Models;
using Car.AppDbContext;
using Microsoft.AspNetCore.Authorization;

namespace Car.Controllers
{
    [Authorize(Roles="Admin")]
    public class MakeController : Controller
    {
        private readonly CarDbContext _db;
        public MakeController(CarDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Makes.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Make make)
        {
            if(ModelState.IsValid)
            {
                _db.Add(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
        public IActionResult Delete(int id)
        {
            var make = _db.Makes.Find(id);
            if(make==null)
            {
                return NotFound();
            }
            _db.Makes.Remove(make);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var make = _db.Makes.Find(id);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }
        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                _db.Update(make);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
    }
    
}
