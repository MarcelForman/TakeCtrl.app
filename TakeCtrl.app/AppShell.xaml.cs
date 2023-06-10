using TakeCtrl.app.View;

namespace TakeCtrl.app;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("loginpage", typeof(LoginPage));
		Routing.RegisterRoute("serveroverview", typeof(ServerOverview));
		Routing.RegisterRoute("feedback", typeof(Feedback));
		Routing.RegisterRoute("serverdetails", typeof(ServerDetails));
		Routing.RegisterRoute("userdetails", typeof(UserDetails));
		Routing.RegisterRoute("createuser", typeof(CreateUser));
    }
}
