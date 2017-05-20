using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MiniCarSales.Data.InMemoryRepository;
using MiniCarsales.Data.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniCarSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class BikeController : Controller
    {
        private readonly IInMemoryData<Vehicle> _vehicleProvider;
        public BikeController(IInMemoryData<Vehicle> vehicleProvider)
        {
            _vehicleProvider = vehicleProvider;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Bike bike)
        {
            _vehicleProvider.Add(bike);
        }

        // PUT api/values/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody]Bike bike)
        {
            _vehicleProvider.Edit(id, bike);
        }

    }
}
