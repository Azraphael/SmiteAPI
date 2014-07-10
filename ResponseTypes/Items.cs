using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smite.API.ResponseTypes
{
    public class Items
    {
        public int ChildItemId { get; set; }
        public string DeviceName { get; set; }
        public int IconId { get; set; }
        public ItemDescription ItemDescription { get; set; }
        public int ItemId { get; set; }
        public int ItemTier { get; set; }
        public int Price { get; set; }
        public int RootItemId { get; set; }
        public string ShortDesc { get; set; }
        public bool StartingItem { get; set; }
        public string Type { get; set; }
        public string ret_msg { get; set; }
    }
}
