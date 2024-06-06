using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public class StopEngineCommand : ICommand
    {
        private readonly IVehicle _vehicle;

        public StopEngineCommand(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.StopEngine();
        }

        public void Undo()
        {
            _vehicle.StartEngine();
        }
    }
}
