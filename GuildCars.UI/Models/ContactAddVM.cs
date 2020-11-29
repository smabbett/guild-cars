using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class ContactAddVM : IValidatableObject
    {
        public Contact Contact { get; set; }

        public ContactAddVM()
        {
            Contact = new Contact();
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

           
            if (string.IsNullOrEmpty(Contact.FullName))
            {
                errors.Add(new ValidationResult("Name is required",
                    new[] { "Contact.FullName" }));
       
            }
            if (string.IsNullOrEmpty(Contact.Message))
            {
                errors.Add(new ValidationResult("Message is required",
                    new[] { "Contact.Message" }));
            }
            if ((string.IsNullOrEmpty(Contact.Email) && (string.IsNullOrEmpty(Contact.Phone))))
            {
                errors.Add(new ValidationResult("Email or Phone are required",
                    new[] { "Contact.Email" }));

                errors.Add(new ValidationResult("Email or Phone are required",
                   new[] { "Contact.Phone" }));

            }
            return errors;
        }
    }
}