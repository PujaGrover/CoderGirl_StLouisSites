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
                //location.RateAndReviews = item.RateAndReviews; THIS IS EMPTY ?? NEED TO CHECK WHY?CODE BELOW IS WITH THIS IDEA
                //location.RateAndReviews = item.RateAndReviews;
                //List<int> Ratings = item.RateAndReviews.Select(r => r.Rating).ToList();

                //if (Ratings.Count == 0)
                //{
                //    location.AverageRating = 0;
                //}
                //else


                //CODE BELOW IS TO GET THE LIST OF RATINGS FOR THE SPECIFIC LOCATION Id
                List<LocationRateAndReview> locationRateAndReviews = new List<LocationRateAndReview>();
                
                locationRateAndReviews = context.LocationRateAndReview.Where(rr => rr.LocationId == location.Id).ToList();
         
                List<int> ratings = new List<int>();

                if (locationRateAndReviews.Count > 0)
                {
                    foreach (Models.LocationRateAndReview rr in locationRateAndReviews)
                    {
                        //extract a rating 
                        int rate = rr.Rating;


                        //store rating in the list of view model
                        ratings.Add(rate);
                    }
                    location.AverageRating = Math.Round(ratings.Average(), 2);
                    ////Math.Round(movie.Ratings.Average(x => x.Rating), 2);
                }
                else
                    location.AverageRating = 0;

                locations.Add(location);
            }

            return locations;
        }
    }
}
