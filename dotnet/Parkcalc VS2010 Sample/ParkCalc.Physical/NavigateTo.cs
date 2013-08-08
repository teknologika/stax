using System;
using Stax.Controllers.Web.Watin;
using Parkcalc.Controls;

namespace Parkcalc.Physical
{
    public sealed class NavigateTo
    {
        public static void Homepage()
        {
			Browser.GoTo(URLs.HomePage); 
        }
	}
}
