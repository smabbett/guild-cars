using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SearchVM
    {
        public List<int> SearchYears { get; set; }
        public List<int> PriceRange { get; set; }
    }
}