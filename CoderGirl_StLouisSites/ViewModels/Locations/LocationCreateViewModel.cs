using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_StLouisSites.ViewModels.Locations
{
    public class LocationCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please give the description between 2 to 200 characters")]
        [MinLength(2)][StringLength(200)]
        public string Description { get; set; }
        public string StreetAddress { get; set; }
        [Required]
        public string County { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage ="Invalid Zip")]
        public string ZipCode { get; set; }
        public string State { get; set; }
        //public string ImageURL { get; set; }

        public void Persist(ApplicationDbContext context)
        {
            Location location = new Location()
            {
                Name = this.Name,
                Description = this.Description,
                StreetAddress = this.StreetAddress,
                County = this.County,
                ZipCode = this.ZipCode,
                State = this.State
            };
            context.Add(location);
            context.SaveChanges();
        }
    }
}
