using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parkcalc.Observer;
using Parkcalc.Observer.Enums;
using Parkcalc.Physical;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace Parkcalc.Verification
{
    public static class Verify
    {
        public static void ErrorIsShown()
        {
            bool errorIsShown = Physical.Parking.GetResult().Contains("ERROR");
            if (errorIsShown)
            {
                Assert.IsTrue(errorIsShown, "Error shown was: " + Physical.Parking.GetResult() + ".");
            }
        }

        public static void NoErrorIsShown()
        {
            Assert.IsTrue(!Physical.Parking.GetResult().Contains("ERROR"), "An error was shown when it was not expected./n The Error shown was: " + Physical.Parking.GetResult() + ".");
        }

        public static bool SpecificErrorIsShown(ErrorMessages errorMessage)
        {
            Assert.AreEqual(EnumValues.GetErrorMessage(errorMessage), Physical.Parking.GetResult());
            // if the error is shown, return true
            return true;
        }

       

        public static void VerifyResult(ParkingType parkingType, string inTime, string inAMPM, string inDate, string outTime, string outAMPM, string outDate)
        {
            bool errorIsShown = false;
            

            inDate = Utility.CalculateDate(inDate);
            outDate = Utility.CalculateDate(outDate);
            
            DateTime entryDateTime = DateTime.MinValue, exitDateTime = DateTime.MinValue;
            
            // Convert entry and exit to a Date time. If we can't convert then the app should be displaying an error
            try
            {
                entryDateTime = Convert.ToDateTime(inDate + " " + inTime + "  " + inAMPM); 
            }
            catch (Exception)
            {
                // Date or time is invalid, we should show an error.
                errorIsShown = SpecificErrorIsShown(ErrorMessages.EnterCorrectDate);
            }

            try
            {
                exitDateTime = Convert.ToDateTime(outDate + " " + outTime + "  " + outAMPM);
            }
            catch (Exception)
            {
                // Date or time is invalid, we should show an error.
                errorIsShown = SpecificErrorIsShown(ErrorMessages.EnterCorrectDate);
            }

            // if we have shown the error, the date is not valid so exit and pass the test
            if (!errorIsShown)
            {
                VerifyResult(parkingType, entryDateTime, exitDateTime);
            }

        }

        public static void VerifyResult(ParkingType parkingType, DateTime inDateTime, DateTime outDateTime)
        {
            TimeSpan ts = (outDateTime - inDateTime);
            int days = ts.Days;
            int Remaininghours = ts.Hours;
            int Remainingminutes = ts.Minutes;
            int ChargableWeeks = 0, ChargableDays = 0, ChargableHours = 0;
            decimal cost = 0;

            switch (parkingType)
            {
                case ParkingType.ShortTermParking:
                    // $2 first hour; $1 each additional 1/2 hour $24 daily maximum
                    break;
                case ParkingType.EconomyParking:
                    // $2 per hour $9 daily maximum $54 per week (7th day free)
                    // NOTE: The "spec" says $2 per hour, but the app has $4 per hour
                    int EconomyBaseRate = 2;

                    // Calculate weeks
                    ChargableWeeks = days / 7;
                    cost = ChargableWeeks * 54;
                    
                    // calculate days
                    ChargableDays = days % 7;
                
                    cost = cost + ChargableDays * 9;

                    // calculate hours
                    ChargableHours = Remaininghours;
                    int hourCost = Remaininghours * EconomyBaseRate;
                    if (hourCost > 9)
                    {
                        hourCost = 9;
                    }

                    if ((Remainingminutes > 0) && (hourCost < 7))
                    {
                        cost = cost + hourCost + EconomyBaseRate;
                    }
                    else
                    {
                        cost = cost + hourCost;
                    }
                    
                    break;
                case ParkingType.LongTermSurfaceParking:
                    // $2 per hour $10 daily maximum $60 per week (7th day free)
                    break;
                case ParkingType.LongTermGarageParking:
                    // $2 per hour $12 daily maximum $72 per week (7th day free)
                    break;
                case ParkingType.ValetParking:
                    // $18 per day $12 for five hours or less
                    break;
            }
            
            // Cleanup the result and tokenise it into an array
            Regex regex = new Regex(@"\s{2,}",RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
            string actual = regex.Replace(Physical.Parking.GetResult().Trim()," ");
            string[] splitResult = actual.Split(' ');

            
            Assert.AreEqual(days,Convert.ToInt32(splitResult[2].Replace("(","")),"Verification of number of days.");
            Assert.AreEqual(ChargableHours,Convert.ToInt32(splitResult[4]),"Verification of number of hours");
            Assert.AreEqual(Remainingminutes, Convert.ToInt32(splitResult[6]), "Verifciation of number of minutes.");
            Assert.AreEqual("$" + cost.ToString("#,#.00#"), "$" + splitResult[1]);

            
            //$ 4.00 (0 Days, 0 Hours, 59 Minutes)

        }
    }
}
