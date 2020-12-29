using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_core.Models.Classes
{
    public class ConnectionQuestion : BaseQuestion
    {
        public Dictionary<int, ConnectionItem> Steps { get; set; }
        public string Answer { get; set; }
        public ConnectionType QuestionType { get; set; }
    }
}
