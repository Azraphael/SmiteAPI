﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{
    public class QueueStats
    {
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public string God { get; set; }
        public int GodId { get; set; }
        public int Gold { get; set; }
        public int Kills { get; set; }
        public string LastPlayed { get; set; }
        public int Losses { get; set; }
        public int Matches { get; set; }
        public int Minutes { get; set; }
        public string Queue { get; set; }
        public int Wins { get; set; }
        public string ret_msg { get; set; }
    }
}
