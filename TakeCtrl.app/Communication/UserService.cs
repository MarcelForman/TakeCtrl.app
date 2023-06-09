using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Communication.Contracts;
using TakeCtrl.app.Data;

namespace TakeCtrl.app.Communication
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private const string ServerUrl =
            "http://localhost:5100/api";
        private bool _isLogginIn = false;
        private readonly string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android
        ? "http://10.0.2.2:5100"
        : "http://localhost:5100";

        /*        public UserService(HttpClient httpClient)
                {
                    this._httpClient = httpClient;
                }*/

        public UserService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<bool> Login(LoginUser loginUser)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;

            var response = await _httpClient.PostAsJsonAsync($"{BaseAddress}/api/User/login", loginUser);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
