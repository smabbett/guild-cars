using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class FeaturedVehicleItem
    {
        public int VehicleID { get; set; }
        public int VehicleYear { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public string ImageFileName { get; set; }
        public string Vin { get; set; }
    }
}
