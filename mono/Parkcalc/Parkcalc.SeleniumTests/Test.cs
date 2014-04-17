using NUnit.Framework;
using System;

namespace Parkcalc.SeleniumTests
{
	[TestFixture ()]
	public class Test : BaseTest
	{
		[Test ()]
		public void TestCase ()
		{
            string lblMessage = "id='message'";



			Browser.NavigateTo ("http://127.0.0.1:8080");




            string text = Browser.GetValue(lblMessage);




            Assert.AreEqual ("Welcome to ASP.NET MVC on Mono!", text);
		}
	}
}

