using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public class VehicleGroup : IVehicle
    {
        private List<IVehicle> _vehicles = new List<IVehicle>();
        public event Action<IVehicle> OnChange;

        public string Owner { get; set; }
        public VehicleGroup(string owner) => Owner = owner;

        public void DisplayStatus()
        {
            foreach (var vehicle in _vehicles)
                vehicle.DisplayStatus();
            //OnChange?.Invoke(this);
        }

        public void StartEngine()
        {
            foreach (var vehicle in _vehicles)
                vehicle.StartEngine();
            //OnChange?.Invoke(this);
        }

        public void StopEngine()
        {
            foreach (var vehicle in _vehicles)
                vehicle.StopEngine();
            OnChange?.Invoke(this);
        }

        public void Add(IVehicle vehicle)
        {
            _vehicles.Add(vehicle);
            vehicle.OnChange += (vehicle) => OnChange?.Invoke(vehicle);
        }

        public void Remove(IVehicle vehicle)
        {
            _vehicles.Remove(vehicle);
            vehicle.OnChange -= (vehicle) => OnChange?.Invoke(vehicle);
        }
    }

}
