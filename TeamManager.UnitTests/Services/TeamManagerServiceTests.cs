using Moq;
using TeamManager.API.Models;
using TeamManager.API.Repositories;
using TeamManager.API.Services;

namespace TeamManager.UnitTests.Services;

public class Tests
{
    private Game previousGame;
    private TeamManagerService service;

    [SetUp]
    public void Setup()
    {
        var mockRepository = new Mock<ITeamRepository>();
        DateTime now = DateTime.UtcNow;
        DateTime aMonthInThePast = now.AddMonths(-1);
        previousGame = new SoccerGame("MyGame2", aMonthInThePast);
        List<Game> games = new List<Game>();
        games.Add(previousGame);
        DateTime aMonthFromNow = now.AddMonths(1);
        games.Add(new SoccerGame("MyGame1", aMonthFromNow));
        mockRepository.Setup(repo => repo
            .findAll("MyTeam"))
            .Returns(games);
        service = new TeamManagerService(mockRepository.Object);
    }

    [Test]
    public void givenOnePreviousAndOneFutureViewAllMyTeamsUpcomingGamesReturnsOnlyOneFutureGames()
    {
        List<Game> allMyTeamsGames = service.getAllFuture("MyTeam");
        Assert.That(allMyTeamsGames.Count, Is.EqualTo(1));
    }

    [Test]
    public void givenOnePreviousAndOneFutureViewAllMyTeamsPreviousGamesReturnsOnlyOneGameInThePast()
    {
        List<Game> allMyTeamsGames = service.getAllPrevious("MyTeam");
        Assert.That(allMyTeamsGames.First(), Is.EqualTo(previousGame));
    }

/*
    [Test]
    public void viewAllMyTeamsUpcomingGamesReturnsOneGameWhenAGameWasAddedEarlier()
    {
        DateTime aMonthFromNow = DateTime.UtcNow;
        aMonthFromNow.AddMonths(1);
        List<Game> games = new List<Game>();
        games.Add(new SoccerGame("MyTeam", DateTime.UtcNow));
        mockRepository.Setup(repo => repo
            .findAll("MyTeam"))
            .Returns(games);
        TeamManagerService service = new TeamManagerService(mockRepository.Object);

        List<Game> allMyTeamsGames = service.getAllFuture("MyTeam");

        Assert.That(allMyTeamsGames.Count, Is.EqualTo(1));
    }

    [Test]
    public void addAGameToMyTeamCallsSaveInRepositoryOnce()
    {
        TeamManagerService service = new TeamManagerService(mockRepository.Object);

        service.add(new SoccerGame("MyTeam", DateTime.UtcNow));

        mockRepository.Verify(repo => repo.save(It.IsAny<Game>()), Times.Once());
    }

    [Test]
    public void viewAllMyTeamsPreviousGamesReturnsAListOfGamesInThePast()
    {
        DateTime aMonthFromNow = DateTime.UtcNow;
        aMonthFromNow.AddMonths(1);
        List<Game> games = new List<Game>();
        games.Add(new SoccerGame("MyGame", aMonthFromNow));
        mockRepository.Setup(repo => repo
            .findAll("MyTeam"))
            .Returns(games);
        TeamManagerService service = new TeamManagerService(mockRepository.Object);

        List<Game> allMyTeamsGames = service.getAll("MyTeam");

        Assert.That(allMyTeamsGames.Count, Is.EqualTo(1));
    }*/
}