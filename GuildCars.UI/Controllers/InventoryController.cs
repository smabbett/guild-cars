using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Vehicle
        public ActionResult Details(int id)
        {        
            var repo = VehicleRepositoryFactory.GetRepository();
            var model = repo.GetDetails(id);

            return View(model);
        }

        public ActionResult New()
        {
            SearchVM model = new SearchVM();
            model.SearchYears = VehicleRepositoryFactory.GetRepository().CreateSearchYears();
            model.PriceRange = VehicleRepositoryFactory.GetRepository().CreatePriceRange();
            return View(model);
        }

        public ActionResult Used()
        {
            SearchVM model = new SearchVM();
            model.SearchYears = VehicleRepositoryFactory.GetRepository().CreateSearchYears();
            model.PriceRange = VehicleRepositoryFactory.GetRepository().CreatePriceRange();
            return View(model);
        }
    }
}