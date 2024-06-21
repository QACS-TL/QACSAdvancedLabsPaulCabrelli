using System.Reflection.Metadata;

namespace VehiclePatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Create and instnce of a VehicleFactory object

            // use the factory object to assign vehicles to the correct type to the variables below
            IVehicle car;
            IVehicle lorry; ;
            IVehicle motorcycle;


			// Create a VehicleGroup object and pass in the Owner in the constructor e.g. VehicleGroup("Bob's Used Vehicles");

			// Now add the three vehicles created earlier to the vehicle group 


			// Create an instance of the VehicleMonitor class

			// Subsribe the update method on the monitor object to the OnChange event of the Vehicle group
			// e.g. vehicleGroup.OnChange += monitor.Update;
			

            // Demonstrating functionality
            // call methods of the VehicleGroup object to Display Staus, start and stop engines, e.g.
            // vehicleGroup.DisplayStatus();
            // vehicleGroup.StartEngine();
            // vehicleGroup.StopEngine();
        }
    }
}
