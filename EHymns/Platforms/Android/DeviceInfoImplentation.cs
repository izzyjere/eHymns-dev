﻿using Android.Content.PM;

using EHymns.Platforms.Android;

using Application = Android.App.Application;

namespace EHymns.Interfaces
{
    public class DeviceInfoImplentation : EHymns.Interfaces.IMyDeviceInfo
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
