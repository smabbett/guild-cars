using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using GuildCars.UI.Utitlites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "sales")]
    public class SalesController : Controller
    {
        // GET: Sales    
        public ActionResult Index()
        {
            SearchVM model = new SearchVM();
            model.SearchYears = VehicleRepositoryFactory.GetRepository().CreateSearchYears();
            model.PriceRange = VehicleRepositoryFactory.GetRepository().CreatePriceRange();
            return View(model);
        }
        [HttpGet]
        public ActionResult Purchase(int id)
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.UserID = AuthorizeUtilities.GetUserId(this);
            }

            var repo = VehicleRepositoryFactory.GetRepository();
            var staterepo = StateRepositoryFactory.GetRepository();
            var model = new PurchaseAddViewModel();
            model.VehicleDetails = repo.GetDetails(id);
            model.Purchase.VehicleID = id;
            model.SetStateItems(staterepo.GetAll());
            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseAddViewModel model)
        {
            if (Request.IsAuthenticated)
            {
                model.Purchase.UserID = AuthorizeUtilities.GetUserId(this);
            }

            if (ModelState.IsValid)
            {
                var customerRepo = CustomerRepositoryFactory.GetRepository();
                var purchaseRepo = PurchaseRepositoryFactory.GetRepository();
                try
                {
                    customerRepo.Insert(model.Customer);

                    model.Purchase.CustomerID = model.Customer.CustomerID;
                    model.Purchase.VehicleID = model.VehicleDetails.VehicleID;

                    purchaseRepo.Insert(model.Purchase);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                var repo = VehicleRepositoryFactory.GetRepository();
                var staterepo = StateRepositoryFactory.GetRepository();
                
                model.VehicleDetails = repo.GetDetails(model.VehicleDetails.VehicleID);
                model.Purchase.VehicleID = model.VehicleDetails.VehicleID;
                model.SetStateItems(staterepo.GetAll());

                return View(model);
            }
        }

    }
}
