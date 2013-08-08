using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Globalization;

namespace Parkcalc.Observer
{
    public static class Utility
    {
        public static Object[] GetCallerAttributes(Type attributeType, int stackLevel)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame = trace.GetFrame(stackLevel);
            MethodBase mb = frame.GetMethod();

            return mb.GetCustomAttributes(attributeType, true);
        }

        internal static int GenerateRandomNumber(int minValue, int maxValue)
        {
            Random generator = new Random();
            return generator.Next(minValue, maxValue);
        }

        public static string CalculateDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                return "DD/MM/YYYY";
            }

          
            if (date.ToLower() == "today")
            {
                    date = DateTime.Today.ToShortDateString();
            }
            if (date.Contains("+"))
            {
                string[] split = date.Split('+');
                date = DateTime.Today.AddDays(Convert.ToInt32(split[1])).ToShortDateString();
            }

            if (date.Contains("-"))
            {
                string[] split = date.Split('-');
                Convert.ToInt32(split[1]);
                date = DateTime.Today.AddDays(0 - Convert.ToInt32(split[1])).ToShortDateString();
            }


            return date;
        }
    }

}
