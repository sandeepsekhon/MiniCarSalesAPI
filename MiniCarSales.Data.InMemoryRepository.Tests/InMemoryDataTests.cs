using Microsoft.Extensions.Logging;
using MiniCarsales.Data.Models;
using Moq;
using System;
using Xunit;

namespace MiniCarSales.Data.InMemoryRepository.Tests
{
    public class InMemoryDataTests
    {
        private readonly Mock<ILogger<InMemoryData<Vehicle>>> _logger;
        private const string carid = "BDA3E16C-209E-4DCD-BF38-378274C572F6";
        private const string bikeid = "7A430D63-455D-4F6D-822C-42FA8597308D";

        public InMemoryDataTests()
        {
            _logger = new Mock<ILogger<InMemoryData<Vehicle>>>();
        }

        [Fact]
        public void Should_Add_Car()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);
            var car = GetCar();
            var result = inMemoryRepository.Add(car);
            Assert.True(result != null, "Test Add car failed for success case");
            Assert.True(result.GetType() == typeof(Car), "Test Add car failed for type check success case");
        }

        [Fact]
        public void Should_Add_Bike()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);
            var bike = GetBike();
            var result = inMemoryRepository.Add(bike);
            Assert.True(result != null, "Test Add bike failed for success case");
            Assert.True(result.GetType() == typeof(Bike), "Test Add bike failed for type check success case");
        }

        [Fact]
        public void Should_Not_Add_Bike()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);            
            var result = inMemoryRepository.Add(null);
            Assert.False(result != null, "Test Add bike failed for failure case");
        }

        [Fact]
        public void Should_Find_Vehicle()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);
            var bike = GetBike();
            inMemoryRepository.Add(bike);
            var result = inMemoryRepository.Find(new Guid(bikeid));
            Assert.True(result != null, "Test Find vehicle failed for success case");
            Assert.True(result.GetType() == typeof(Bike), "Test Find vehicle failed for type check success case");
        }

        [Fact]
        public void Should_Not_Find_Vehicle()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);            
            var result = inMemoryRepository.Find(new Guid());
            Assert.Equal(null, result);
        }

        [Fact]
        public void Should_Not_GetAll_Vehicle()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);
            var result = inMemoryRepository.GetAll();
            Assert.True(result != null, " Test GetAll failed for null check in failure case");
            Assert.False(result.Count > 0, "Test GetAll vehicle failed for failure case for items count");
        }

        [Fact]
        public void Should_GetAll_Vehicle()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);
            inMemoryRepository.Add(GetCar());
            var result = inMemoryRepository.GetAll();
            Assert.True(result != null, "Test GetAll failed for null check in success case");
            Assert.True(result.Count > 0, "Test GetAll vehicle failed for success case for items count");
        }

        [Fact]
        public void Should_Edit_Vehicle()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);
            inMemoryRepository.Add(GetCar());
            var result = inMemoryRepository.Edit(new Guid(carid), GetCar());
            Assert.True(result, "Test Edit failed for success case");
        }

        [Fact]
        public void Should__Not_Edit_Vehicle()
        {
            var inMemoryRepository = new InMemoryData<Vehicle>(_logger.Object);
            
            var result = inMemoryRepository.Edit(new Guid(carid), GetCar());
            Assert.False(result, "Test Edit failed for failure case");
        }

        private Bike GetBike()
        {
            return new Bike
            {
                Id = new Guid(bikeid),
                BikeType = "Road",
                Engine = "Classic",
                Type = "bike",
                Model = "Highlander",
                Make = "BMW",
                Wheels = 2
            };
        }

        private Car GetCar()
        {
            return new Car
            {
                Id = new Guid(carid),
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
