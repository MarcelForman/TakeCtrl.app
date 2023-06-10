using TakeCtrl.app.ViewModel;

namespace TakeCtrl.app.View;

public partial class CreateUser : ContentPage
{
	public CreateUser(CreateUserViewModel createUserViewModel)
	{
		BindingContext = createUserViewModel;
		InitializeComponent();
	}
}