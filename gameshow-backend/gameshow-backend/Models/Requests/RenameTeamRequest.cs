using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_backend.Models.Requests
{
    public class RenameTeamRequest
    {
        public TeamType Team { get; set; }
        public string TeamName { get; set; }
    }
}
