using TakeCtrl.app.ViewModel;
using TakeCtrl.app.View;
using TakeCtrl.app.Communication;

namespace TakeCtrl.app;

public partial class App : Application
{
	public App(LoginPage page)
	{
		InitializeComponent();
		MainPage = page;
	}
}
