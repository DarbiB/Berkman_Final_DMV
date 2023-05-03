using Berkman_Final_DMV.Controllers;
using Berkman_Final_DMV.Data;
using Berkman_Final_DMV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Berkman_Final_DMV.Tests
{
    [TestClass]
    public class VehiclesControllerTests
    {
        private DMVContext _context;
        private VehiclesController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DMVContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            _context = new DMVContext(options);

            // Add test data to the in-memory database
            _context.Vehicles.AddRange(new List<Vehicle>
            {
                new Vehicle { VehicleId = "V999", DriverId = "D999",  VehiclePlate = "444444" },
                new Vehicle { VehicleId = "V888", DriverId = "D888",  VehiclePlate = "555555" },
                new Vehicle { VehicleId = "V777", DriverId = "D777",  VehiclePlate = "666666" },
            });
            _context.SaveChanges();

            _controller = new VehiclesController(_context);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Dispose the in-memory database after each test
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetVehicles_ReturnsAllVehicles()
        {
            // Act
            var result = await _controller.GetVehicles();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<Vehicle>>));
            Assert.AreEqual(3, result.Value.Count());
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteVehicle_ReturnsNoContent_WhenVehicleIdExists()
        {
            // Arrange
            var existingVehicleId = "V888";

            // Act
            var result = await _controller.DeleteVehicle(existingVehicleId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

    }
}