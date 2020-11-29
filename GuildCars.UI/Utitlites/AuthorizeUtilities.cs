using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace GuildCars.UI.Utitlites
{
    public class AuthorizeUtilities
    {
        public static string GetUserId(Controller controller)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(new ApplicationDbContext()));
            var user = userMgr.FindByName(controller.User.Identity.Name);
            
            return user.Id;
        }

        public static List<AppUser> GetUsersInRole([Control]string ddlRole)
        {
            var db = new ApplicationDbContext();
            var role = db.Roles.SingleOrDefault(m => m.Name == ddlRole);
            var usersInRole = db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList();

            return usersInRole;
        }
    }
}