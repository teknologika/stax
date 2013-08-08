using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parkcalc.Physical;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parkcalc.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitions : BaseTest
    {
        [Given(@"I park in (.*$)")]
        public void GivenIParkInShort_TermParking(string lot)
        {
            Physical.Parking.OpenPageAndSelectCarPark(lot);
        }

        [Given(@"I enter at (.*$)")]
        public void GivenIEnterAt(string time)
        {
            Physical.Parking.EnterEntryDateAndTime(time);
        }


        [Given(@"I exit at (.*$)")]
        public void SetEntryTime(string time)
        {
            Physical.Parking.EnterExitDateAndTime(time);
        }

        [Then(@"The parking should cost (.*$)")]
         public void VerifyCost(string expected)
        {
            Physical.Parking.Calculate();
            string actual = Physical.Parking.GetResult();
            bool result = actual.Contains(expected);
            if (result)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.AreEqual(expected, actual);
            }
        }
        
        [AfterScenario]
        public static void AfterWebFeature()
        {
            Physical.NavigateTo.TheEnd();
        }
    }
}
