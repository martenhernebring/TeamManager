using TeamManager.API.Dtos;
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

        public void Add(PlayerDto addPlayer)
        {
            Player player = new Player();
            player.Team = addPlayer.Team;
            player.Jersey = addPlayer.Jersey;
            _repository.Save(player);
        }

        public HashSet<Player> GetAllFrom(string team)
        {
            return _repository.FindAll(team);
        }

        public void Remove(PlayerDto playerDto)
        {
            if(playerDto.Team !=  null)
                _repository.Delete(playerDto.Team!, playerDto.Jersey);
                
        }
    }
}