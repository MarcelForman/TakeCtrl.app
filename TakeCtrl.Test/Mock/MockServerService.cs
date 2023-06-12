using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Communication;
using TakeCtrl.app.Communication.Contracts;
using TakeCtrl.app.Data;

namespace TakeCtrl.Test.Mock
{
    public class MockServerService : IServerService
    {
        public Task<IEnumerable<Firewall>> GetFirewalls(string uuid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ServerDto>> GetServers()
        {
            return Enumerable.Empty<ServerDto>();
        }

        public Task<Usage> GetUsage(UsageReq usageDto)
        {
            throw new NotImplementedException();
        }
    }
}
