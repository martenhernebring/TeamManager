using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public interface IGameRepository
    {
        public List<Game> findAll(string team);
        public void save(Game game);
    }
}