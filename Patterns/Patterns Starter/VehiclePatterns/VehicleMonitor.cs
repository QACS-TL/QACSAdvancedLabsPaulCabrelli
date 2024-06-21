using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public class VehicleMonitor //: IVehicleChangedObserver
    {
		// implement the update method to report status information about the Vehicle or VehicleGroup referenced in the input parameter
		// remember that they both implement the IVehicle interface
		// in the Update method you can use and if statement to differentiate between Vehicle and VehicalGroup to output relevent information to the console

		// for a VehicleGroup 
		// Console.WriteLine($"Vehicle Monitor Update: Status of one of {vehicle.Owner}'s vehicles has been refreshed.");

		// for a Vehicle
		//Console.WriteLine($"Vehicle Update: Status of {vehicle.Owner}'s {vehicle.GetType().Name} has been refreshed.");


    }
}
