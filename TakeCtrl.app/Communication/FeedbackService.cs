using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Communication.Contracts;
using TakeCtrl.app.Model;

namespace TakeCtrl.app.Communication
{
    public class FeedbackService : IFeedbackService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5100"
            : "http://localhost:5100";
        public FeedbackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public FeedbackService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5100"
            : "http://localhost:5100")
            };
        }
        public async Task<bool> PostFeedback(Feedback feedback)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return false;

            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/User/Feedback", feedback);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
