using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

using Font = Microsoft.Maui.Font;

namespace EHymns.Interfaces;

public static class ToastService
{
  public static async void Show(string message)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.Green,
            TextColor = Colors.White,
            ActionButtonTextColor = Colors.Yellow,
            CornerRadius = new CornerRadius(10),
            Font = Font.SystemFontOfSize(14),
            ActionButtonFont = Font.SystemFontOfSize(14)
            
        };            
       
       
        TimeSpan duration = TimeSpan.FromSeconds(5);

        var snackbar = Snackbar.Make(message,duration:duration, visualOptions:snackbarOptions);

        await snackbar.Show(cancellationTokenSource.Token);
    }
}
