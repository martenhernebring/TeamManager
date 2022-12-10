using TeamManager.API.Models;

namespace TeamManager.API.Services
{
    public interface IGameService
    {
        public void add(Game game);
        public List<Game> getAllFuture(string team);
        public List<Game> getAllPrevious(string team);
    }
}