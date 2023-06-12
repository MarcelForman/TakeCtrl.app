using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.ViewModel;

namespace TakeCtrl.Test.ViewModel
{
    public class ServerDetailsViewModelTests
    {
        [Fact]
        public void ChangingStatusShouldRaisePropertyChanged()
        {
            var invoked = false;
            var viewModel = new ServerDetailsViewModel();

            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals(nameof(ServerDetailsViewModel.Status)))
                {
                    invoked = true;
                }
            };

            viewModel.Status = "stopped";

            Assert.True(invoked);
        }
    }
}
