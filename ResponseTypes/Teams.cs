using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{
    public class Teams
    {
        public string Founder { get; set; }
        public string Name { get; set; }
        public int Players { get; set; }
        public string Tag { get; set; }
        public int TeamId { get; set; }
        public string ret_msg { get; set; }
    }
}
