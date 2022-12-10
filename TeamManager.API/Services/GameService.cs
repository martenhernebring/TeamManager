using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void add(Game game)
        {
            _repository.save(game);
        }

        public List<Game> getAllFuture(string team)
        {
            return _repository
                .findAll(team)
                .Where(game => DateTime.Compare(game.getTime(), DateTime.UtcNow) > 0)
                .ToList();
        }

        public List<Game> getAllPrevious(string team)
        {
            return _repository
                .findAll(team)
                .Where(game => DateTime.Compare(game.getTime(), DateTime.UtcNow) <= 0)
                .ToList();
        }
    }
}