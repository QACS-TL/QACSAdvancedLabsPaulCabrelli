namespace VehiclePatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory factory = new VehicleFactory();
            IVehicle car = factory.CreateVehicle("car");
            IVehicle lorry = factory.CreateVehicle("lorry");
            IVehicle motorcycle = factory.CreateVehicle("motorcycle");

            VehicleGroup vehicleGroup = new VehicleGroup("Bob's Used Vehicles");

            vehicleGroup.Add(car);
            vehicleGroup.Add(lorry);
            vehicleGroup.Add(motorcycle);

            // Monitor setup
            VehicleMonitor monitor = new VehicleMonitor();
            //car.OnChange += monitor.Update;
            //lorry.OnChange += monitor.Update;
            //motorcycle.OnChange += monitor.Update;
            vehicleGroup.OnChange += monitor.Update;

            // Demonstrating functionality
            vehicleGroup.DisplayStatus();
            vehicleGroup.StartEngine();
            vehicleGroup.StopEngine();
        }
    }
}
