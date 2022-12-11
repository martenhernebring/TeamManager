using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public class GameRepository : IGameRepository
    {
        private static List<Game> games = new List<Game>{};

        public List<Game> FindAll(string team)
        {
            return games
                .Where(game => game.Team != null && game.Team.Equals(team))
                .ToList();
        }

        public void Save(Game game)
        {
            if(games.Count <= 0)
                game.Id = 0;
            else
                game.Id = games.Max(c => c.Id) + 1;

            games.Add(game);
        }
    }
}