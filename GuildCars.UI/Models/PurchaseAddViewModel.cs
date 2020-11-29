using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class PurchaseAddViewModel: IValidatableObject
    {
        public Purchase Purchase { get; set; }
        public Customer Customer { get; set; }
        public VehicleDetailsItem VehicleDetails { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public List<SelectListItem> PurchaseTypeList { get; set; }
        public int SelectedStateID { get; set; }
        public int SelectedPurchaseType { get; set; }
        public PurchaseAddViewModel()
        {
            Purchase = new Purchase();
            StateList = new List<SelectListItem>();

            PurchaseTypeList = new List<SelectListItem>();
            PurchaseTypeList.Add(new SelectListItem() { Text = "Cash", Value = "Cash" });
            PurchaseTypeList.Add(new SelectListItem() { Text = "Bank Finance", Value = "Bank Finance" });
            PurchaseTypeList.Add(new SelectListItem() { Text = "Dealer Finance", Value = "Dealer Finance" });

        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateList.Add(new SelectListItem()
                {
                    Value = state.StateID.ToString(),
                    Text = state.StateName
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if ((string.IsNullOrEmpty(Customer.Email) && (string.IsNullOrEmpty(Customer.Phone))))
            {
                errors.Add(new ValidationResult("Email or Phone are required",
                    new[] { "Customer.Email" }));

                errors.Add(new ValidationResult("Email or Phone are required",
                   new[] { "Customer.Phone" }));
            }
                if (string.IsNullOrEmpty(Customer.FullName))
            {
                errors.Add(new ValidationResult("Name is required",
                    new[] { "Customer.FullName" }));
            }
            if (string.IsNullOrEmpty(Customer.Street1))
            {
                errors.Add(new ValidationResult("Street is required",
                    new[] { "Customer.Street1" }));
            }
            if (string.IsNullOrEmpty(Customer.City))
            {
                errors.Add(new ValidationResult("City is required",
                    new[] { "Customer.City" }));
            }
            if (string.IsNullOrEmpty(Customer.State))
            {
                errors.Add(new ValidationResult("State is required",
                    new[] { "Customer.State" }));
            }
            if (string.IsNullOrEmpty(Customer.ZipCode))
            {
                errors.Add(new ValidationResult("Zip Code is required",
                    new[] { "Customer.ZipCode" }));
            }
            if (!(string.IsNullOrEmpty(Customer.ZipCode)) && ((Customer.ZipCode).Length != 5))
            {
                errors.Add(new ValidationResult("Zip Code must be 5 digits",
                    new[] { "Customer.ZipCode" }));
            }
            if (Purchase.PurchasePrice < (VehicleDetails.Price * Convert.ToDecimal(.95)))
            {
                errors.Add(new ValidationResult("Purchase Price cannot be less than 95% of the sales price",
                    new[] { "Purchase.PurchasePrice" }));
            }
            if (Purchase.PurchasePrice > VehicleDetails.MSRP)
            {
                errors.Add(new ValidationResult("Purchase Price cannot exceed the MSRP",
                    new[] { "Purchase.PurchasePrice" }));
            }
            if (string.IsNullOrEmpty(Purchase.PurchaseType))
            {
                errors.Add(new ValidationResult("Purchase Type is required",
                    new[] { "Purchase.PurchaseType" }));
            }
            return errors;
        }
    }
}