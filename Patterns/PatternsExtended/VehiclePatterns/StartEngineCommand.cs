using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public class StartEngineCommand : ICommand
    {
        private readonly IVehicle _vehicle;

        public StartEngineCommand(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.StartEngine();
        }

        public void Undo()
        {
            _vehicle.StopEngine();
        }
    }

}
