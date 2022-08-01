using EHymns.Data;

using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace EHymns;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
    {
        SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHFqVVhkW1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF9jT35UdkFnWXtYc3dTRg==;Mgo+DSMBPh8sVXJ0S0d+XE9AcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3xTcEVkWXtacHBTRWlcUA==;ORg4AjUWIQA/Gnt2VVhhQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkNjXn9adHRRQGRcU0U=;NjUyMDQzQDMyMzAyZTMxMmUzMGM5TXA0OUhsZ2ZKWGRiQW9xaXJnemFUV1Z3S1hMODBjbWZRRzJVZVVCcms9;NjUyMDQ0QDMyMzAyZTMxMmUzMEFXaVQ3dTlsZ3paNlhUZjJ3V1dDYnRBMUx2SURaazJaSXM3RTZzejVPUlU9;NRAiBiAaIQQuGjN/V0Z+XU9EaFtFVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdEVlWXhedHBVQmZZU0d0;NjUyMDQ2QDMyMzAyZTMxMmUzMFMwNENmZXVlYnppNldGQkdUcExSaC9Wakhla2V1eE5QYlZGZGdIOCtXSEE9;NjUyMDQ3QDMyMzAyZTMxMmUzMG5wYS8zRTVjdk9td1BCaEhaRmlocDQ0REdIZk53cGFyTTk4RFJFSnhURDQ9;Mgo+DSMBMAY9C3t2VVhhQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkNjXn9adHRRQGVUV0w=;NjUyMDQ5QDMyMzAyZTMxMmUzMEtUNUN4QldlVm5MNVJDL2s2aUNnMzZrQlkzTWlRR2xXbXVqa0Uram9IbkU9;NjUyMDUwQDMyMzAyZTMxMmUzMEtLcE96ZG1XUG5ZSkxlaTJ0emhXQllaaHMrbXNySVNrYmJiU3VDZ252YXc9");
        var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddSyncfusionBlazor();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		

		return builder.Build();
	}
}
