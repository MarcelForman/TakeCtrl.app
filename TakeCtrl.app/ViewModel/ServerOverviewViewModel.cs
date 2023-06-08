using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
/*                Shell.Current.GoToAsync($"{nameof(View.ServerDetails)}?load=",
                new Dictionary<string, object>
                {
                    [nameof(ServerDto)] = server,
                });*/

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

            /*            MainThread.BeginInvokeOnMainThread(() =>
                        {
                            foreach (ServerDto server in result.Result)
                            {
                                Servers.Add(server);
                            }
                        });*/

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
