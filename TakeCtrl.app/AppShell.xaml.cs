using TakeCtrl.app.View;

namespace TakeCtrl.app;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("loginpage", typeof(LoginPage));
    }
}
