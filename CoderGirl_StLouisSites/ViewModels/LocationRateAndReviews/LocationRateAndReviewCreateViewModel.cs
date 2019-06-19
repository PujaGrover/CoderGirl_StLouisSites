using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
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
        public Location Location { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

        private readonly ApplicationDbContext context;

        public LocationRateAndReviewCreateViewModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public LocationRateAndReviewCreateViewModel GetLocationForRateAnReviewFromLocation(int locationId)
        {
            Location location = context.Locations.Find(locationId);
            LocationRateAndReview locationRateAndReview = new LocationRateAndReview();
            locationRateAndReview.LocationId = locationId;
            locationRateAndReview.Location = location;

            return new LocationRateAndReviewCreateViewModel(context)
            {
                LocationId = locationRateAndReview.LocationId,
                Location = locationRateAndReview.Location,
                Rating = locationRateAndReview.Rating,
                Review = locationRateAndReview.Review
            };
        }
    }
}
