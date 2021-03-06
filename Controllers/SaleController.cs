using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car.AppDbContext;
using Car.Models;
using Car.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace Car.Controllers
{
    
    public class SaleController : Controller
    {
        private readonly CarDbContext _db;

        [BindProperty]
        public CarViewModel SaleVM { get; set; }
        public SaleController(CarDbContext db)
        {
            _db = db;
            SaleVM = new CarViewModel()
            {
                Makes = _db.Makes.ToList(),
                Models = _db.Models.ToList(),
                Sale = new Models.Sale()
            };

        }
        public IActionResult Index()
        {
            var Sales = _db.Sales.Include(m => m.Make).Include(m=>m.Model);
            return View(Sales);
        }

        public IActionResult Create()
        {
            return View(SaleVM);
        }
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(SaleVM);
            }
            _db.Sales.Add(SaleVM.Sale);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            SaleVM.Sale = _db.Sales.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
            if (SaleVM.Sale == null)
            {
                return NotFound();
            }
            return View(SaleVM);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(SaleVM);
            }
            _db.Update(SaleVM.Sale);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Sale model = _db.Sales.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _db.Sales.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult View(int id)
        {
            SaleVM.Sale = _db.Sales.SingleOrDefault(b => b.Id == id);

            if (SaleVM.Sale == null)
            {
                return NotFound();
            }
            return View(SaleVM);
        }
    }
}
