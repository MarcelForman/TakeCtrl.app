using TakeCtrl.app.ViewModel;

namespace TakeCtrl.app.View;

public partial class Feedback : ContentPage
{
	public Feedback(FeedbackViewModel feedbackViewModel)
	{
		InitializeComponent();
		BindingContext = feedbackViewModel;
	}
}