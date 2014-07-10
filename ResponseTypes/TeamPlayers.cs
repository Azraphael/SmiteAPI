using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{
    public class TeamPlayers
    {
        public int AccountLevel { get; set; }
        public string JoinedDatetime { get; set; }
        public string LastLoginDatetime { get; set; }
        public string Name { get; set; }
        public string ret_msg { get; set; }
    }
}
