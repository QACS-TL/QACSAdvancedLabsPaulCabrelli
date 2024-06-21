using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace VehiclePatterns
    {
        public class MotorCycle : IVehicle
        {
            public event Action<IVehicle> OnChange;
            public string Owner { get; set; }
            public MotorCycle(string owner) => Owner = owner;

            public void DisplayStatus()
            {
                Console.WriteLine("Motorcycle is ready");
                OnChange?.Invoke(this);
            }

            public void StartEngine()
            {
                Console.WriteLine("Motorcycle engine started");
                OnChange?.Invoke(this);
            }

            public void StopEngine()
            {
                Console.WriteLine("Motorcycle engine stopped");
                OnChange?.Invoke(this);
            }

            public void Add(IVehicle vehicle) { }
            public void Remove(IVehicle vehicle) { }
        }
    }

}
