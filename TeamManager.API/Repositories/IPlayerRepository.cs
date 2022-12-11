using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public interface IPlayerRepository
    {
        public HashSet<Player> FindAll(string team);
        public void Save(Player player);
        public void Delete(string team, int jersey);
    }
}