using System;
using System.Collections.Generic;
using System.Text;
using Parkcalc.Controls;
using Stax.Controllers.Web;
using Parkcalc.Observer.Enums;
using Parkcalc;
using Stax.Controllers.Web.Watin;



namespace Parkcalc.Physical
{
    public static class Parking
    {
      
        public static void OpenPageAndSelectCarPark(string carPark)
        {
            NavigateTo.Homepage();
            Browser.SetValue(Controls.ParkingCalculator.ddlLot, carPark);
        }

        public static void EnterEntryDateAndTime(string dateTime)
        {
            DateTime cleanDateTime = DateTime.Parse(dateTime);

            Browser.SetValue(Controls.ParkingCalculator.txtEntryTime, cleanDateTime.ToString("hh:mm"));
            Browser.SetValue(Controls.ParkingCalculator.rdoEntryTimeAMPM, cleanDateTime.ToString("tt"));
            Browser.SetValue(Controls.ParkingCalculator.txtEntryDate,cleanDateTime.ToShortDateString() );
        }

        public static void EnterExitDateAndTime(string dateTime)
        {
            DateTime cleanDateTime = DateTime.Parse(dateTime);

            Browser.SetValue(Controls.ParkingCalculator.txtExitTime, cleanDateTime.ToString("hh:mm"));
            Browser.SetValue(Controls.ParkingCalculator.rdoExitTimeAMPM, cleanDateTime.ToString("tt"));
            Browser.SetValue(Controls.ParkingCalculator.txtExitDate, cleanDateTime.ToShortDateString());
        }

        public static void Calculate()
        {
            Browser.Invoke(Controls.ParkingCalculator.btnCalculate);
        }

        public static string GetResult()
        {
           return Browser.GetValue(Controls.ParkingCalculator.txtResult);

        }
    }


}
