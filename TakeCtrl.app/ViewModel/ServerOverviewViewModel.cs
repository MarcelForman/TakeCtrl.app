﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TakeCtrl.app.Communication;
using TakeCtrl.app.Data;

namespace TakeCtrl.app.ViewModel
{
    [ObservableObject]
    public partial class ServerOverviewViewModel
    {
        private ServerService serverService;
        [ObservableProperty]
        ObservableCollection<ServerDto> servers;

        public ServerOverviewViewModel(ServerService serverService)
        {
            this.serverService = serverService;
            _ = new Command(async () => await LoadData());
            try 
            {
                Accelerometer.Start(SensorSpeed.UI);
                Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            } catch (FeatureNotSupportedException ex) 
            {
                Debug.WriteLine(ex.Message);
            }
        }
        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
            Shell.Current.GoToAsync("feedback");
        }

        public ServerOverviewViewModel()
        {
            this.serverService = new ServerService();
            servers = new ObservableCollection<ServerDto>();
        }

        [RelayCommand]
        public async Task SelectServer(ServerDto server)
        {
            if (server is not null)
            {

                await Shell.Current.GoToAsync("serverdetails",
                    new Dictionary<string, object>
                    {
                        { "Server", server }
                    }
                    );
            }
        }
        [RelayCommand]
        public async Task LoadData()
        {
            var result = await serverService.GetServers();

            if (result != null)
            {
                Servers.Clear();
                foreach (ServerDto server in result)
                {
                    Servers.Add(server);
                }
                if (Servers.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert
                        ("Failure retrieving", "No servers found, please try again later.", "Ok");
                }
            }
        }
    }
}
