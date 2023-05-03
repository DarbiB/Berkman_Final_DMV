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
    public class DriversControllerTests
    {
        private DMVContext _context;
        private DriversController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DMVContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            _context = new DMVContext(options);

            // Add test data to the in-memory database
            _context.Drivers.AddRange(new List<Driver>
            {
                new Driver { DriverId = "D999", DriverFirstName = "John",  DriverLastName = "Doe", DriverSsn = "999-99-9999" },
                new Driver { DriverId = "D888", DriverFirstName = "Barbara",  DriverLastName = "Smith", DriverSsn = "888-88-8888" },
                new Driver { DriverId = "D777", DriverFirstName = "Jane",  DriverLastName = "Johnson", DriverSsn = "777-77-7777" },
            });
            _context.SaveChanges();

            _controller = new DriversController(_context);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Dispose the in-memory database after each test
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task GetDrivers_ReturnsAllDrivers()
        {
            // Act
            var result = await _controller.GetDrivers();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<Driver>>));
            Assert.AreEqual(3, result.Value.Count());
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task DeleteDriver_ReturnsNoContent_WhenDriverIdExists()
        {
            // Arrange
            var existingDriverId = "D888";

            // Act
            var result = await _controller.DeleteDriver(existingDriverId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

    }
}
