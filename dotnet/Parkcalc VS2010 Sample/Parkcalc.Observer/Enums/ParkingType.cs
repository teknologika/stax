using System;
using System.Collections.Generic;
using System.Text;
using Parkcalc.Observer;

namespace Parkcalc.Observer.Enums
{
    public enum ParkingType
    {
        ShortTermParking,
        EconomyParking,
        LongTermSurfaceParking,
        LongTermGarageParking,
        ValetParking
    }

    public static partial class EnumValues
    {
        public static string GetParkingType(ParkingType parkingType)
        {
            switch (parkingType)
	        {
		        case ParkingType.ShortTermParking:
                    return "Short-Term Parking";
                case ParkingType.EconomyParking:
                    return "Economy Parking";
                case ParkingType.LongTermSurfaceParking:
                    return "Long-Term Surface Parking";
                case ParkingType.LongTermGarageParking:
                    return "Long-Term Garage Parking";
                case ParkingType.ValetParking:
                    return "Valet Parking";
	        }
            // required to compile
            return "";
        }
    }
}
