using TakeCtrl.app.ViewModel;

namespace TakeCtrl.app.View;

public partial class ServerOverview : ContentPage
{
	public ServerOverview(ServerOverviewViewModel serverOverviewViewModel)
	{
		InitializeComponent();
		BindingContext = serverOverviewViewModel;
	}
}