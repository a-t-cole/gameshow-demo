using System;
using System.Collections.Generic;
using gameshow_core.Models.Classes; 
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_core.Models.Rounds
{
    public class ConnectionRound
    {
        public Dictionary<int, ConnectionQuestion> Qestions { get; set; }
    }
}
