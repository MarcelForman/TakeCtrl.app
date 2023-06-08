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

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5100/api/User/login", loginUser);
            //var result = await _httpClient.GetAsync("http://localhost:5100/api/Server");
            //var servers = result.Content;

            //var content = response.Content.ReadAsStringAsync().ToString();
            //return content.ReadFromJsonAsync<bool>().Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
