using TakeCtrl.app.ViewModel;

namespace TakeCtrl.app.View;

public partial class Users : ContentPage
{
	public Users(UserViewModel userViewModel)
	{
		BindingContext = userViewModel;
		InitializeComponent();
	}
}