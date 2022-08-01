using EHymns.Data;

namespace EHymns;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
	protected override async void OnStart()
	{
        await Database.Initialize();
        base.OnStart();
	}
}
