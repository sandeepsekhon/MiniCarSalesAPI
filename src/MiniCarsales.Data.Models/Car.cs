using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Data.Models
{
    /// <summary>
    /// Car - Type of vehicle. Therefore inheriting from Vehicle class.
    /// </summary>
    public class Car: Vehicle
    {
        /// <summary>
        /// Number of doors.
        /// </summary>
        public int Doors { get; set; }

        /// <summary>
        /// Possible values - Sedan, Hatchback, SUV, Wagon, etc.
        /// </summary>
        public string CarType { get; set; }
    }
}
