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
    public partial class CreateUserViewModel
    {
        private UserService userService;
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public string password;
        [ObservableProperty]
        public bool isAdmin;
        [ObservableProperty]
        public bool aChecked;
        [ObservableProperty]
        public bool bChecked;

        public CreateUserViewModel()
        {
            this.userService = new UserService();
        }

        [RelayCommand]
        public async Task AddUser()
        {
            IsAdmin = AChecked ? true : false;

            var user = new User
            {
                Name = Name,
                userName = UserName,
                Password = Password,
                IsAdmin = IsAdmin,
            };
            var response = await userService.PostUser(user);
            var message = "";

            if (response != null)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                string toastMessage = "User created";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(toastMessage, duration, fontSize);

                await toast.Show(cancellationTokenSource.Token);


            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                string toastMessage = "User not created, please try again later";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(toastMessage, duration, fontSize);

                await toast.Show(cancellationTokenSource.Token);
            }
        }
    }
}
