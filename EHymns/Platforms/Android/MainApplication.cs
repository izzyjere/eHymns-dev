using Android.App;
using Android.OS;
using Android.Runtime;

using Plugin.CurrentActivity;

namespace EHymns.Platforms.Android;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }     
    public void OnActivityResumed(Activity activity)
    {
        CrossCurrentActivity.Current.Activity = activity;
    }
    protected override MauiApp CreateMauiApp()
    {
        return MauiProgram.CreateMauiApp();
    }
    public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
    {
        CrossCurrentActivity.Current.Activity = activity;
    }

}
