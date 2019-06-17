using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_StLouisSites.Models
{
    public class LocationRateAndReview
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
