﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiskInventory.Models;

namespace DiskInventory.Controllers
{
    public class ArtistController : Controller
    {
        private disk_inventoryTFContext context { get; set; }
        public ArtistController(disk_inventoryTFContext ctx)
        {
            context = ctx;
        }
        public IActionResult List()
        {
            List<Artist> artists = context.Artist.OrderBy(a => a.Lastname).ToList();
            return View(artists);
        }
    }
}