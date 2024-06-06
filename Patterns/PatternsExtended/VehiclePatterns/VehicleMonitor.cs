using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public class VehicleMonitor : IVehicleChangedObserver
    {
        public void Update(IVehicle vehicle)
        {
            if (vehicle is VehicleGroup)
                Console.WriteLine($"Vehicle Monitor Update: Status of one of {vehicle.Owner}'s vehicles has been refreshed.");
            else
                Console.WriteLine($"Vehicle Update: Status of {vehicle.Owner}'s {vehicle.GetType().Name} has been refreshed.");
        }
    }
}
