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
    public class CarController : Controller
    {
        private readonly IInMemoryData<Vehicle> _vehicleProvider;

        public CarController(IInMemoryData<Vehicle> vehicleProvider)
        {
            _vehicleProvider = vehicleProvider;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Car car)
        {
            if(!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var result = _vehicleProvider.Add(car);
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
        public IActionResult Put(Guid id, [FromBody]Car car)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            if (_vehicleProvider.Edit(id, car))
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
