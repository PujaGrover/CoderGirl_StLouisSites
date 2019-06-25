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
        [Required(ErrorMessage = "Please give the description between 2 to 200 characters")][MinLength(2)][MaxLength(200)]
        public string Description { get; set; }
        public string StreetAddress { get; set; }
        [Required]
        public string County { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }

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
