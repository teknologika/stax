using System;
using System.Collections.Generic;
using System.Text;
using Parkcalc.Observer;

namespace Parkcalc.Observer.Enums
{
    public enum ErrorMessages
    {
        EnterCorrectDate,
        ExitIsBeforeEntry
    }


    

    public static partial class EnumValues
    {
        public static string GetErrorMessage(ErrorMessages errorMessage)
        {
            switch (errorMessage)
            {
                case ErrorMessages.EnterCorrectDate:
                    return "ERROR! Enter A Correctly Formatted Date";
                case ErrorMessages.ExitIsBeforeEntry:
                    return "ERROR! Your Exit Date Or Time Is Before Your Entry Date or Time";
            }
            // required to compile
            return "";
        }
    }
}
