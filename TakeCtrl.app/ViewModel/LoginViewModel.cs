using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Communication;
using TakeCtrl.app.Data;
using Exception = System.Exception;

namespace TakeCtrl.app.ViewModel
{
    [ObservableObject]
    public partial class LoginViewModel
    {
        private UserService userService;
        [ObservableProperty]
        private string userName;
        [ObservableProperty]
        private string password;

        public LoginViewModel(UserService userService)
        {
            this.userService = userService;
        }

        public LoginViewModel()
        {
            this.userService = new UserService();
        }

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                LoginUser loginuser = new LoginUser
                {
                    userName = userName,
                    password = password
                };
                var loggedIn = await userService.Login(loginuser);

                if (loggedIn)
                {

                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync("serveroverview");

                } else
                {
                    await Application.Current.MainPage.DisplayAlert
                        ("Login failure", "Please check your username and password or try again later.", "Ok");
                }
            }catch (Exception ex) 
            {

                await Application.Current.MainPage.DisplayAlert
                ("Login failure", ex.Message, "Ok");                
                Console.WriteLine(ex);
            }
        }
    }
}
