using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Data;

namespace TakeCtrl.app.Communication.Contracts
{
    public interface IServerService
    {
        Task<IEnumerable<ServerDto>> GetServers();
        Task<IEnumerable<Firewall>> GetFirewalls(string uuid);
    }
}
