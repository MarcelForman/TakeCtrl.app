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
    public class UserViewModelTests
    {
        [Fact]
        public async Task IfNoUsersThenShowUserWithNoUserMessage()
        {
            
            var viewModel = new UserViewModel(new MockUserService());
            await viewModel.GetUsers();

            var name = viewModel.Users.First().Name;

            Debug.WriteLine(name);
            Assert.True(name.Equals("No users found."));

        }
    }
}
