using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private static List<Player> players = new List<Player>{};

        public List<Player> FindAll(string team)
        {
            return players
                .Where(player => player.Team != null && player.Team.Equals(team))
                .ToList();
        }
        
        public void Save(Player player)
        {
            if(players.Count <= 0)
                player.Id = 0;
            else
                player.Id = players.Max(c => c.Id) + 1;
                
            players.Add(player);
        }

        public void Delete(string team, int jersey)
        {
            List<Player> toBeDeleted = players.FindAll(p => p.Team == team && p.Jersey == jersey);
            toBeDeleted.ForEach(p => players.Remove(p));
        }
    }
}