using TeamManager.API.Models;
using TeamManager.API.Services;

namespace TeamManager.UnitTests.Services;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void viewAllMyTeamsGamesReturnsEmptyWhenNoGamesWasFound()
    {
        TeamManagerService service = new TeamManagerService();
        List<Game> allMyTeamsGames = service.getAll("MyTeam");
        Assert.That(allMyTeamsGames.Count, Is.EqualTo(0));
    }
}