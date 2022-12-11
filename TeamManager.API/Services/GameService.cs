using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManager.API.Dtos;
using TeamManager.API.Models;
using TeamManager.API.Repositories;

namespace TeamManager.API.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository) {
            _repository = repository;
        }

        public void Add(AddGame addGame)
        {
            Game game = new SoccerGame();
            game.Team = addGame.Team;
            game.Time = addGame.Time;
            _repository.Save(game);
        }

        public List<Game> GetAllFuture(string team)
        {
            return _repository
                .FindAll(team)
                .Where(game => DateTime.Compare(game.Time, DateTime.UtcNow) > 0)
                .ToList();
        }

        public List<Game> GetAllPrevious(string team)
        {
            return _repository
                .FindAll(team)
                .Where(game => DateTime.Compare(game.Time, DateTime.UtcNow) <= 0)
                .ToList();
        }
    }
}