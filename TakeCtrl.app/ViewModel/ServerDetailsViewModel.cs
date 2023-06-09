using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Communication;
using TakeCtrl.app.Data;

namespace TakeCtrl.app.ViewModel
{
    [ObservableObject]
    public partial class ServerDetailsViewModel : IQueryAttributable
    {
        private ServerService serverService;
        [ObservableProperty]
        public String status;
        [ObservableProperty]
        public ServerDto reqServer;
        [ObservableProperty]
        public ObservableCollection<Firewall> firewalls;
        [ObservableProperty]
        public string minDate = DateTime.Now.AddDays(-30).ToString();
        [ObservableProperty]
        public string maxDate = DateTime.Now.ToString();
        [ObservableProperty]
        public string startDate = DateTime.Today.ToString();
        [ObservableProperty]
        public string endDate = DateTime.Today.ToString();
        [ObservableProperty]
        public ObservableCollection<Usage> usages;

        public ServerDetailsViewModel()
        {
            serverService = new ServerService();
            reqServer = default(ServerDto);
            firewalls = new ObservableCollection<Firewall>();
            usages = new ObservableCollection<Usage>();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var _server = (ServerDto)query.Values.First();
            Status = _server.Status;
            ReqServer = _server;
        }

        [RelayCommand]
        public async Task StopVPS()
        {
            var changeStatus = new ChangeStatus
            {
                UUID = reqServer.UUID,
                Status = "stopped"
            };
            var result = await serverService.ChangeStatus(changeStatus);

            Status = "stopped";
        }

        [RelayCommand]
        public async Task StartVPS()
        {
            var changeStatus = new ChangeStatus
            {
                UUID = reqServer.UUID,
                Status = "running"
            };
            var result = await serverService.ChangeStatus(changeStatus);

            Status = "running";
        }

        [RelayCommand]
        public async Task GetFirewall()        {

            try
            {
                var result = await serverService.GetFirewalls(ReqServer.UUID);

                if (result != null)
                {
                    Firewalls.Clear();
                    foreach (Firewall server in result)
                    {
                        Firewalls.Add(server);
                    }
                    if (Firewalls.Count == 0)
                    {
                        await Application.Current.MainPage.DisplayAlert
                            ("No information found", "No firewall rules found, please try again later.", "Ok");
                    }
                }

            } catch (Exception ex) 
            {
                Debug.WriteLine(ex);
            }
        }

        [RelayCommand]
        public async Task GetUsage()
        {
            var parameters = new UsageReq
            {
                Uuid = reqServer.UUID,
                StartDate = this.StartDate.ToString(),
                EndDate = this.EndDate.ToString(),
            };
            
            try
            {
                var result = await serverService.GetUsage(parameters);

                if (result != null)
                {
                    Usages.Clear();
                    Usages.Add(result);
                    if (Usages.Count == 0)
                    {
                        await Application.Current.MainPage.DisplayAlert
                            ("No information found", "No firewall rules found, please try again later.", "Ok");
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
