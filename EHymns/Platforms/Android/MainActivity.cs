using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Speech;

using EHymns.Interfaces;

using Plugin.CurrentActivity;

namespace EHymns.Platforms.Android;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity ,IMessageSender
{
    protected override void OnStart()
    {
        
        CrossCurrentActivity.Current.Activity = this;
        base.OnStart();
    }
    protected override void OnResume()
    {
        CrossCurrentActivity.Current.Activity = this;
        base.OnResume();    
    }
    private readonly int VOICE = 10;
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {

        if (requestCode == VOICE)
        {
            if (resultCode == Result.Ok)
            {
                var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
                if (matches.Count != 0)
                {
                    string textInput = matches[0];
                    MessagingCenter.Send<IMessageSender, string>(this, "STT", textInput);
                }
                else
                {
                    MessagingCenter.Send<IMessageSender, string>(this, "STT", "No input");
                }

            }
        }
        base.OnActivityResult(requestCode, resultCode, data);
    }
}
