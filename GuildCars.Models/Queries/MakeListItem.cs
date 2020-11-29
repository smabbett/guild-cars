using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class MakeListItem
    {
        public int MakeID { get; set; }
        public string MakeName { get; set; }
        public string UserID { get; set; }
        public DateTime DateAdded { get; set; }
        public string Email { get; set; }
    }
}
