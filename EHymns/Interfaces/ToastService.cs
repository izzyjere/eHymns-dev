﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

using Font = Microsoft.Maui.Font;

namespace EHymns.Interfaces;

public static class ToastService
{
  public static async void Show(string message, bool error = false)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = error? Colors.Green:Colors.Red,
            TextColor = Colors.White,
            ActionButtonTextColor = Colors.Yellow,
            CornerRadius = new CornerRadius(10),
            Font = Font.SystemFontOfSize(14),
            ActionButtonFont = Font.SystemFontOfSize(14) ,
            
        };            
       
       
        TimeSpan duration = TimeSpan.FromSeconds(5);

        var snackbar = Snackbar.Make(message,duration:duration, visualOptions: snackbarOptions, action: () =>
        {
            return;
        });

        await snackbar.Show(cancellationTokenSource.Token);
    }
}
