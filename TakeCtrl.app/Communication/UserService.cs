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
using TakeCtrl.app.Model;

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

        public async Task<IEnumerable<User>> GetUsers()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return Enumerable.Empty<User>();

            var response = await _httpClient.GetAsync($"{BaseAddress}/api/users");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
            }

            return Enumerable.Empty<User>();
        }

        public async Task<bool> DeleteUser(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;

            var response = await _httpClient.DeleteAsync($"{BaseAddress}/api/User/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<User> PostUser(User user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return default(User);

            var response = await _httpClient.PostAsJsonAsync($"{BaseAddress}/api/User/adduser", user);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<User>();
            }

            return default(User);
        }
    }
}
