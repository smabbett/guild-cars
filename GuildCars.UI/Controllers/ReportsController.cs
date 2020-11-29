using GuildCars.Data.Factories;
using GuildCars.UI.Models;
using GuildCars.UI.Utitlites;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            InventoryReportVM model = new InventoryReportVM();
            model.NewVehicles = VehicleRepositoryFactory.GetRepository().GetInventoryReport("new");
            model.UsedVehicles = VehicleRepositoryFactory.GetRepository().GetInventoryReport("used");

            return View(model);
        }

        
        public ActionResult Sales()
        {
            SearchSalesVM model = new SearchSalesVM();
            var userList = AuthorizeUtilities.GetUsersInRole("sales");
            model.Users = from u in userList
                          select new SelectListItem { Text = u.FirstName + ' ' + u.LastName, Value = u.Id.ToString() };
           
            return View(model);
        }
    }
}