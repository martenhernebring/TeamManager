using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManager.API.Models
{
    public class SoccerGame : Game
    {
        private string name;
        private DateTime time;

        public SoccerGame(string name, DateTime time)
        {
            this.name = name;
            this.time = time;
        }

        public DateTime getTime()
        {
            return time;
        }
    }
}