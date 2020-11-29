using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using System.Data;
using GuildCars.Models.Queries;

namespace GuildCars.Data.ADO
{
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.Price = (decimal)dr["Price"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleType = dr["VehicleType"].ToString();
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.BodyStyleID = (int)dr["BodyStyleID"];
                        currentRow.TransmissionID = (int)dr["TransmissionID"];
                        currentRow.BodyColorID = (int)dr["BodyColorID"];
                        currentRow.InteriorColorID = (int)dr["InteriorColorID"];
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.SaleStatus = (bool)dr["SaleStatus"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public Vehicle GetbyId(int vehicleID)
        {
            Vehicle vehicle = null;
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new Vehicle();
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.VehicleYear = (int)dr["VehicleYear"];
                        vehicle.MakeID = (int)dr["MakeID"];
                        vehicle.ModelID = (int)dr["ModelID"];
                        vehicle.Price = (decimal)dr["Price"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();
                        vehicle.VehicleType = dr["VehicleType"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        vehicle.BodyStyleID = (int)dr["BodyStyleID"];
                        vehicle.TransmissionID = (int)dr["TransmissionID"];
                        vehicle.BodyColorID = (int)dr["BodyColorID"];
                        vehicle.InteriorColorID = (int)dr["InteriorColorID"];
                        vehicle.DateAdded = (DateTime)dr["DateAdded"];
                        vehicle.SaleStatus = (bool)dr["SaleStatus"];
                        vehicle.IsFeatured = (bool)dr["IsFeatured"];
                    }
                }
            }
            return vehicle;
        }

        public VehicleDetailsItem GetDetails(int vehicleID)
        {
            VehicleDetailsItem vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        vehicle = new VehicleDetailsItem();
                        vehicle.VehicleID = (int)dr["VehicleID"];
                        vehicle.VehicleYear = (int)dr["VehicleYear"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.Price = (decimal)dr["Price"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();
                        vehicle.ImageFileName = dr["ImageFileName"].ToString();
                        vehicle.BodyDescription = dr["BodyDescription"].ToString();
                        vehicle.Gears = dr["Gears"].ToString();
                        vehicle.BodyColorName = dr["BodyColorName"].ToString();
                        vehicle.InteriorColorName = dr["InteriorColorName"].ToString();
                        vehicle.SaleStatus = (bool)dr["SaleStatus"];
                    }
                }
            }
            return vehicle;
        }

