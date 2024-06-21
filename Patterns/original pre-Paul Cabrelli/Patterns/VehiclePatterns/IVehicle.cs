using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public interface IVehicle
    {
        string Owner { get;  }
        void DisplayStatus();
        void StartEngine();
        void StopEngine();
        void Add(IVehicle vehicle);
        void Remove(IVehicle vehicle);
        event Action<IVehicle> OnChange; // Event to notify observers of changes
        
    }

}
