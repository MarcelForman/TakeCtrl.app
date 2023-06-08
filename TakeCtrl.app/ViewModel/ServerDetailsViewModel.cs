using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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
        public String uuid;
        [ObservableProperty]
        public ServerDto reqServer;

        public ServerDetailsViewModel()
        {
            serverService = new ServerService();
            reqServer = default(ServerDto);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Application.Current.MainPage.DisplayAlert
            ("Login failure", "Please check your username and password", "Ok");
            var _server = (ServerDto)query.Values.First();
            Uuid = _server.UUID;
            ReqServer = _server;
        }

    }
}
