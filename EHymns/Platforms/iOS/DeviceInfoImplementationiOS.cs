using EHymns.Platforms.iOS;
using EHymns.Shared;

using Foundation;

using System;
using System.Collections.Generic;
using System.Text;

using UIKit;




namespace EHymns.Interfaces
{
    public class DeviceInfoImplementation : EHymns.Interfaces.IMyDeviceInfo
    {
        public bool IsWhatsAppInstalled()
        {
            return UIApplication.SharedApplication.CanOpenUrl(new NSUrl(new NSString("whatsapp://")));

        }
    }
}
