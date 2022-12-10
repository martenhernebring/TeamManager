using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public interface IGameRepository
    {
        List<Game> findAll(string team);
        void save(Game game);
    }
}