using System;
using Parkcalc.Observer;
using Parkcalc.Observer.Enums;


namespace Parkcalc.Logical
{
	public class Parking
	{
		public static void OpenHome()
		{
            Physical.NavigateTo.Homepage();
		}

        public static void Calculate(ParkingType parkingType, DateTime inDateTime, DateTime outDateTime)
        {
            Physical.Parking.Calculate(parkingType, inDateTime, outDateTime);
        }

        public static void Calculate(ParkingType parkingType, string inTime, string inAMPM, string inDate, string outTime, string outAMPM, string outDate)
        {
           inDate = Utility.CalculateDate(inDate);
           outDate = Utility.CalculateDate(outDate);
            
           


            Physical.Parking.Calculate(parkingType, inTime, inAMPM, inDate, outTime, outAMPM, outDate);
        }

       

        public static void CalculateAndVerify(ParkingType parkingType, string inTime, string inAMPM, string inDate, string outTime, string outAMPM, string outDate)
        {
            Calculate(parkingType, inTime, inAMPM, inDate, outTime, outAMPM, outDate);
            Verification.Verify.VerifyResult(parkingType, inTime, inAMPM, inDate, outTime, outAMPM, outDate);
            

        }

       
    }
}

