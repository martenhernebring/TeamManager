using TeamManager.API.Dtos;
using TeamManager.API.Models;

namespace TeamManager.API.Repositories
{
    public interface IGameRepository
    {
        public HashSet<Game> FindAll(string team);
        public void Save(Game game);
    }
}