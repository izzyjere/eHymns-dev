using Windows.Management.Deployment;

namespace EHymns.Interfaces;

public class DeviceInfoImpl : IMyDeviceInfo
{
    public bool IsWhatsAppInstalled()
    {
        string packageFamilyName = "5319275A.WhatsApp";
        PackageManager packageManager = new PackageManager();
        var package = packageManager.FindPackageForUser("", packageFamilyName);
        return (package != null);
    }
}
