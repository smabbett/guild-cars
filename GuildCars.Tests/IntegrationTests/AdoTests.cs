using GuildCars.Data.ADO;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakeRepositoryADO();

            var makes = repo.GetAll();

            Assert.AreEqual(4, makes.Count);
            Assert.AreEqual("Chevrolet", makes[0].MakeName);
            Assert.AreEqual("Volkswagen", makes[3].MakeName);
            Assert.AreEqual(3, makes[3].MakeID);
        }
        [Test]
        public void CanLoadInteriorColors()
        {
            var repo = new InteriorColorRepositoryADO();
            var colors = repo.GetAll();

            Assert.AreEqual(5, colors.Count);
            Assert.AreEqual("Black", colors[0].InteriorColorName);
            Assert.AreEqual("Gold", colors[1].InteriorColorName);
            Assert.AreEqual("White", colors[4].InteriorColorName);
            Assert.AreEqual(5, colors[1].InteriorColorID);
        }

        [Test]
        public void CanLoadBodyColors()
        {
            var repo = new BodyColorRepositoryADO();

            var colors = repo.GetAll();

            Assert.AreEqual(5, colors.Count);
            Assert.AreEqual("Black", colors[0].BodyColorName);
            Assert.AreEqual("Red", colors[3].BodyColorName);
            Assert.AreEqual(5, colors[2].BodyColorID);
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStyleRepositoryADO();

            var styles = repo.GetAll();

            Assert.AreEqual(4, styles.Count);
            Assert.AreEqual("Car", styles[0].BodyDescription);
            Assert.AreEqual("Truck", styles[2].BodyDescription);
            Assert.AreEqual(4, styles[3].BodyStyleID);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new ModelRepositoryADO();

            var models = repo.GetAll();

            Assert.AreEqual(10, models.Count);
            Assert.AreEqual("Beetle", models[1].ModelName);
            Assert.AreEqual("Fiesta", models[4].ModelName);
            Assert.AreEqual(5, models[2].ModelID);
        }

        [Test]
        public void CanLoadPurchases()
        {
            var repo = new PurchaseRepositoryADO();

            var purchases = repo.GetAll();

            Assert.AreEqual(3, purchases.Count);
            Assert.AreEqual(5, purchases[2].VehicleID);
            Assert.AreEqual(3, purchases[2].CustomerID);
            Assert.AreEqual("Dealer Finance", purchases[2].PurchaseType);
        }

        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialRepositoryADO();

            var specials = repo.GetAll();

            Assert.AreEqual(3, specials.Count);
            Assert.AreEqual("Prius Lease", specials[2].Title);
            Assert.AreEqual("Bring your car for service today! Alignment only $99.99!", specials[1].SpecialDescription);
            Assert.AreEqual(1, specials[0].SpecialID);
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StateRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(25, states.Count);
            Assert.AreEqual("AR", states[2].StateID);
            Assert.AreEqual("Minnesota", states[22].StateName);
        }

        [Test]
        public void CanLoadTransmissions()
        {
            var repo = new TransmissionRepositoryADO();

            var transmissions = repo.GetAll();

            Assert.AreEqual(2, transmissions.Count);
            Assert.AreEqual("Manual", transmissions[1].Gears);
            Assert.AreEqual(1, transmissions[0].TransmissionID);
        }

        [Test]
        public void CanLoadVehicles()
        {
            var repo = new VehicleRepositoryADO();

            var vehicles = repo.GetAll();

            Assert.AreEqual(8, vehicles.Count);
            Assert.AreEqual(3, vehicles[2].VehicleID);
            Assert.AreEqual(2010, vehicles[2].VehicleYear);
            Assert.AreEqual("Used", vehicles[1].VehicleType);
            Assert.AreEqual(5, vehicles[4].BodyColorID);
        }
        [Test]
        public void CanLoadContacts()
        {
            var repo = new ContactRepositoryADO();

            var contacts = repo.GetAll();

            Assert.AreEqual(5, contacts.Count);
            Assert.AreEqual("Oscar Smith", contacts[2].FullName);
            Assert.AreEqual("I want to make an offer on this vehicle.", contacts[3].Message);
            Assert.AreEqual("612-333-3333", contacts[2].Phone);
        }
        [Test]
        public void CanLoadCustomers()
        {
            var repo = new CustomerRepositoryADO();

            var customers = repo.GetAll();

            Assert.AreEqual(3, customers.Count);
            Assert.AreEqual("Sarah Nelson", customers[2].FullName);
            Assert.AreEqual("111 Oak Street", customers[1].Street1);
            Assert.AreEqual("Vail", customers[0].City);
        }
        [Test]
        public void CanLoadVehiclebyId()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetbyId(1);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual("1GKUKKE30AR251404", vehicle.Vin);
            Assert.AreEqual(2008, vehicle.VehicleYear);
            Assert.AreEqual("Used", vehicle.VehicleType);
            Assert.AreEqual(1, vehicle.TransmissionID);
            Assert.AreEqual(1, vehicle.BodyColorID);
        }

        [Test]
        public void NotFoundVehicleReturnsNull()
        {
            var repo = new VehicleRepositoryADO();
            var vehicle = repo.GetbyId(1000000);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanAddVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.VehicleYear = 2016;
            vehicleToAdd.MakeID = 3;
            vehicleToAdd.ModelID = 1;
            vehicleToAdd.Price = 24000;
            vehicleToAdd.Mileage = 1000;
            vehicleToAdd.Vin = "1GNDU23W27D181467";
            vehicleToAdd.MSRP = 26000;
            vehicleToAdd.VehicleDescription = "Beauty";
            vehicleToAdd.VehicleType = "New";
            vehicleToAdd.ImageFileName = "placeholder.png";
            vehicleToAdd.BodyStyleID = 1;
            vehicleToAdd.TransmissionID = 2;
            vehicleToAdd.BodyColorID = 3;
            vehicleToAdd.InteriorColorID = 2;
            vehicleToAdd.SaleStatus = true;
            vehicleToAdd.IsFeatured = true;

            repo.Insert(vehicleToAdd);

            Assert.AreEqual(9, vehicleToAdd.VehicleID);
        }

        [Test]
        public void CanUpdateVehicle()
        {
            Vehicle vehicleToAdd = new Vehicle();
            var repo = new VehicleRepositoryADO();

            vehicleToAdd.VehicleYear = 2016;
            vehicleToAdd.MakeID = 3;
            vehicleToAdd.ModelID = 1;
            vehicleToAdd.Price = 24000;
            vehicleToAdd.Mileage = 1000;
            vehicleToAdd.Vin = "1GNDU23W27D181467";
            vehicleToAdd.MSRP = 26000;
            vehicleToAdd.VehicleDescription = "Beauty";
            vehicleToAdd.VehicleType = "New";
            vehicleToAdd.ImageFileName = "placeholder.png";
            vehicleToAdd.BodyStyleID = 1;
            vehicleToAdd.TransmissionID = 2;
            vehicleToAdd.BodyColorID = 3;
            vehicleToAdd.InteriorColorID = 2;
            vehicleToAdd.SaleStatus = true;
            vehicleToAdd.IsFeatured = true;

            repo.Insert(vehicleToAdd);

            vehicleToAdd.VehicleDescription = "What a beauty!";
            vehicleToAdd.MSRP = 28000;
            vehicleToAdd.ImageFileName = "placeholder2.png";
            vehicleToAdd.IsFeatured = false;

            repo.Update(vehicleToAdd);

            var updatedVehicle = repo.GetbyId(9);

            Assert.AreEqual("What a beauty!", updatedVehicle.VehicleDescription);
            Assert.AreEqual("placeholder2.png", updatedVehicle.ImageFileName);
            Assert.AreEqual("New", updatedVehicle.VehicleType);
            Assert.AreEqual(9, updatedVehicle.VehicleID);
        }

        [Test]
        public void CanLoadVehicleDetails()
        {
            var repo = new VehicleRepositoryADO();

            var vehicle = repo.GetDetails(1);

            Assert.IsNotNull(vehicle);
            Assert.AreEqual("1GKUKKE30AR251404", vehicle.Vin);
            Assert.AreEqual(2008, vehicle.VehicleYear);
            Assert.AreEqual("Chrysler", vehicle.MakeName);
            Assert.AreEqual("300", vehicle.ModelName);
            Assert.AreEqual("Car", vehicle.BodyDescription);
            Assert.AreEqual("Automatic", vehicle.Gears);
            Assert.AreEqual("Grey", vehicle.InteriorColorName);
            Assert.AreEqual("Blue", vehicle.BodyColorName);
        }

        [Test]
        public void CanLoadFeaturedVehiclesList()
        {
            var repo = new VehicleRepositoryADO();

            List<FeaturedVehicleItem> featuredList = repo.GetFeaturedVehicleList();

            Assert.IsNotNull(featuredList);
            Assert.AreEqual(5, featuredList.Count());
            Assert.AreEqual(2008, featuredList[0].VehicleYear);
            Assert.AreEqual("Ford", featuredList[1].MakeName);
            Assert.AreEqual("Beetle", featuredList[2].ModelName);
            Assert.AreEqual(13000, featuredList[0].Price);
            Assert.AreEqual("1GKUKKE30AR251404", featuredList[0].Vin);
           
        }

        [Test]
        public void CanAddSpecial()
        {
            Special specialToAdd = new Special();
            var repo = new SpecialRepositoryADO();

            specialToAdd.Title = "The Greatest Sale Ever!";
            specialToAdd.SpecialDescription = "We're offering 50% off all used vehicles until the end of the day!";
            specialToAdd.UserID = "00000000-0000-0000-0000-000000000000";

            repo.Insert(specialToAdd);

            Assert.AreEqual(4, specialToAdd.SpecialID);
        }

        [Test]
        public void CanDeleteSpecial()
        {
            Special specialToAdd = new Special();
            var repo = new SpecialRepositoryADO();

            specialToAdd.Title = "The Greatest Sale Ever!";
            specialToAdd.SpecialDescription = "We're offering 50% off all used vehicles until the end of the day!";
            specialToAdd.UserID = "00000000-0000-0000-0000-000000000000";

            repo.Insert(specialToAdd);

            Assert.AreEqual(4, specialToAdd.SpecialID);

            repo.Delete(4);
            var specials = repo.GetAll();
            Assert.AreEqual(3, specials.Count());
        }

        [Test]
        public void CanAddPurchase()
        {
            Purchase purchaseToAdd = new Purchase();
            var repo = new PurchaseRepositoryADO();

            purchaseToAdd.PurchaseType = "Cash";
            purchaseToAdd.PurchasePrice = 20000M;
            purchaseToAdd.CustomerID = 2;
            purchaseToAdd.UserID = "00000000-0000-0000-0000-000000000000";
            purchaseToAdd.SpecialID = 1;
            purchaseToAdd.VehicleID = 4;

            repo.Insert(purchaseToAdd);

            Assert.AreEqual(4, purchaseToAdd.PurchaseID);
        }

        [Test]
        public void CanLoadMakeList()
        {
            var repo = new MakeRepositoryADO();

            List<MakeListItem> makeList = repo.GetMakeList();

            Assert.IsNotNull(makeList);
            Assert.AreEqual(4, makeList.Count());
            Assert.AreEqual("Chrysler", makeList[1].MakeName);
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", makeList[2].UserID);
            Assert.AreEqual("john@test.com", makeList[3].Email);

        }

        [Test]
        public void CanLoadModelList()
        {
            var repo = new ModelRepositoryADO();

            List<ModelListItem> modelList = repo.GetModelList();

            Assert.IsNotNull(modelList);
            Assert.AreEqual(10, modelList.Count());
            Assert.AreEqual(6, modelList[1].ModelID);
            Assert.AreEqual("Cruze", modelList[1].ModelName);
            Assert.AreEqual("Chevrolet", modelList[2].MakeName);
            Assert.AreEqual("john@test.com", modelList[2].Email);

        }

        [Test]
        public void CanSearchOnMinPrice()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new InventorySearchParameters { MinPrice = 17000M });

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanSearchOnMaxPrice()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new InventorySearchParameters { MaxPrice = 15000M });

            Assert.AreEqual(4, found.Count());
        }

        [Test]
        public void CanSearchOnVehicleTypeandMinPrice()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new InventorySearchParameters { MinPrice = 15000M, VehicleType = "New" });

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanSearchMakeModelYear()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new InventorySearchParameters { SearchTextBox = "Volk" });

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void CanSearchMakeModelYearandVehicleType()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.Search(new InventorySearchParameters { SearchTextBox = "Volk", VehicleType = "New" });

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanSearchSaleableOnMinPrice()
        {
            var repo = new VehicleRepositoryADO();

            var found = repo.SearchSaleable(new InventorySearchParameters { MinPrice = 17000M });

            Assert.AreEqual(3, found.Count());
        }
    }

}

