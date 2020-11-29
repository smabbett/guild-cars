using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SpecialsAddViewModel : IValidatableObject
    {
        public Special Special { get; set; }
        public List<Special> SpecialList { get; set; }
        public SpecialsAddViewModel()
        {
            Special = new Special();
            SpecialList = new List<Special>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
         
            if (string.IsNullOrEmpty(Special.Title))
            {
                errors.Add(new ValidationResult("Title is required",
                    new[] { "Special.Title" }));
            }
            if (string.IsNullOrEmpty(Special.SpecialDescription))
            {
                errors.Add(new ValidationResult("Description is required",
                    new[] { "Special.SpecialDescription" }));
            }
            return errors;
        }
    }
}
