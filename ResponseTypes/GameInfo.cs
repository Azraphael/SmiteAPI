using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smite.API.ResponseTypes
{
    public class GameInfo
    {
        public int Leaves { get; set; }
        public int Losses { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int PrevRank { get; set; }
        public int Rank { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Trend { get; set; }
        public int VictoryPoints { get; set; }
        public int Wins { get; set; }
        public string ret_msg { get; set; }
    }
}
