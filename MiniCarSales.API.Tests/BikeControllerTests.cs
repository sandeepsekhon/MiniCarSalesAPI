using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniCarsales.Data.Models;
using MiniCarSales.Data.InMemoryRepository;
using MiniCarSalesAPI.Controllers;
using Moq;
using System;
using Xunit;

namespace MiniCarSales.API.Tests
{
    public class BikeControllerTests
    {
        private readonly Mock<IInMemoryData<Vehicle>> vehicleStorage;
        private readonly Mock<ILogger<BikeController>> logger;
        private const string id = "7A430D63-455D-4F6D-822C-42FA8597308D";

        public BikeControllerTests()
        {
            vehicleStorage = new Mock<IInMemoryData<Vehicle>>();
            logger = new Mock<ILogger<BikeController>>();
            var bike = new Bike
            {
                Id = new Guid(id),
                BikeType = "Road",
                Engine = "Classic",
                Type = "bike",
                Model = "Highlander",
                Make = "BMW"
            };
            vehicleStorage.Setup(t => t.Add(It.IsAny<Bike>())).Returns(bike);
            vehicleStorage.Setup(t => t.Edit(new Guid(id), It.IsAny<Bike>())).Returns(true);
        }

        [Fact]
        public void Should_Post_Bike()
        {
            var controller = new BikeController(vehicleStorage.Object, logger.Object);
            var bike = new Bike
            {
                Id = new Guid(id),
                BikeType = "Road",
                Engine = "Classic",
                Type = "bike",
                Model = "Highlander",
                Make = "BMW"
            };
            var result = controller.Post(bike);
            Assert.True(result.GetType() == typeof(CreatedResult), "POST Test failed");
        }

        [Fact]
        public void Should_PUT_Bike()
        {
            var controller = new BikeController(vehicleStorage.Object, logger.Object);
            var bike = new Bike
            {
                Id = new Guid(id),
                BikeType = "Road",
                Engine = "Classic",
                Type = "bike",
                Model = "Highlander",
                Make = "BMW"
            };
            var result = controller.Put(new Guid(id), bike);
            Assert.True(result.GetType() == typeof(OkResult), "PUT Test failed for success case");
        }

        [Fact]
        public void Should__NOT_PUT_Bike()
        {
            var controller = new BikeController(vehicleStorage.Object, logger.Object);
            var bike = new Bike
            {
                Id = new Guid(id),
                BikeType = "Road",
                Engine = "Classic",
                Type = "bike",
                Model = "Highlander",
                Make = "BMW"
            };
            var result = controller.Put(new Guid(), bike);
            Assert.False(result.GetType() == typeof(OkResult), "PUT Test failed for failure case");
            Assert.True(result.GetType() == typeof(NotFoundResult), "PUT Test failed for failure case");
        }

    }
}
