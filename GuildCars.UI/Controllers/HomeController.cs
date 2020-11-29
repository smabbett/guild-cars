using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FeaturedVehiclesSpecialsVM model = new FeaturedVehiclesSpecialsVM();
            model.FeaturedVehicles = VehicleRepositoryFactory.GetRepository().GetFeaturedVehicleList();
            model.Specials = SpecialRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        public ActionResult Specials()
        {
            var repo = SpecialRepositoryFactory.GetRepository();
            var model = repo.GetAll();

            return View(model);
        }
        [HttpGet]
        public ActionResult Contact(string vin)
        {
            var repo = ContactRepositoryFactory.GetRepository();
            var model = new ContactAddVM();
            if (!string.IsNullOrEmpty(vin))
            {
                model.Contact.Message = vin;
            }
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(ContactAddVM model)
        {
            if (ModelState.IsValid)
            {
                var repo = ContactRepositoryFactory.GetRepository();

                try
                {
                    repo.Insert(model.Contact);
                    return View(model);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return View(model);
            }  
        }
    }
}