using Android.Content.PM;

using Application = Android.App.Application;

namespace EHymns.Interfaces;

public class DeviceInfoImpl : IMyDeviceInfo
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
