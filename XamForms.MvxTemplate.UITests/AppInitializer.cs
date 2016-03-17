﻿using System;
using Xamarin.UITest;
using Xamarin.UITest.Utils;

namespace XamForms.MvxTemplate.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile("../../../XamForms.MvxTemplate.Droid/bin/Release/XamForms.MvxTemplate.Droid.apk")
                    .WaitTimes(new WaitTimes())
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .AppBundle("../../../XamForms.MvxTemplate.iOS/bin/iPhoneSimulator/Debug/XamForms.MvxTemplate.iOs.app")
                .WaitTimes(new WaitTimes())
                .StartApp();
        }
    }

    /// <summary>
    /// Custom implementation of IWaitTimes in order to avoid test failures due to slow emulators.
    /// </summary>
    internal class WaitTimes : IWaitTimes
    {
        public TimeSpan GestureWaitTimeout
        {
            get
            {
                return TimeSpan.FromMinutes(1);
            }
        }

        public TimeSpan WaitForTimeout
        {
            get
            {
                return TimeSpan.FromMinutes(1);
            }
        }
    }

}
