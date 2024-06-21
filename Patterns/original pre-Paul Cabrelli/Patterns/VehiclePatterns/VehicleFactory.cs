using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePatterns.VehiclePatterns;

namespace VehiclePatterns
{
    public class VehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType)
        {
            switch (vehicleType.ToLower())
            {
                case "car":
                    return new Car("Bob's Used Cars");
                case "lorry":
                    return new Lorry("Bob's Used Lorries");
                case "motorcycle":
                    return new MotorCycle("Bob's Used Bikes");
                default:
                    throw new ArgumentException("Unknown vehicle type.");
            }
        }
    }

}
