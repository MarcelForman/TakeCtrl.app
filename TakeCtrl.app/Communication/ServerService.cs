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
                var response = await _httpClient.GetAsync($"{BaseAddress}/api/Server");

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

        public async Task<bool> ChangeStatus(ChangeStatus changeStatus)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseAddress}/api/Server/changestatus", changeStatus);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Firewall>> GetFirewalls(string uuid)
        {

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return Enumerable.Empty<Firewall>();

            try
            {
                var response = await _httpClient.GetAsync($"{BaseAddress}/api/Server/firewall/{uuid}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Firewall>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<Firewall>>();
                }
                else
                {
                    return Enumerable.Empty<Firewall>();
                }
            }
            catch
            {
                return Enumerable.Empty<Firewall>();
            }
        }
    }
}
