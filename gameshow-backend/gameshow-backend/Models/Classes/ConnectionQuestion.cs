using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_backend.Models
{
    public class ConnectionQuestion
    {
        public IEnumerable<ConnectionItem> Steps { get; set; }
        public string Answer { get; set; }
        public ConnectionType QuestionType { get; set; }
    }
}
