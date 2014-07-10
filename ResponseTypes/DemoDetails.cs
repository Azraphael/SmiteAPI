using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{
    public class DemoDetails
    {
        public string Ban1 { get; set; }
        public string Ban2 { get; set; }
        public string Entry_Datetime { get; set; }
        public int Match { get; set; }
        public int Match_Time { get; set; }
        public int Offline_Spectators { get; set; }
        public int Realtime_Spectators { get; set; }
        public string Recording_Ended { get; set; }
        public string Recording_Started { get; set; }
        public int Team1_AvgLevel { get; set; }
        public int Team1_Gold { get; set; }
        public int Team1_Kills { get; set; }
        public int Team1_Score { get; set; }
        public int Team2_AvgLevel { get; set; }
        public int Team2_Gold { get; set; }
        public int Team2_Kills { get; set; }
        public int Team2_Score { get; set; }
        public int Winning_Team { get; set; }
        public string ret_msg { get; set; }
    }
}
