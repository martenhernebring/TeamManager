using Moq;
using TeamManager.API.Models;
using TeamManager.API.Repositories;
using TeamManager.API.Services;

namespace TeamManager.UnitTests.Services;

public class Tests
{
    private Mock<IGameRepository> mockRepository;
    private Game previousGame;
    private GameService service;

    [SetUp]
    public void Setup()
    {
        mockRepository = new Mock<IGameRepository>();
        DateTime now = DateTime.UtcNow;
        DateTime aMonthInThePast = now.AddMonths(-1);
        previousGame = new SoccerGame("MyGame1", aMonthInThePast);
        List<Game> games = new List<Game>();
        games.Add(previousGame);
        DateTime aMonthFromNow = now.AddMonths(1);
        games.Add(new SoccerGame("MyGame2", aMonthFromNow));
        mockRepository.Setup(repo => repo
            .findAll("MyTeam"))
            .Returns(games);
        mockRepository.Setup(repo => repo
            .findAll("NewTeam"))
            .Returns(new List<Game>());
        service = new GameService(mockRepository.Object);
    }

    [Test]
    public void givenOnePreviousAndOneFutureViewAllMyTeamsUpcomingGamesReturnsOnlyOneFutureGames()
    {
        List<Game> allMyTeamsGames = service.getAllFuture("MyTeam");
        Assert.That(allMyTeamsGames.Count, Is.EqualTo(1));
    }

    [Test]
    public void givenOnePreviousAndOneFutureViewAllMyTeamsPreviousGamesReturnsSameGameFromThePast()
    {
        List<Game> allMyTeamsGames = service.getAllPrevious("MyTeam");
        Assert.That(allMyTeamsGames.First(), Is.EqualTo(previousGame));
    }

    [Test]
    public void newlyRegisteredTeamManagerViewIsEmpty()
    {
        List<Game> noRegFutureGames = service.getAllFuture("NewTeam");
        List<Game> noRegPastGames = service.getAllPrevious("NewTeam");
        Assert.That(noRegFutureGames.Count, Is.EqualTo(0));
        Assert.That(noRegPastGames.Count, Is.EqualTo(0));
    } 

    [Test]
    public void addAGameToMyTeamCallsSaveInRepositoryOnce()
    {
        service.add(new SoccerGame("MyTeam", DateTime.UtcNow));
        mockRepository.Verify(repo => repo.save(It.IsAny<Game>()), Times.Once());
    }

}