        public List<FeaturedVehicleItem> GetFeaturedVehicleList()
        {
            List<FeaturedVehicleItem> vehicles = new List<FeaturedVehicleItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FeaturedVehicleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        FeaturedVehicleItem currentRow = new FeaturedVehicleItem();
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Price = (decimal)dr["Price"];
                        currentRow.ImageFileName = dr["ImageFileName"].ToString();
                        currentRow.Vin = dr["Vin"].ToString();

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public void Insert(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("VehicleID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType);
                cmd.Parameters.AddWithValue("@BodyStyleID", vehicle.BodyStyleID);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@BodyColorID", vehicle.BodyColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColorID);
                cmd.Parameters.AddWithValue("@SaleStatus", vehicle.SaleStatus);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleID = (int)param.Value;
            }
        }

        public List<VehicleListItem> Search(InventorySearchParameters parameters)
        {
            List<VehicleListItem> vehicles = new List<VehicleListItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 VehicleID, VehicleYear, mk.MakeName, md.ModelName, bs.BodyDescription, Price, Mileage, Vin, MSRP, VehicleType, ImageFileName, bs.BodyDescription, t.Gears, BodyColorName, InteriorColorName FROM Vehicle v ";
                query += "INNER JOIN Make mk ON v.MakeID = mk.MakeID ";
                query += "INNER JOIN Model md ON V.ModelID = md.ModelID ";
                query += "INNER JOIN BodyStyle bs ON v.BodyStyleID = bs.BodyStyleID ";
                query += "INNER JOIN Transmission t ON v.TransmissionID = t.TransmissionID ";
                query += "INNER JOIN BodyColor bc ON v.BodyColorID = bc.BodyColorID ";
                query += "INNER JOIN InteriorColor ic ON v.InteriorColorID = ic.InteriorColorID ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (!string.IsNullOrEmpty(parameters.VehicleType))
                {
                    query += "WHERE VehicleType = @VehicleType ";
                    cmd.Parameters.AddWithValue("@VehicleType", parameters.VehicleType);
                }
                else
                {
                    query += "WHERE 1 = 1  ";
                }

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND Price >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND Price <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (parameters.MinYear.HasValue)
                {
                    query += "AND VehicleYear >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }

                if (parameters.MaxYear.HasValue)
                {
                    query += "AND VehicleYear <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                if (!string.IsNullOrEmpty(parameters.SearchTextBox))
                {
                    query += "AND (MakeName LIKE @MakeName ";
                    cmd.Parameters.AddWithValue("@MakeName", parameters.SearchTextBox + '%');

                    query += "OR ModelName LIKE @ModelName ";
                    cmd.Parameters.AddWithValue("@ModelName", parameters.SearchTextBox + '%');

                    query += "OR VehicleYear LIKE @VehicleYear) ";
                    cmd.Parameters.AddWithValue("@VehicleYear", parameters.SearchTextBox + '%');
                }

                query += "ORDER BY MSRP DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleListItem row = new VehicleListItem();

                        row.VehicleID = (int)dr["VehicleID"];
                        row.VehicleYear = (int)dr["VehicleYear"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Mileage = (int)dr["Mileage"];
                        row.Vin = dr["Vin"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.ImageFileName = dr["ImageFileName"].ToString();
                        row.BodyDescription = dr["BodyDescription"].ToString();
                        row.Gears = dr["Gears"].ToString();
                        row.BodyColorName = dr["BodyColorName"].ToString();
                        row.InteriorColorName = dr["InteriorColorName"].ToString();           

                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;
        }

        public void Update(Vehicle vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("VehicleId", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@MakeID", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelID", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType);
                cmd.Parameters.AddWithValue("@ImageFileName", vehicle.ImageFileName);
                cmd.Parameters.AddWithValue("@BodyStyleID", vehicle.BodyStyleID);
                cmd.Parameters.AddWithValue("@TransmissionID", vehicle.TransmissionID);
                cmd.Parameters.AddWithValue("@BodyColorID", vehicle.BodyColorID);
                cmd.Parameters.AddWithValue("@InteriorColorID", vehicle.InteriorColorID);
                cmd.Parameters.AddWithValue("@SaleStatus", vehicle.SaleStatus);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<InventoryReportItem> GetInventoryReport(string vehicleType)
        {
            List<InventoryReportItem> vehicles = new List<InventoryReportItem>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@vehicleType", vehicleType);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReportItem currentRow = new InventoryReportItem();
                        
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (decimal)dr["StockValue"];

                        vehicles.Add(currentRow);
                    }
                }
            }
            return vehicles;
        }

        public List<int> CreateSearchYears()
        {
            var date = DateTime.Now.Year;
            var range = date - 1998;
            var searchYears = Enumerable.Range(2000, range).ToList();
            return searchYears;
        }

        public List<int> CreatePriceRange()
        {
            var priceRange = Enumerable.Range(14, 10).Select(x => x * 1000).ToList();
            return priceRange;
        }

        public List<VehicleListItem> SearchSaleable(InventorySearchParameters parameters)
        {
            List<VehicleListItem> vehicles = new List<VehicleListItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT VehicleID, VehicleYear, mk.MakeName, md.ModelName, bs.BodyDescription, Price, Mileage, Vin, MSRP, VehicleType, ImageFileName, bs.BodyDescription, t.Gears, BodyColorName, InteriorColorName FROM Vehicle v ";
                query += "INNER JOIN Make mk ON v.MakeID = mk.MakeID ";
                query += "INNER JOIN Model md ON V.ModelID = md.ModelID ";
                query += "INNER JOIN BodyStyle bs ON v.BodyStyleID = bs.BodyStyleID ";
                query += "INNER JOIN Transmission t ON v.TransmissionID = t.TransmissionID ";
                query += "INNER JOIN BodyColor bc ON v.BodyColorID = bc.BodyColorID ";
                query += "INNER JOIN InteriorColor ic ON v.InteriorColorID = ic.InteriorColorID ";
                query += "WHERE SaleStatus = 1  ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND Price >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND Price <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (parameters.MinYear.HasValue)
                {
                    query += "AND VehicleYear >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }

                if (parameters.MaxYear.HasValue)
                {
                    query += "AND VehicleYear <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                if (!string.IsNullOrEmpty(parameters.SearchTextBox))
                {
                    query += "AND (MakeName LIKE @MakeName ";
                    cmd.Parameters.AddWithValue("@MakeName", parameters.SearchTextBox + '%');

                    query += "OR ModelName LIKE @ModelName ";
                    cmd.Parameters.AddWithValue("@ModelName", parameters.SearchTextBox + '%');

                    query += "OR VehicleYear LIKE @VehicleYear) ";
                    cmd.Parameters.AddWithValue("@VehicleYear", parameters.SearchTextBox + '%');
                }

                query += "ORDER BY MSRP DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleListItem row = new VehicleListItem();

                        row.VehicleID = (int)dr["VehicleID"];
                        row.VehicleYear = (int)dr["VehicleYear"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Mileage = (int)dr["Mileage"];
                        row.Vin = dr["Vin"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.ImageFileName = dr["ImageFileName"].ToString();
                        row.BodyDescription = dr["BodyDescription"].ToString();
                        row.Gears = dr["Gears"].ToString();
                        row.BodyColorName = dr["BodyColorName"].ToString();
                        row.InteriorColorName = dr["InteriorColorName"].ToString();

                        vehicles.Add(row);
                    }
                }
            }

            return vehicles;
        }

        public void Delete(int vehicleID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
