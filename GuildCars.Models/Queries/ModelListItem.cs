using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace GuildCars.Models.Queries
{
    public class ModelListItem
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public string Email { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
