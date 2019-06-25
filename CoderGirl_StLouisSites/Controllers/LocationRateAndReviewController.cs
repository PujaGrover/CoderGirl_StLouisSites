using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using CoderGirl_StLouisSites.ViewModels.LocationRateAndReviews;

namespace CoderGirl_StLouisSites.Controllers
{
    public class LocationRateAndReviewController : Controller
    {
        private readonly ApplicationDbContext context;

        public LocationRateAndReviewController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: LocationRateAndReviews
        public IActionResult Index()
        {

            List<LocationRateAndReview> list = context.RateAndReviews.ToList();
            foreach (LocationRateAndReview item in list)
            {
                int id = item.LocationId;
                Location location = context.Locations.Find(id);
                item.Location = location;
            }
            return View(list);
        }

        // GET: LocationRateAndReviews/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var locationRateAndReview = await context.LocationRateAndReview
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (locationRateAndReview == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(locationRateAndReview);
        //}

        // GET: LocationRateAndReviews/Create
        [HttpGet]
        public IActionResult Create(int locationId)
        {
            //CODE BELOW IS FOR MODELS
            //Location location = context.Locations.Find(locationId);
            //LocationRateAndReview locationRateAndReview = new LocationRateAndReview();
            //locationRateAndReview.LocationId = locationId;
            //locationRateAndReview.Location = location;

            //CODE BELOW IS FOR VIEW MODELS - RESOLVED
            LocationRateAndReviewCreateViewModel locationRateAndReview
                = LocationRateAndReviewCreateViewModel.GetLocationForRateAnReviewFromLocation(locationId, context);

            return View(locationRateAndReview);
        }

        [HttpPost]
        public IActionResult Create(LocationRateAndReviewCreateViewModel locationRateAndReview)
        {
            //CODE BELOW IS FOR MODELS
            //context.Add(locationRateAndReview);
            //context.SaveChanges();

            //CODE BELOW IS THROUGH VIEW MODELS
            locationRateAndReview.Persist(context);
            return RedirectToAction(nameof(Index));
            //return RedirectToAction(controllerName: nameof(Location), actionName: nameof(Index));
        }

        //// POST: LocationRateAndReviews/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Location,Rating,Review")] LocationRateAndReview locationRateAndReview)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Location location = context.Locations.Find(locationRateAndReview.LocationId);
        //        location.RateAndReviews.Add(locationRateAndReview);

        //        context.Add(locationRateAndReview);
        //        await context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(locationRateAndReview);
        //}

        //// GET: LocationRateAndReviews/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var locationRateAndReview = await context.LocationRateAndReview.FindAsync(id);
        //    if (locationRateAndReview == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(locationRateAndReview);
        //}

        //// POST: LocationRateAndReviews/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,LocationId,Location,Rating,Review")] LocationRateAndReview locationRateAndReview)
        //{
        //    if (id != locationRateAndReview.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            context.Update(locationRateAndReview);
        //            await context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LocationRateAndReviewExists(locationRateAndReview.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(locationRateAndReview);
        //}

        //// GET: LocationRateAndReviews/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var locationRateAndReview = await context.LocationRateAndReview
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (locationRateAndReview == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(locationRateAndReview);
        //}

        //// POST: LocationRateAndReviews/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var locationRateAndReview = await context.LocationRateAndReview.FindAsync(id);
        //    context.LocationRateAndReview.Remove(locationRateAndReview);
        //    await context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LocationRateAndReviewExists(int id)
        //{
        //    return context.LocationRateAndReview.Any(e => e.Id == id);
        //}
    }
}
