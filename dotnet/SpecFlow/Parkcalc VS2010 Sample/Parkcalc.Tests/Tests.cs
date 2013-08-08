using System;
using Stax.Controllers.Web;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Parkcalc.Observer;
using Parkcalc.Observer.Enums;

using TechTalk.SpecFlow;

namespace Parkcalc.Tests
{
    [TestClass]
	public class Tests : BaseTest
	{
       /*
        
        [Test]
		public void InvalidTextAsEntryDate()
		{
            Parking.Calculate(ParkingType.LongTermSurfaceParking,"12:00","AM","INALID","12:00","AM","TODAY");
            Verify.SpecificErrorIsShown(ErrorMessages.EnterCorrectDate);
		}


        // [Parkcalc.Observer.Version(ApplicationVersion.V1)]
        [Test]
        public void InvalidTextAsExitDate()
        {
            Observer.TestObserver.StartTestObserver();
            Parking.Calculate(ParkingType.LongTermSurfaceParking, "12:00", "AM", "today", "12:00", "AM", "INVALID");
            Verify.SpecificErrorIsShown(ErrorMessages.EnterCorrectDate);
        }

        [Test]
        public void OnlySpecifyEntryDate()
        {
            Parking.Calculate(ParkingType.LongTermSurfaceParking, "12:00", "AM", "today", "12:00", "AM", "");
            Verify.VerifyResult(ParkingType.LongTermSurfaceParking, "12:00", "AM", "today", "12:00", "AM", "");
        }

        [Test]
        public void OnlySpecifyExitDate()
        {
            Parking.CalculateAndVerify(ParkingType.LongTermSurfaceParking, "12:00", "AM", "", "12:00", "AM", "today");
        }

        [Test]
        public void EconomyLessThanOneHour()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "10:00", "AM", "today", "10:59", "AM", "today");
        }

        [Test]
        public void EconomyExactlyOneHour()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "10:00", "AM", "today", "11:00", "AM", "today");
        }

        [Test]
        public void EconomyMoreThanOneHour()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "10:00", "AM", "today", "11:01", "AM", "today");
        }

        [Test]
        public void EconomyJustLessThanOneDay()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "10:00", "AM", "today", "9:59", "AM", "today+1");
        }

        public void EconomyExactlyOneDay()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "10:00", "AM", "today", "10:00", "AM", "today+1");
        }

        [Test]
        public void EconomyJustMoreThanOneDay()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "10:00", "AM", "today", "10:01", "AM", "today+1");
        }

        [Test]
        public void EconomyJustLessThanOneWeek()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "10:00", "AM", "today", "9:59", "AM", "today+7");
        }

        [Test]
        public void EconomyExactlyOneWeek()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "12:00", "AM", "today", "12:00", "AM", "today+1");
        }

        [Test]
        public void EconomySixDays()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "12:00", "AM", "today", "12:00", "AM", "today+6");
        }

        [Test]
        public void EconomyJustMoreThanOneWeek()
        {
            Parking.CalculateAndVerify(ParkingType.EconomyParking, "10:00", "AM", "today", "10:01", "AM", "today+7");
        }
        // snippet example
        */
       
        }
}

