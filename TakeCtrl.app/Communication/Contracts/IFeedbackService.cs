using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeCtrl.app.Model;

namespace TakeCtrl.app.Communication.Contracts
{
    public interface IFeedbackService
    {
        Task<bool> PostFeedback(Feedback feedback);
    }
}
