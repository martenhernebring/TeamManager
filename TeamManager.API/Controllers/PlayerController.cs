using Microsoft.AspNetCore.Mvc;
using TeamManager.API.Dtos;
using TeamManager.API.Models;
using TeamManager.API.Services;

namespace TeamManager.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _service;

    public PlayerController(IPlayerService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetAllPlayers")]
    public OkObjectResult GetAllPlayers(string team)
    {
        return Ok(_service.GetAllFrom(team));
    }

    [HttpPost(Name = "AddPlayer")]
    public OkResult AddPlayer(PlayerDto playerDto)
    {
        _service.Add(playerDto);
        return Ok();
    }

    [HttpDelete(Name = "RemovePlayer")]
    public OkResult RemovePlayer(PlayerDto playerDto)
    {
        _service.Remove(playerDto);
        return Ok();
    }
        
}
