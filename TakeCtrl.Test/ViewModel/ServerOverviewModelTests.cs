using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.ViewModel;
using TakeCtrl.Test.Mock;

namespace TakeCtrl.Test.ViewModel
{
    public class ServerOverviewModelTests
    {
        [Fact]
        public async Task WhenNoServersCountIsZero()
        {
            var mockServiceServer = new MockServerService();
            var viewModel = new ServerOverviewViewModel(mockServiceServer);
            await viewModel.LoadData();

            var name = viewModel.Servers.First().Name;


            Assert.True(name.Equals("No servers found"));
 
        }
    }
}
