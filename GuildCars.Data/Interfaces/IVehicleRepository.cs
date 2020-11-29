using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle GetbyId(int vehicleId);
        List<Vehicle> GetAll();
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        VehicleDetailsItem GetDetails(int vehicleID);
        List<FeaturedVehicleItem> GetFeaturedVehicleList();
        List<VehicleListItem> Search(InventorySearchParameters parameters);
        List<VehicleListItem> SearchSaleable(InventorySearchParameters parameters);
        List<InventoryReportItem> GetInventoryReport(string vehicleType);
        List<int> CreateSearchYears();
        List<int> CreatePriceRange();
        void Delete(int vehicleID);
    }
}
