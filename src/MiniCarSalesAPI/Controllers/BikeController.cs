using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniCarsales.Data.Models;
using MiniCarSales.Data.InMemoryRepository;
using System;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniCarSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class BikeController : Controller
    {
        private readonly IInMemoryData<Vehicle> _vehicleProvider;
        private readonly ILogger<BikeController> _logger;
        public BikeController(IInMemoryData<Vehicle> vehicleProvider, ILogger<BikeController> logger)
        {
            _vehicleProvider = vehicleProvider;
            _logger = logger;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Bike bike)
        {
            if (!this.ModelState.IsValid)
            {
                _logger.LogError("Invalid data sent to the Post method", this.ModelState, bike);
                return BadRequest(this.ModelState);
            }
            var result = _vehicleProvider.Add(bike);
            if (result != null)
            {
                return Created(Request?.Scheme + "://" + Request?.Host + "/api/vehicles/" + result?.Id, result);
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
                _logger.LogError("Invalid data sent to the PUT method", this.ModelState, bike);
                return BadRequest(this.ModelState);
            }
            if (_vehicleProvider.Edit(id, bike))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
