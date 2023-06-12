using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Communication;
using TakeCtrl.app.Model;

namespace TakeCtrl.app.ViewModel
{
    [ObservableObject]
    public partial class UserDetailsViewModel : IQueryAttributable
    {
        private UserService userService;
        [ObservableProperty]
        public User reqUser;

        public UserDetailsViewModel()
        {
            userService = new UserService();
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var _user = (User)query.Values.First();
            ReqUser = _user;
        }

        [RelayCommand]
        public async Task DeleteUser()
        {
            var result = await this.userService.DeleteUser(ReqUser.Id);

                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                string toastMessage = result ? "User deleted" : "Failure removing user, please try again later.";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(toastMessage, duration, fontSize);

                await toast.Show(cancellationTokenSource.Token);

            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("users");

        }
    }
}
