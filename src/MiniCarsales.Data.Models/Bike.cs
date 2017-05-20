using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Data.Models
{
    /// <summary>
    /// Another type of vehicle. Therefore inheriting from base class Vehicle.
    /// </summary>
    public class Bike: Vehicle
    {
        /// <summary>
        /// Possible values - Road, Off-road, etc.
        /// </summary>
        public string BikeType { get; set; }
    }
}
