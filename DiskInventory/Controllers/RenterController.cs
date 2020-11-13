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
    }
}
