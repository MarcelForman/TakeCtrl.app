﻿using CommunityToolkit.Mvvm.ComponentModel;
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
                    UserName = userName,
                    Password = password
                };
                var loggedIn = await userService.Login(loginuser);

                if (loggedIn)
                {

                    await Application.Current.MainPage.DisplayAlert
                    ("Login Succes",
                    "Your username and password do not match our records", "Ok");
                }
            }catch (Exception ex) 
            {

                await Application.Current.MainPage.DisplayAlert
                ("Authorization failure", 
                "Your username and password do not match our records", "Ok");                
                Console.WriteLine(ex);
            }
        }
    }
}