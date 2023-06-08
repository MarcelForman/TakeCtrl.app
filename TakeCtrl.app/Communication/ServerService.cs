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
    public class ServerService : IServerService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5100"
            : "http://localhost:5100";

        public ServerService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IEnumerable<ServerDto>> GetServers()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return Enumerable.Empty<ServerDto>();

            try
            {
                //  var response = await _httpClient.GetAsync($"{BaseAddress}/api/Server");
                var response = await _httpClient.GetAsync("http://localhost:5100/api/Server");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ServerDto>();
                    }
                    
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ServerDto>>();
                }
                else
                {
                    return Enumerable.Empty<ServerDto>();
                }
            }
            catch
            {
                return Enumerable.Empty<ServerDto>();
            }

        }
    }
}
