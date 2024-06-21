using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclePatterns
{
    public interface IVehicle
    {
		// This interface must require class that implement it to have a Property named Owner of type string also
		// create Method signatures for DisplayStatus , StartEngine , StopEngine (All void with no parameters)

		// In addition create method signatures in this interface to Add and Remove Vehicles, these methods need to accept a parameter of type IVehicle and 
		// will be used later on to implement the Composite Pattern
		// Add OnChange event Signature which will be used to help facilitate the observer pattern
		// e.g. event Action<IVehicle> OnChange

	}

}
