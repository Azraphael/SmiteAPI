using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{


    public class LeagueSeasons
    {
        public bool complete { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string ret_msg { get; set; }
    }
}
