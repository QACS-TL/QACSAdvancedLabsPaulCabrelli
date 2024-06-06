using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public class Lorry : IVehicle
    {

        public event Action<IVehicle> OnChange;
        public string Owner { get; set; }
        public Lorry(string owner) => Owner = owner;

        public void DisplayStatus()
        {
            Console.WriteLine("Lorry is ready");
            OnChange?.Invoke(this);
        }

        public void StartEngine()
        {
            Console.WriteLine("Lorry engine started");
            OnChange?.Invoke(this);
        }

        public void StopEngine()
        {
            Console.WriteLine("Lorry engine stopped");
            OnChange?.Invoke(this);
        }

        public void Add(IVehicle vehicle) { }
        public void Remove(IVehicle vehicle) { }
    }
}
