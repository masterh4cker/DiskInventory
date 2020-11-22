using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiskInventory.Models;

namespace DiskInventory.Controllers
{
    public class DiskController : Controller
    {
        private disk_inventoryTFContext context { get; set; }
        public DiskController(disk_inventoryTFContext ctx)
        {
            context = ctx;
        }
        public IActionResult List()
        {
            List<Disk> disks = context.Disk.OrderBy(a => a.DiskName).ToList();
            return View(disks);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Disk());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var disk = context.Disk.Find(id);
            return View(disk);
        }

        [HttpPost]
        public IActionResult Edit(Disk disk)
        {
            if (ModelState.IsValid)
            {
                if (disk.DiskId == 0)
                    context.Disk.Add(disk);
                else
                    context.Disk.Update(disk);
                context.SaveChanges();
                return RedirectToAction("List", "Disk");
            }
            else
            {
                ViewBag.Action = (disk.DiskId == 0) ? "Add" : "Edit";
                return View(disk);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var disk = context.Disk.Find(id);
            return View(disk);
        }
        [HttpPost]
        public IActionResult Delete(Disk disk)
        {
            context.Disk.Remove(disk);
            context.SaveChanges();
            return RedirectToAction("List", "Disk");
        }
    }
}
