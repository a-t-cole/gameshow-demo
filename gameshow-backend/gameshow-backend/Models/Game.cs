using gameshow_backend.Models.Rounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_backend.Models
{
    public class Game
    {
        public ConnectionRound Round1 { get; set; }
        public ConnectionRound Round2 { get; set; }
        public WallRound Round3 { get; set; }
        public MissingVowelRound Round4 { get; set;}
    }
}
