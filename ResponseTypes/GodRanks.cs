using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{
    public class GodRanks
    {
        public int Rank { get; set; }
        public int Worshippers { get; set; }
        public string god { get; set; }
        public string ret_msg { get; set; }
    }
}
