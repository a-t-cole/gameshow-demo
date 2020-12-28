using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameshow_core.Models.Classes;

namespace gameshow_core.Models.Rounds
{
    public class WallRound
    {
        public IEnumerable<WallGroup> Wall1 { get; set;}
        public IEnumerable<WallGroup> Wall2 { get; set; }
    }
}
