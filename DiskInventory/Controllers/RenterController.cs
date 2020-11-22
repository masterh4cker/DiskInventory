using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiskInventory.Models;

namespace DiskInventory.Controllers
{
    public class RenterController : Controller
    {
        private disk_inventoryTFContext context { get; set; }       // Student context
        public RenterController(disk_inventoryTFContext ctx)
        {
            context = ctx;
        }
        public IActionResult List()
        {
            List<Renter> renters = context.Renter.OrderBy(a => a.Lastname).ToList();
            return View(renters);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Renter());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var renter = context.Renter.Find(id);
            return View(renter);
        }

        [HttpPost]
        public IActionResult Edit(Renter renter)
        {
            if (ModelState.IsValid)
            {
                if (renter.RenterId == 0)
                    context.Renter.Add(renter);
                else
                    context.Renter.Update(renter);
                context.SaveChanges();
                return RedirectToAction("List", "Renter");
            }
            else
            {
                ViewBag.Action = (renter.RenterId == 0) ? "Add" : "Edit";
                return View(renter);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var renter = context.Renter.Find(id);
            return View(renter);
        }
        [HttpPost]
        public IActionResult Delete(Renter renter)
        {
            context.Renter.Remove(renter);
            context.SaveChanges();
            return RedirectToAction("List", "Renter");
        }
    }
}
