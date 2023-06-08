using TakeCtrl.app.ViewModel;

namespace TakeCtrl.app.View;

public partial class ServerDetails : ContentPage
{
	public ServerDetails(ServerDetailsViewModel serverDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = serverDetailsViewModel;
	}
}