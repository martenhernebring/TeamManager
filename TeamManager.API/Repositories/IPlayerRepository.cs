using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public interface IPlayerRepository
    {
        void delete(Player player);
        public List<Player> findAll(string team);
        void save(Player player);
    }
}