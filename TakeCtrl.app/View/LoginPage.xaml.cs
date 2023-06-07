using TakeCtrl.app.Communication;
using TakeCtrl.app.Communication.Contracts;
using TakeCtrl.app.ViewModel;

namespace TakeCtrl.app.View;

public partial class LoginPage : ContentPage
{
	private LoginViewModel viewModel = new LoginViewModel(new UserService());
	public LoginPage(LoginViewModel loginViewModel)
	{

		InitializeComponent();
        BindingContext = loginViewModel;
		
    }
}