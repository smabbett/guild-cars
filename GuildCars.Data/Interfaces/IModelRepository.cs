using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetAll();
        void Insert(Model model);
        List<ModelListItem> GetModelList();
        List<Model> GetModelsByMake(int id);
    }
}
