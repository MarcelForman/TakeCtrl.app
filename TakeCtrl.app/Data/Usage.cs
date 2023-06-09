using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeCtrl.app.Data
{
    public class Usage
    {
        public int CpuAvg { get; set; }
        public int DiskReadAvg { get; set; }
        public int DiskWriteAvg { get; set; }
        public int NetworkInAvg { get; set; }
        public int NetworkOutAvg { get; set; }
    }
}
