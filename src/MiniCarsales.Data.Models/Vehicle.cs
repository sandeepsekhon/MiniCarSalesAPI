using System;
using System.Collections.Generic;
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
        public string Make { get; set; }

        public string Model { get; set; }

        public string Engine { get; set; }

        /// <summary>
        /// Type of vehicle - Bike or car.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Number of wheels. Example - For Bike - 2, For Car - 4
        /// </summary>
        public int Wheels { get; set; }
    }
}
