using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_StLouisSites.ViewModels
{
    public class LocationIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LocationRateAndReview> RateAndReviews { get; set; }
        public double AverageRating { get; set; }

        private ApplicationDbContext context;

        //Dependency Injection; context here is acting like a repository
        //context acting like database
        public LocationIndexViewModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public static List<LocationIndexViewModel> GetLocationListFromLocation(ApplicationDbContext context)
        {
            List<Location> locationList = context.Locations.ToList();

            List<LocationIndexViewModel> locations = new List<LocationIndexViewModel>();
            foreach (var item in locationList)
            {
                LocationIndexViewModel location = new LocationIndexViewModel(context);

                location.Id = item.Id;
                location.Name = item.Name;
                location.Description = item.Description;
                location.RateAndReviews = item.RateAndReviews;
                //List<int> Ratings = item.RateAndReviews.Select(r => r.Rating).ToList();

                //if (Ratings.Count == 0)
                //{
                //    location.AverageRating = 0;
                //}
                //else
                //location.AverageRating = Ratings.Average();

                locations.Add(location);
            }

            return locations;
        }
    }
}
