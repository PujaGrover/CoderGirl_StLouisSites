using CoderGirl_StLouisSites.Data;
using CoderGirl_StLouisSites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_StLouisSites.ViewModels.Locations
{
    public class LocationEditViewModel
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

        public LocationEditViewModel(int Id, ApplicationDbContext context)
        {
            Location location = context.Locations.Find(Id);
            Name = location.Name;
            Description = location.Description;
            StreetAddress = location.StreetAddress;
            County = location.County;
            ZipCode = location.ZipCode;
            State = location.State;
        }

        public void Persist(int Id, ApplicationDbContext context)
        {
            Location location = new Location()
            {
                Id = Id,
                Name = this.Name,
                Description = this.Description,
                StreetAddress = this.StreetAddress,
                County = this.County,
                ZipCode = this.ZipCode,
                State = this.State
            };
            context.Update(location);
            context.SaveChanges();
        }
    }
}
