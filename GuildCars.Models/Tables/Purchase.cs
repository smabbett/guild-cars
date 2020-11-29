using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string PurchaseType { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int CustomerID { get; set; }
        public string UserID { get; set; }
        public int VehicleID { get; set; }
        public int? SpecialID { get; set; }

    }
}
