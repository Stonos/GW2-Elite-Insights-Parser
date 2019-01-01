using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckParser.Models.PickLeaderboardModels
{
    class PickLeaderboard
    {
        public List<string> parsedLogs;
        public Dictionary<string, PickLeaderboardPlayer> players;
    }
}
