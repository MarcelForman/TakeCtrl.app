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
            "https://localhost:7196/";
        private bool _isLogginIn = false;

        /*        public UserService(HttpClient httpClient)
                {
                    this._httpClient = httpClient;
                }*/

        public UserService()
        {
            _httpClient = new HttpClient(new HttpClientHandler());
        }
        public async Task<bool> Login(LoginUser loginUser)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;

            //var response = await _httpClient.GetAsync($"{ServerUrl}/Server)").ConfigureAwait(false);
            //response.EnsureSuccessStatusCode();

            //return await response.Content.ReadFromJsonAsync<IEnumerable<Server>>();

            var response = await _httpClient.PostAsJsonAsync($"{ServerUrl}/user/login", loginUser).ConfigureAwait(false);

            var content = response.Content;
            return content.ReadFromJsonAsync<bool>().Result;
        }
    }
}
