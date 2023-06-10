﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Communication.Contracts;
using TakeCtrl.app.Model;

namespace TakeCtrl.app.ViewModel
{
    [ObservableObject]
    public partial class UserViewModel
    {
        private IUserService userService;
        [ObservableProperty]
        ObservableCollection<User> users;
        [ObservableProperty]
        public int deleteUserId;

        public UserViewModel(IUserService userService)
        {
            this.userService = userService;
            users = new ObservableCollection<User>();
        }

        [RelayCommand]
        public async Task GetUsers()
        {
            var users = await this.userService.GetUsers();

            if(users != null)
            {
                Users.Clear();
                foreach(var user in users)
                {
                    Users.Add(user);
                }

                if (Users.Count == 0)
                {
                    Users.Add(new User
                    {
                        Name = "No users found."
                    });
                }
            }

        }

        [RelayCommand]
        public async Task SelectUser(User user)
        {
            if (user is not null)
            {

                await Shell.Current.GoToAsync("userdetails",
                    new Dictionary<string, object>
                    {
                        { "User", user }
                    }
                    );
            }
        }


    }
}