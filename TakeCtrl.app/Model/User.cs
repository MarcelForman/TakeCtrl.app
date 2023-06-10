using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeCtrl.app.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string userName { get; set; }
        public string Password { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
