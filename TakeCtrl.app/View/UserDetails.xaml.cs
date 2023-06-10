using TakeCtrl.app.ViewModel;

namespace TakeCtrl.app.View;

public partial class UserDetails : ContentPage
{
	public UserDetails(UserDetailsViewModel userDetailsViewModel)
	{
		BindingContext = userDetailsViewModel;
		InitializeComponent();
	}
}