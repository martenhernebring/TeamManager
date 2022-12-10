using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public void delete(Player player)
        {
            throw new NotImplementedException();
        }

        public void save(Player player)
        {
            throw new NotImplementedException();
        }

        List<Player> IPlayerRepository.findAll(string team)
        {
            throw new NotImplementedException();
        }
    }
}