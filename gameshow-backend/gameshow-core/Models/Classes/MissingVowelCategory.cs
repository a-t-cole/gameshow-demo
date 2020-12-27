using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_core.Models.Classes
{
    public class MissingVowelCategory
    {
        public IEnumerable<MissingVowelItem> Questions { get; set; }
        public string CategoryName { get; set; }
    }
}
