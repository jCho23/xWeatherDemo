﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace xWeatherDemo
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            app.Screenshot("App Launched");
			//PRO-TIP: This is an easy way to make sure that the app successfully launches before the tests begin
		}

        [Test]
        public void Repl()
        {
            app.Repl();
			//PRO-TIP: The REPL is a console-like environment in which the developer enters expressions or commands
			//It will then evaluate those expressions, and display the results to the user
		}

        [Test]
        public void CheckLasVegasWeather()
		//PRO-TIP: Naming conventions of tests should reflect a behavioral user action 
		{
			app.Tap("floatingButton");
            //PRO-TIP: Use Automation IDs (Xamarin.Forms), Content description (Android), Accessibility Identifiers (iOS) to 
			app.Screenshot("Let's start by Tapping on the 'Floating Action Button'");
			//PRO-TIP: Screenshots will enable to view the step definition in the Test Cloud portal 
			app.Tap("Las Vegas");
			app.Screenshot("Then we Tapped on 'Las Vegas'");
			app.SwipeRightToLeft();
			app.Screenshot("We Swiped Left to get weather summary");
			app.ScrollDown();
			app.Screenshot("Lastly, we scrolled down for more information");
        }


    }
}
