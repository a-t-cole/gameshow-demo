using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_core.Models
{
    public class WallRound
    {
        public IEnumerable<WallGroup> Wall1 { get; set;}
        public IEnumerable<WallGroup> Wall2 { get; set; }
    }
}
