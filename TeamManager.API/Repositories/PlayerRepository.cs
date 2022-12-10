using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<Player> players = new List<Player>();

        public List<Player> findAll(string team)
        {
            return players
                .Where(player => player.getTeam().Equals(team))
                .ToList();
        }
        
        public void save(Player player)
        {
            players.Add(player);
        }

        public void delete(Player player)
        {
            players.Remove(player);
        }
    }
}