using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiskInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace DiskInventory.Controllers
{
    public class DiskHasRenterController : Controller
    {
        private disk_inventoryTFContext context { get; set; }   //Student context name will differ
        public DiskHasRenterController(disk_inventoryTFContext ctx)    //Student context name will differ
        {
            context = ctx;
        }
        public IActionResult List()
        {
            // List<DiskHasRenter> diskhasrenter = context.DiskHasRenter.OrderBy(db => db.DiskId).ThenBy(db => db.RenterId).ToList();
            var diskhasrenters = context.DiskHasRenter.OrderBy(db => db.RentDate).
                Include(d => d.Disk).OrderBy(d => d.DiskId).
                Include(r => r.Renter).OrderBy(r => r.RenterId).ToList();
            return View(diskhasrenters);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Disks = context.Disk.OrderBy(d => d.DiskName).ToList();
            ViewBag.Renters = context.Renter.OrderBy(r => r.Lastname).ToList();
            return View("Edit", new DiskHasRenter());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Disks = context.Disk.OrderBy(d => d.DiskName).ToList();
            ViewBag.Renters = context.Renter.OrderBy(r => r.Lastname).ToList();
            var diskhasrenter = context.DiskHasRenter.Find(id);
            return View(diskhasrenter);
        }
        [HttpPost]
        public IActionResult Edit(DiskHasRenter diskhasrenter)
        {
            if (ModelState.IsValid)
            {
                if (diskhasrenter.Id == 0)
                    context.DiskHasRenter.Add(diskhasrenter);
                else
                    context.DiskHasRenter.Update(diskhasrenter);
                context.SaveChanges();
                return RedirectToAction("List", "DiskHasRenter");
            }
            else
            {
                ViewBag.Action = (diskhasrenter.Id == 0) ? "Add" : "Edit";
                ViewBag.Disks = context.Disk.OrderBy(d => d.DiskName).ToList();
                ViewBag.Renters = context.Renter.OrderBy(r => r.Lastname).ToList();
                return View(diskhasrenter);
            }
        }
    }
}
