using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{
    public class Player
    {
        public string Created_Datetime { get; set; }
        public int Id { get; set; }
        public string Last_Login_Datetime { get; set; }
        public GameInfo LeagueConquest { get; set; }
        public GameInfo LeagueJoust { get; set; }
        public int Leaves { get; set; }
        public int Level { get; set; }
        public int Losses { get; set; }
        public int MasteryLevel { get; set; }
        public string Name { get; set; }
        public double Rank_Stat { get; set; }
        public double Rank_Stat_Joust { get; set; }
        public int TeamId { get; set; }
        public string Team_Name { get; set; }
        public int Tier_Conquest { get; set; }
        public int Tier_Joust { get; set; }
        public int Wins { get; set; }
        public string ret_msg { get; set; }
    }
}
