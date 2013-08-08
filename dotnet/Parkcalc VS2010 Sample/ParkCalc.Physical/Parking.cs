using System;
using System.Collections.Generic;
using System.Text;
using Parkcalc.Controls;
using Stax.Controllers.Web.Watin;
using Parkcalc.Observer.Enums;
using Parkcalc;



namespace Parkcalc.Physical
{
    public static class Parking
    {
       
        public static void Calculate(ParkingType parkingType, DateTime inDateTime, DateTime outDateTime)
        {
            throw new NotImplementedException();
        }

        public static void Calculate(ParkingType parkingType, string inTime, string inAMPM, string inDate, string outTime, string outAMPM, string outDate)
        {
            NavigateTo.Homepage();
            Browser.SetValue(Controls.ParkingCalculator.ddlLot,EnumValues.GetParkingType(parkingType));
            if (!string.IsNullOrEmpty(inTime))
            {
                Browser.SetValue(Controls.ParkingCalculator.txtEntryTime, inTime);
            }

            if (!string.IsNullOrEmpty(inAMPM))
            {
                Browser.SetValue(Controls.ParkingCalculator.rdoEntryTimeAMPM, inAMPM);
            }

            if (!string.IsNullOrEmpty(inDate))
            {
                Browser.SetValue(Controls.ParkingCalculator.txtEntryDate, inDate);
            }

            if (!string.IsNullOrEmpty(outTime))
            {
                Browser.SetValue(Controls.ParkingCalculator.txtExitTime, outTime);
            }

            if (!string.IsNullOrEmpty(outAMPM))
            {
                Browser.SetValue(Controls.ParkingCalculator.rdoExitTimeAMPM, outAMPM);
            }

            if (!string.IsNullOrEmpty(outDate))
            {
                Browser.SetValue(Controls.ParkingCalculator.txtExitDate, outDate);
            }

            Browser.Invoke(Controls.ParkingCalculator.btnCalculate);
        }

        public static string GetResult()
        {
           return Browser.GetValue(Controls.ParkingCalculator.txtResult);
           
        }
    }


}
