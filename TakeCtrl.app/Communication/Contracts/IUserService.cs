using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Data;

namespace TakeCtrl.app.Communication.Contracts
{
    public interface IUserService
    {
        Task<bool> Login(LoginUser loginUser);
    }
}
