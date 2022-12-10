using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManager.API.Models
{
    public class SoccerGame : Game
    {
        private string team;
        private DateTime time;

        public SoccerGame(string team, DateTime time)
        {
            this.team = team;
            this.time = time;
        }

        public DateTime getTime()
        {
            return time;
        }
    }
}