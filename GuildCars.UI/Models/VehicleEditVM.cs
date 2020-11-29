using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class VehicleEditVM : IValidatableObject
    {
        public IEnumerable<SelectListItem> Make { get; set; }
        public IEnumerable<SelectListItem> Model { get; set; }
        public List<SelectListItem> Type { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> Transmission { get; set; }
        public IEnumerable<SelectListItem> BodyColor { get; set; }
        public IEnumerable<SelectListItem> InteriorColor { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public Vehicle Vehicle { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }

        public VehicleEditVM()
        {
            Type = new List<SelectListItem>();
            Type.Add(new SelectListItem() { Text = "New", Value = "New" });
            Type.Add(new SelectListItem() { Text = "Used", Value = "Used" });

        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Vehicle.VehicleType == "New" && Vehicle.Mileage > 1000 || Vehicle.Mileage < 0)
            {
                errors.Add(new ValidationResult("New Vehicles must have mileage between 0 and 1000",
                    new[] { "Vehicle.Mileage" }));
            }

            if (Vehicle.VehicleType == "Used" && Vehicle.Mileage < 1000)
            {
                errors.Add(new ValidationResult("Used Vehicles must have mileage of 1000 or greater",
                    new[] { "Vehicle.Mileage" }));
            }

            if (string.IsNullOrEmpty(Vehicle.Vin))
            {
                errors.Add(new ValidationResult("VIN is required",
                   new[] { "Vehicle.Vin" }));
            }

            if (Vehicle.MSRP <= 0)
            {
                errors.Add(new ValidationResult("MSRP must be greater than 0",
                    new[] { "Vehicle.MSRP" }));
            }

            if (Vehicle.Price <= 0)
            {
                errors.Add(new ValidationResult("Price must be greater than 0",
                    new[] { "Vehicle.Price" }));
            }

            if (Vehicle.Price > Vehicle.MSRP)
            {
                errors.Add(new ValidationResult("Vehicle price may not exceed MSRP",
                    new[] { "Vehicle.Price" }));
            }

            if (string.IsNullOrEmpty(Vehicle.VehicleDescription))
            {
                errors.Add(new ValidationResult("Vehicle Description is required",
                    new[] { "Vehicle.VehicleDescription" }));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg.",
                        new[] { "Vehicle.ImageFileName" }));
                }
            }
            return errors;
        }
    }
}
