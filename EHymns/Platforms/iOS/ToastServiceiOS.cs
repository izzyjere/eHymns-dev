using EHymns.Interfaces;
using EHymns.Platforms.iOS;
using EHymns.Shared;

using Foundation;

using UIKit;



[assembly: Dependency(typeof(ToastServiceiOS))]
namespace EHymns.Platforms.iOS
{

    public class ToastServiceiOS : IToastService
    {
        public void Show(string message)
        {

            var alertController = UIAlertController.Create(null,
                message, UIAlertControllerStyle.Alert);

            NSTimer.CreateScheduledTimer(5, alertTimer =>
            {
                DismissToast(alertController, alertTimer);
            });

            UIApplication.SharedApplication.KeyWindow
                .RootViewController.PresentViewController(alertController, true, null);
        }
        private void DismissToast(UIAlertController alertController, NSTimer alertTimer)
        {
            alertController?.DismissViewController(true, null);
            alertTimer?.Dispose();
        }
    }
}