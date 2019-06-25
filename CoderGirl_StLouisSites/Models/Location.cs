using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_StLouisSites.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<LocationRateAndReview> RateAndReviews { get; set; }
        public string StreetAddress { get; set; }
        public string County { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
    }
}
