using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class UserAddVM : IValidatableObject
    {
        public AppUser User { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public string SelectedRoleID { get; set; }
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(User.FirstName))
            {
                errors.Add(new ValidationResult("First Name is required",
                    new[] { "User.FirstName" }));
            }
            if (string.IsNullOrEmpty(User.LastName))
            {
                errors.Add(new ValidationResult("Last Name is required",
                    new[] { "User.LastName" }));
            }
            if (string.IsNullOrEmpty(User.Email))
            {
                errors.Add(new ValidationResult("Email is required",
                    new[] { "User.Email" }));
            }
            if (string.IsNullOrEmpty(Password))
            {
                errors.Add(new ValidationResult("Password is required",
                    new[] { "Password" }));
            }
            if (string.IsNullOrEmpty(SelectedRoleID))
            {
                errors.Add(new ValidationResult("Role is required",
                    new[] { "SelectedRoleID" }));
            }
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                errors.Add(new ValidationResult("Confirm Password is required",
                    new[] { "ConfirmPassword" }));
            }
            if (Password != ConfirmPassword)
            {
                errors.Add(new ValidationResult("Password and Confirm Password must match",
                    new[] { "Password" }));
            }       
            return errors;
        }
    }
}