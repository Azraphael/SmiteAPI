using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smite.API.ResponseTypes
{
    public class AbilityDescription
    {
        public string description { get; set; }
        public string secondaryDescription { get; set; }
        public List<Menuitem> menuitems { get; set; }
        public List<Rankitem> rankitems { get; set; }
        public string cooldown { get; set; }
        public string cost { get; set; }
    }
}
