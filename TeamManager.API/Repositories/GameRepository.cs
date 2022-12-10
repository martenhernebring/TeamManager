using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public class GameRepository : IGameRepository
    {
        private List<Game> games = new List<Game>();
        public List<Game> findAll(string team)
        {
            return games;
        }

        public void save(Game game)
        {
            games.Add(game);
        }
    }
}