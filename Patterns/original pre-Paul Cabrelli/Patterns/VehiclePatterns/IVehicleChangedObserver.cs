using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public interface IVehicleChangedObserver
    {
        void Update(IVehicle vehicle);
    }
}
