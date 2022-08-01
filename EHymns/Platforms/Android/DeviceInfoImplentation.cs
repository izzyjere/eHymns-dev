using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using EHymns.Platforms.Android;
using EHymns.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Application = Android.App.Application;

[assembly: Dependency(typeof(DeviceInfoImplentation))]
namespace EHymns.Platforms.Android
{
    public class DeviceInfoImplentation : EHymns.Interfaces.IDeviceInfo
    {
        public bool IsWhatsAppInstalled()
        {
            try
            {
                var pm = Application.Context.PackageManager;
                pm.GetPackageInfo("com.whatsapp", PackageInfoFlags.MatchAll);
                return true;
            }
            catch (PackageManager.NameNotFoundException)
            {
                return false;
            }
        }
    }
}
