using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniCarsales.Data.Models;
using MiniCarSales.Data.InMemoryRepository;
using System;
using System.Collections.Generic;

namespace MiniCarSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class VehiclesController : Controller
    {
        private readonly IInMemoryData<Vehicle> _vehicleProvider;
        private readonly ILogger<VehiclesController> _logger;
        public VehiclesController(IInMemoryData<Vehicle> vehicleProvider, ILogger<VehiclesController> logger)
        {
            _vehicleProvider = vehicleProvider;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            _logger.LogInformation("Get All vehicles request initiated on Vehicles controller");
            return _vehicleProvider.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id:Guid}")]
        public Vehicle Get(Guid id)
        {
            _logger.LogInformation($"Get by Id method initiated on the controller with id {id}");
            return _vehicleProvider.Find(id);
        }

    }
}
