using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public class Car : IVehicle
    {
        public event Action<IVehicle> OnChange;
        public string Owner { get; set; }
        public Car(string owner) => Owner = owner;

        public void DisplayStatus()
        {
            Console.WriteLine("Car is ready");
            OnChange?.Invoke(this);
        }

        public void StartEngine()
        {
            Console.WriteLine("Car engine started");
            OnChange?.Invoke(this);
        }

        public void StopEngine()
        {
            Console.WriteLine("Car engine stopped");
            OnChange?.Invoke(this);
        }

        public void Add(IVehicle vehicle) { }
        public void Remove(IVehicle vehicle) { }
    }
}
