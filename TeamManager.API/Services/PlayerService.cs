using TeamManager.API.Models;
using TeamManager.API.Repositories;

namespace TeamManager.API.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository) {
            _repository = repository;
        }

        public void add(Player player)
        {
            _repository.save(player);
        }

        public List<Player> getAllFrom(string team)
        {
            return _repository.findAll(team);
        }

        public void remove(Player player)
        {
            _repository.delete(player);
        }
    }
}