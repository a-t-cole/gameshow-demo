using gameshow_core.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_core.Models.Rounds
{
    public class MissingVowelRound
    {
        public IEnumerable<MissingVowelCategory> Categories { get; set; }
    }
}
