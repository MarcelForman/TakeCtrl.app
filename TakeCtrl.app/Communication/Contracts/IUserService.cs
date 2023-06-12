using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Data;
using TakeCtrl.app.Model;

namespace TakeCtrl.app.Communication.Contracts
{
    public interface IUserService
    {
        Task<User> Login(LoginUser loginUser);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> DeleteUser(int id);
        Task<User> PostUser(User user);
    }
}
