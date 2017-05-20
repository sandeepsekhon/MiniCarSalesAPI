using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        public VehiclesController(IInMemoryData<Vehicle> vehicleProvider)
        {
            _vehicleProvider = vehicleProvider;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicleProvider.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id:Guid}")]
        public Vehicle Get(Guid id)
        {
            return _vehicleProvider.Find(id);
        }

    }
}
