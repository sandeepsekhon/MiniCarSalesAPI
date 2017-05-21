using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Data.Models
{
    /// <summary>
    /// Base class for the vehicles.
    /// </summary>
    public abstract class Vehicle
    {
        public Vehicle()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Identifier for the vehicle. It allows managing of the data in storage.
        /// </summary>
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the Make of the vehicle.")]
        public string Make { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the Make of the vehicle.")]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the value for the engine of the vehicle.")]
        public string Engine { get; set; }

        /// <summary>
        /// Type of vehicle - Bike or car.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of wheels. Example - For Bike - 2, For Car - 4
        /// </summary>
        [Required(ErrorMessage = "Please provide the number of wheels.")]
        public int? Wheels { get; set; }
    }
}
