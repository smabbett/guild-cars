using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Special
    {
        public int SpecialID { get; set; }
        public string Title { get; set; }
        public string SpecialDescription { get; set; }
        public string UserID { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
