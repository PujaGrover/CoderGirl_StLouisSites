using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using CoderGirl_StLouisSites.ViewModels;
using CoderGirl_StLouisSites.ViewModels.Locations;
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
            //List<Location> locations = context.Locations.ToList();
            List<LocationIndexViewModel> locations = LocationIndexViewModel.GetLocationListFromLocation(context);
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LocationCreateViewModel locationCreateViewModel)
        {
            //CODE BELOW IS WITH MODELS
            //context.Add(location);
            //context.SaveChanges();//After adding SaveChanges puts the changes in the Database

            //CODE BELOW IS WITH VIEWMODELS
            locationCreateViewModel.Persist(context);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            //Location location = context.Locations.Find(Id);
            LocationDetailsViewModel locationViewModel = LocationDetailsViewModel.GetLocationDetails(Id, context);

            return View(locationViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View(new LocationEditViewModel(Id, context));
        }

        [HttpPost]
        public IActionResult Edit(int Id, LocationEditViewModel locationEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(new LocationEditViewModel(Id, context));
            }

            locationEditViewModel.Persist(Id, context);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Location location = context.Locations.Find(id);
            context.Locations.Remove(location);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}