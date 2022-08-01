using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using EHymns.Interfaces;
using EHymns.Platforms.Android;
using EHymns.Shared;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application = Android.App.Application;

[assembly: Dependency(typeof(ToastServiceAndroid))]
namespace EHymns.Platforms.Android
{
    public class ToastServiceAndroid : IToastService
    {
        private static Toast _toastInstance;
        public void Show(string message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _toastInstance?.Cancel();
                _toastInstance = Toast.MakeText(Application.Context,
                    message, ToastLength.Long);
                _toastInstance?.Show();
            });
        }
    }
}