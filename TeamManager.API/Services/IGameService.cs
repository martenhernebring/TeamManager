using TeamManager.API.Dtos;
using TeamManager.API.Models;

namespace TeamManager.API.Services
{
    public interface IGameService
    {
        public void Add(AddGame addGame);
        public List<Game> GetAllFuture(string team);
        public List<Game> GetAllPrevious(string team);
    }
}