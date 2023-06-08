using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeCtrl.app.Data
{
    public class ServerDto
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public int CPUAmount { get; set; }
        public int DiskSize { get; set; }
        public int MemorySize { get; set; }
        public string Status { get; set; }
        public string IPAddress { get; set; }

    }
}
