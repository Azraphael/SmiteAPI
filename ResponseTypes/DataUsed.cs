using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{
    public class DataUsed
    {
        public int Active_Sessions { get; set; }
        public int Concurrent_Sessions { get; set; }
        public int Request_Limit_Daily { get; set; }
        public int Session_Cap { get; set; }
        public int Session_Time_Limit { get; set; }
        public int Total_Requests_Today { get; set; }
        public int Total_Sessions_Today { get; set; }
        public string ret_msg { get; set; }
    }
}
