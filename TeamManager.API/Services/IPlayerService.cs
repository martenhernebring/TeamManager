using TeamManager.API.Models;

namespace TeamManager.API.Services
{
    public interface IPlayerService
    {
        void add(Player player);
        public List<Player> getAllFrom(string team);
        void remove(Player player);
    }
}