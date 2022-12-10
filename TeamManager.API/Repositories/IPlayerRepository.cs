using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public interface IPlayerRepository
    {
        public List<Player> findAll(string team);
        public void save(Player player);
        public void delete(Player player);
    }
}