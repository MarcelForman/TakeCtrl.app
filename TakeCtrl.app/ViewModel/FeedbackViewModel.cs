using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TakeCtrl.app.Communication;
using TakeCtrl.app.Communication.Contracts;
using TakeCtrl.app.Model;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace TakeCtrl.app.ViewModel
{
    [ObservableObject]
    public partial class FeedbackViewModel
    {
        private readonly IFeedbackService _feedbackService;
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string message;
        public FeedbackViewModel(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public FeedbackViewModel()
        {
            _feedbackService = new FeedbackService();
        }

        [RelayCommand]
        public async void PostFeedback()
        {
            var result = false;

            try
            {
                var feedback = new Feedback
                {
                    Name = Name,
                    Emailadres = Email,
                    Message = Message
                };

                result = await _feedbackService.PostFeedback(feedback);

            }
            catch (Exception)
            {

                throw;
            }

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


            string toastMessage = result ? "Feedback send, thank you!" : "Failure sending, try again later.";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(toastMessage, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
            Empty();
        }

        public void Empty()
        {
            Name = "";
            Email = "";
            Message = "";
        }
    }
}
