using Moq;
using TeamManager.API.Dtos;
using TeamManager.API.Models;
using TeamManager.API.Repositories;
using TeamManager.API.Services;

namespace TeamManager.UnitTests.Services;

public class Tests
{
    private Mock<IGameRepository>? mockRepository;
    private Game? previousGame;
    private GameService? service;

    [SetUp]
    public void Setup()
    {
        mockRepository = new Mock<IGameRepository>();
        previousGame = new SoccerGame();
        previousGame.Team = "MyTeam";
        DateTime now = DateTime.UtcNow;
        previousGame.Time = now.AddMonths(-1);
        List<Game> games = new List<Game>();
        games.Add(previousGame);
        Game futureGame = new SoccerGame();
        futureGame.Team = "MyTeam";
        futureGame.Time = now.AddMonths(1);
        games.Add(futureGame);
        mockRepository.Setup(repo => repo
            .FindAll("MyTeam"))
            .Returns(games);
        mockRepository.Setup(repo => repo
            .FindAll("NewTeam"))
            .Returns(new List<Game>());
        service = new GameService(mockRepository.Object);
        Assert.NotNull(service);
    }

    [Test]
    public void givenOnePreviousAndOneFutureViewAllMyTeamsUpcomingGamesReturnsOnlyOneFutureGames()
    {
        List<Game> allMyTeamsGames = service!.GetAllFuture("MyTeam");
        Assert.That(allMyTeamsGames.Count, Is.EqualTo(1));
    }

    [Test]
    public void givenOnePreviousAndOneFutureViewAllMyTeamsPreviousGamesReturnsSameGameFromThePast()
    {
        List<Game> allMyTeamsGames = service!.GetAllPrevious("MyTeam");
        Assert.That(allMyTeamsGames.First(), Is.EqualTo(previousGame));
    }

    [Test]
    public void newlyRegisteredTeamManagerViewIsEmpty()
    {

        List<Game> noRegFutureGames = service!.GetAllFuture("NewTeam");
        List<Game> noRegPastGames = service.GetAllPrevious("NewTeam");
        Assert.That(noRegFutureGames.Count, Is.EqualTo(0));
        Assert.That(noRegPastGames.Count, Is.EqualTo(0));
    } 

    [Test]
    public void addAGameToMyTeamCallsSaveInRepositoryOnce()
    {
        AddGame addGame = new AddGame();
        addGame.Team = "MyTeam";
        addGame.Time = DateTime.UtcNow;
        service!.Add(addGame);
        Assert.NotNull(mockRepository);
        mockRepository!.Verify(repo => repo.Save(It.IsAny<Game>()), Times.Once());
    }

}