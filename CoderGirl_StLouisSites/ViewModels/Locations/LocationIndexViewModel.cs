using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_StLouisSites.ViewModels
{
    //private ApplicationDbContext context;

    ////Dependency Injection; context here is acting like a repository
    ////context acting like database
    //public LocationController(ApplicationDbContext context)
    //{
    //    this.context = context;
    //}

    public class LocationIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LocationRateAndReview> RateAndReviews { get; set; }
        public decimal AverageRating { get; set; }
        //public string AverageRating
        //{
        //    get { return $"{LastName}, {FirstName}"; }
        //}

        //public LocationIndexViewModel(int Id, string Name, string Description, decimal AverageRating)
        //{
        //    this.Id= Id;
        //    this.Name = Name;
        //    this.Description = Description;
        //    this.AverageRating = context;
        //}
    }
}
