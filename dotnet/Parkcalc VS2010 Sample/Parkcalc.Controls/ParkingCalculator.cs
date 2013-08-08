using System;
using System.Collections.Generic;
using System.Text;

namespace Parkcalc.Controls
{
    public class ParkingCalculator
    {
        public static string btnCalculate = "type=button;name=Submit";
        public static string rdoEntryTimeAMPM = "type=radiobutton;name=EntryTimeAMPM";
        public static string rdoExitTimeAMPM = "type=radiobutton;name=ExitTimeAMPM";
        public static string ddlLot = "type=select;id=Lot";
        public static string txtEntryTime = "type=text;id=EntryTime";
        public static string txtEntryDate = "type=text;id=EntryDate";
        public static string txtExitTime = "type=text;id=ExitTime";
        public static string txtExitDate = "type=text;id=ExitDate";
        public static string txtAction = "type=text;name=action";
        public static string txtResult = "type=div;id=result";
    }
}
