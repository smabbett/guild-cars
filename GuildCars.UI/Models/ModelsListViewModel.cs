using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class ModelsListViewModel
    {
        public Model Model { get; set; }
        public List<ModelListItem> ModelList { get; set; }
        public List<SelectListItem> MakeList { get; set; }
        public int SelectedMakeId { get; set; }
        public ModelsListViewModel()
        {
            Model = new Model();
            MakeList = new List<SelectListItem>();
            SelectedMakeId = new int();        
        }

        public void SetMakeItems(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                MakeList.Add(new SelectListItem()
                {
                    Value = make.MakeID.ToString(),
                    Text = make.MakeName
                });
            }
        }
    }
}