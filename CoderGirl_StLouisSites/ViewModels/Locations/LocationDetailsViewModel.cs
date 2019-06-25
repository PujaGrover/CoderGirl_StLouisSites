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
        public string StreetAddress { get; set; }
        public string County { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
        // public List<LocationRateAndReview> RateAndReviews { get; set; }
        public List<int> Ratings { get; set; }
        public List<string> Reviews { get; set; }

        public static LocationDetailsViewModel GetLocationDetails(int? Id, ApplicationDbContext context)
        {
            if (Id == null)
            {
                return KeyNotFoundException();
            }
         
            Location location = context.Locations.Find(Id);
            List<LocationRateAndReview> locationRateAndReviews = new List<LocationRateAndReview>();
//locationRateAndReview.LocationId = location.Id;
            locationRateAndReviews = context.LocationRateAndReview.Where(rr => rr.LocationId == Id).ToList();
            //OR
            //List<Models.LocationRateAndReview> rateAndReviews = location.RateAndReviews;
            List<int> ratings = new List<int>();
            List<string> reviews = new List<string>();
            foreach (Models.LocationRateAndReview rr in locationRateAndReviews)
            {
                //extract a rating and a review
                int rate = rr.Rating;
                string review = rr.Review;

                //store it in the list of view model
                
                ratings.Add(rate);
                reviews.Add(review);
            }
            // return the filled list of view model
            return new LocationDetailsViewModel()
            { 
                Id = location.Id,
                Name = location.Name,
                Description = location.Description,
                StreetAddress = location.StreetAddress,
                County = location.County,
                ZipCode = location.ZipCode,
                State = location.State,
                Ratings = ratings,
                Reviews = reviews           
            };
        }

        private static LocationDetailsViewModel KeyNotFoundException()
        {
            throw new NotImplementedException();
        }
    }
}
