using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public class VehicleGroup : IVehicle
    {
		// Declare and instantiate a private field that will hold the list of vehicles e.g. private List>IVehicle .....


		//implement the IVehicle interface

		// In the DisplayStatus method iterate over the vehicle collection and invoke the DisplayStatus method of each vehicle
		// repeat this for the StartEngine and StopEngine methods invoke the relavent methods on the vehicle refernce in each case.


		// Use the Add method of the VehicleGroup class to insert the vehicle into the private list created earlier and also add code
		// register the event handler for the OnChange event of the vehicle 
		// e.g. if the parameter is named vehicle then
		// vehicle.OnChange += (vehicle) => OnChange?.Invoke(vehicle);
		

		// For the Remove method, remove the vehicle from the private List and also remove the event subscription
		// e.g. vehicle.OnChange -= (vehicle) => OnChange?.Invoke(vehicle);

		
    }

}
