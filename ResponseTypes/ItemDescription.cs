using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smite.API.ResponseTypes
{
    public class ItemDescription
    {
        public string Description { get; set; }
        public List<Menuitem> Menuitems { get; set; }
        public string SecondaryDescription { get; set; }
    }
}
