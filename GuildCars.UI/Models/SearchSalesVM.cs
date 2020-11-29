using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class SearchSalesVM
    {
        public IEnumerable<SelectListItem> Users { get; set; }

    }
}