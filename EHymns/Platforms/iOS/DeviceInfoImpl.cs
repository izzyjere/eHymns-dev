using Foundation;

using UIKit;




namespace EHymns.Interfaces;

public class DeviceInfoImpl : IMyDeviceInfo
{
    public bool IsWhatsAppInstalled()
    {
        return UIApplication.SharedApplication.CanOpenUrl(new NSUrl(new NSString("whatsapp://")));

    }
}
