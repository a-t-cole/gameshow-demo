using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_core.Models
{
    public class WallGroup
    {
        public IEnumerable<ConnectionItem> Items { get; set; }
        public string Connection { get; set; }
    }
}
