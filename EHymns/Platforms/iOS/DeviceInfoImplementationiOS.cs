using EHymns.Platforms.iOS;
using EHymns.Shared;

using Foundation;

using System;
using System.Collections.Generic;
using System.Text;

using UIKit;



[assembly: Dependency(typeof(DeviceInfoImplementationiOS))]
namespace EHymns.Platforms.iOS
{
    public class DeviceInfoImplementationiOS : EHymns.Interfaces.IDeviceInfo
    {
        public bool IsWhatsAppInstalled()
        {
            return UIApplication.SharedApplication.CanOpenUrl(new NSUrl(new NSString("whatsapp://")));

        }
    }
}
