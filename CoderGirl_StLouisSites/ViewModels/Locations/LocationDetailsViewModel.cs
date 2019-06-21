using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_StLouisSites.ViewModels.Locations
{
    public class LocationDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public List<LocationRateAndReview> RateAndReviews { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        public static LocationDetailsViewModel GetLocationDetails(int? Id, ApplicationDbContext context)
        {
            if (Id == null)
            {
                return KeyNotFoundException();
            }
            //int rate;
            //string review;
            Location location = context.Locations.Find(Id);
            LocationRateAndReview locationRateAndReview = new LocationRateAndReview();
            //locationRateAndReview.LocationId = location.Id;
            locationRateAndReview = context.LocationRateAndReview.Find(l => l.LocationId == Id).ToList();
            //rate = locationRateAndReview.Rating;
            //review = locationRateAndReview.Review;

            return new LocationDetailsViewModel()
            {
                Name = location.Name,
                Description = location.Description,
                Rating = locationRateAndReview.Rating,
                Review = locationRateAndReview.Review           
            };
        }

        private static LocationDetailsViewModel KeyNotFoundException()
        {
            throw new NotImplementedException();
        }
    }
}
