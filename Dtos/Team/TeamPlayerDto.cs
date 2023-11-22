using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManagerServer.Dtos.Team
{
    public class TeamPlayerDto
    {
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
    }
}