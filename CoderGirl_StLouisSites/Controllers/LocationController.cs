using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_StLouisSites.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationDbContext context;

        //Dependency Injection; context here is acting like a repository
        //context acting like database
        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            //Displaying the list of locations here in Index View
            List<Location> locations = context.Locations.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            context.Add(location);
            context.SaveChanges();//After adding SaveChanges puts the chnges in the Database
            return RedirectToAction(nameof(Index));
        }
    }
}