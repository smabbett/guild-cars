using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        
        public int VehicleID { get; set; }
        public int VehicleYear { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public decimal MSRP { get; set; }
        public string VehicleDescription { get; set; }
        public string VehicleType { get; set; }
        public string ImageFileName { get; set; }
        public int BodyStyleID { get; set; }
        public int TransmissionID { get; set; }
        public int BodyColorID { get; set; }
        public int InteriorColorID { get; set; }
        public DateTime DateAdded { get; set; }
        public bool SaleStatus { get; set; }
        public bool IsFeatured { get; set; }

    }
}
