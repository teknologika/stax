using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Parkcalc.Controls
{
    public class URLs
    {
        public static Uri BaseUrl
        {
            get
            {
                return new Uri(ConfigurationManager.AppSettings["BaseUrl"]);
                //return @"http://10.37.129.2/~bruce/parkcalc/";
            }
        }

        public static string HomePage = BaseUrl.ToString();

	}
}