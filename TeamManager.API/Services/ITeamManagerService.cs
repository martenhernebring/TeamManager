using TeamManager.API.Models;

namespace TeamManager.API.Services
{
    public interface ITeamManagerService
    {
        public void add(Game game);
        public void add(Game game, DateTime date);
        public List<Game> getAllFuture(string team);
        public List<Game> getAllPrevious(string team);
    }
}