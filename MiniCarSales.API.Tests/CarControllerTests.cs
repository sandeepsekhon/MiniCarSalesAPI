using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniCarsales.Data.Models;
using MiniCarSales.Data.InMemoryRepository;
using MiniCarSalesAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MiniCarSales.API.Tests
{
    public class CarControllerTests
    {
        private readonly Mock<IInMemoryData<Vehicle>> vehicleStorage;
        private readonly Mock<ILogger<CarController>> logger;
        private const string id = "BDA3E16C-209E-4DCD-BF38-378274C572F6";

        public CarControllerTests()
        {
            vehicleStorage = new Mock<IInMemoryData<Vehicle>>();
            logger = new Mock<ILogger<CarController>>();
            var car = new Car
            {
                Id = new Guid(id),
                CarType = "Sedan",
                Doors = 5,
                Engine = "Pulsar",
                Type = "car",
                Model = "MY2014",
                Make = "Nissan"
            };
            vehicleStorage.Setup(t => t.Add(It.IsAny<Car>())).Returns(car);
        }

        [Fact]
        public void Should_Post_Car()
        {   
            var controller = new CarController(vehicleStorage.Object, logger.Object);
            var car = new Car
            {
                Id = new Guid(id),
                CarType = "Sedan",
                Doors = 5,
                Engine = "Pulsar",
                Type = "car",
                Model = "MY2014",
                Make = "Nissan"
            };
            var result = controller.Post(car);
            Assert.True(result.GetType()==typeof(CreatedResult), "POST Test failed");
        }

    }
}
