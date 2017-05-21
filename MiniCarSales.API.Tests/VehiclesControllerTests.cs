using Microsoft.Extensions.Logging;
using MiniCarsales.Data.Models;
using MiniCarSales.Data.InMemoryRepository;
using MiniCarSalesAPI.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MiniCarSales.API.Tests
{
    public class VehiclesControllerTests
    {
        private readonly Mock<IInMemoryData<Vehicle>> vehicleStorage;
        private readonly Mock<ILogger<VehiclesController>> logger;
        private const string id = "BDA3E16C-209E-4DCD-BF38-378274C572F6";
        public VehiclesControllerTests()
        {
            vehicleStorage = new Mock<IInMemoryData<Vehicle>>();
            var vehicleCollection = new List<Vehicle>();
            var vehicle = new Car
            {
                Id = new Guid(id),
                CarType = "Sedan",
                Doors = 5,
                Engine = "Pulsar",
                Type = "car",
                Model = "MY2014",
                Make = "Nissan"
            };
            vehicleCollection.Add(vehicle);
            vehicleStorage.Setup(t => t.GetAll()).Returns(vehicleCollection);
            vehicleStorage.Setup(t => t.Find(new Guid(id))).Returns(vehicle);
            logger = new Mock<ILogger<VehiclesController>>();
        }

        [Fact]
        public void Should_Get_All()
        {
            var controller = new VehiclesController(vehicleStorage.Object, logger.Object);
            var result = controller.Get();
            Assert.True(result.Count()==1, "Get All Test failed");
            Assert.True(result.FirstOrDefault().Id==new Guid(id), "Get test failed for the items returned");
        }

        [Fact]
        public void Should_Get_By_Id()
        {            
            var controller = new VehiclesController(vehicleStorage.Object, logger.Object);
            var result = controller.Get(new Guid(id));
            Assert.True(result!=null, "Get By Id Test failed");
        }

        [Fact]
        public void Should_Get_By_Id_Fail()
        {
            var controller = new VehiclesController(vehicleStorage.Object, logger.Object);
            var result = controller.Get(new Guid());
            Assert.False(result != null, "Get By Id Test failed for fail case");
        }
    }
}
