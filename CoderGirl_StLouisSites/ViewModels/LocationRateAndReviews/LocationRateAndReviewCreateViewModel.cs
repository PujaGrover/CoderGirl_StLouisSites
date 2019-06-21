using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_StLouisSites.ViewModels.LocationRateAndReviews
{
    public class LocationRateAndReviewCreateViewModel
    {
        //public int Id { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }



        public static LocationRateAndReviewCreateViewModel GetLocationForRateAnReviewFromLocation(int locationId, ApplicationDbContext context)
        {
            Location location = context.Locations.Find(locationId);

            //LocationRateAndReview rateAndReview = context.RateAndReviews.Include(rr => rr.Location).SingleOrDefault();

            return new LocationRateAndReviewCreateViewModel()
            {
                LocationId = locationId,
                LocationName = location.Name,
            };
        }

        public void Persist(ApplicationDbContext context)
        {
            LocationRateAndReview locationRateAndReview = new LocationRateAndReview()
            {
                LocationId = this.LocationId,
                Rating = this.Rating,
                Review = this.Review
            };

            context.Add(locationRateAndReview);
            context.SaveChanges();
        }
        
    }
}
