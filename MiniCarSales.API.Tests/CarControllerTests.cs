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
    public class CarControllerTests
    {
        private readonly Mock<IInMemoryData<Vehicle>> vehicleStorage;
        private readonly Mock<ILogger<CarController>> logger;
        private const string id = "BDA3E16C-209E-4DCD-BF38-378274C572F6";

        public CarControllerTests()
        {
            vehicleStorage = new Mock<IInMemoryData<Vehicle>>();
            logger = new Mock<ILogger<CarController>>();
            var car = GetCar();
            vehicleStorage.Setup(t => t.Add(It.IsAny<Car>())).Returns(car);
            vehicleStorage.Setup(t => t.Edit(new Guid(id), It.IsAny<Car>())).Returns(true);
        }

        [Fact]
        public void Should_Post_Car()
        {   
            var controller = new CarController(vehicleStorage.Object, logger.Object);
            var car = GetCar();
            var result = controller.Post(car);
            Assert.True(result.GetType()==typeof(CreatedResult), "POST Test failed");
        }

        [Fact]
        public void Should_PUT_Car()
        {
            var controller = new CarController(vehicleStorage.Object, logger.Object);
            var car = GetCar();
            var result = controller.Put(new Guid(id), car);
            Assert.True(result.GetType() == typeof(OkResult), "PUT Test failed for success case");
        }

        [Fact]
        public void Should__NOT_PUT_Car()
        {
            var controller = new CarController(vehicleStorage.Object, logger.Object);
            var car = GetCar();
            var result = controller.Put(new Guid(), car);
            Assert.False(result.GetType() == typeof(OkResult), "PUT Test failed for failure case");
            Assert.True(result.GetType() == typeof(NotFoundResult), "PUT Test failed for failure case");
        }

        private Car GetCar()
        {
            return new Car
            {
                Id = new Guid(id),
                CarType = "Sedan",
                Doors = 5,
                Engine = "Pulsar",
                Type = "car",
                Model = "MY2014",
                Make = "Nissan",
                Wheels = 4
            };
        }

    }
}
