using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Communication.Contracts;
using TakeCtrl.app.Data;
using TakeCtrl.app.Model;

namespace TakeCtrl.Test.Mock
{
    public class MockUserService : IUserService
    {
        private LoginUser _loginUser;

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return Enumerable.Empty<User>();
        }

        public async Task<bool> Login(LoginUser loginUser)
        {
            throw new NotImplementedException();
        }

        public Task<User> PostUser(User user)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.Login(LoginUser loginUser)
        {
            throw new NotImplementedException();
        }
    }
}
