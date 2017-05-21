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
        public IActionResult Post([FromBody]Bike bike)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var result = _vehicleProvider.Add(bike);
            if (result != null)
            {
                return Created(Request.Scheme + "://" + Request.Host + "/api/vehicles/" + result.Id, result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        // PUT api/values/5
        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody]Bike bike)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            if (_vehicleProvider.Edit(id, bike))
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

    }
}
