using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeCtrl.app.Data
{
    public class UsageReq
    {
        public string Uuid { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
