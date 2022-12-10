using Microsoft.AspNetCore.Mvc;
using TeamManager.API.Models;
using TeamManager.API.Services;

namespace TeamManager.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{

    private readonly IGameService _gameService;
    private readonly IPlayerService _playerService;

    public TeamController(IGameService gameService, IPlayerService playerService)
    {
        _gameService = gameService;
        _playerService = playerService;
    }

    [HttpGet(Name = "GetAllUpcomingGames")]
    public OkObjectResult GetAllUpcomingGames(string team)
    {
        return Ok(_gameService.getAllFuture(team));
    }

    [HttpGet(Name = "GetAllPreviousGames")]
    public OkObjectResult GetAllPreviousGames(string team)
    {
        return Ok(_gameService.getAllPrevious(team));
    }

    [HttpGet(Name = "GetAllPlayers")]
    public OkObjectResult GetAllPlayers(string team)
    {
        return Ok(_playerService.getAllFrom(team));
    }

    [HttpPost(Name = "AddGame")]
    public OkResult AddGame(Game game)
    {
        _gameService.add(game);
        return Ok();
    }
        
}
