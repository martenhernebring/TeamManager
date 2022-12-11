using Microsoft.AspNetCore.Mvc;
using TeamManager.API.Dtos;
using TeamManager.API.Models;
using TeamManager.API.Services;

namespace TeamManager.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _service;

    public GameController(IGameService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetAllGames")]
    public OkObjectResult GetAllGames(string team, bool history)
    {
        if(history)
            return Ok(_service.GetAllPrevious(team));
        else
            return Ok(_service.GetAllFuture(team));
    }

    [HttpPost(Name = "AddSoccerGame")]
    public OkResult AddSoccerGame(AddGame addGameDto)
    {
        _service.Add(addGameDto);
        return Ok();
    }
        
}
