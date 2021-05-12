using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApp.Data;
using VehicleApp.Models;

namespace VehicleApp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VehicleController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Vehicle> objList = _db.Vehicles;    
            return View(objList);
        }

        // GET-create
        public IActionResult Create()
        {
            return View();
        }

        // POST-create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehicle obj)
        {
            if (ModelState.IsValid)
            {
                _db.Vehicles.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET-delete
        public IActionResult Delete(int? id)
        {
            if (id == null ||id == 0)
            {
                return NotFound();
            }
            var obj = _db.Vehicles.Find(id);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }

        // POST-delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Vehicles.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Vehicles.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET-update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Vehicles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST-update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Vehicle obj)
        {
            if (ModelState.IsValid)
            {
                _db.Vehicles.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
