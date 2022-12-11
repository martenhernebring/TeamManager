using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TeamManager.API.Dtos;
using TeamManager.API.Models;
using TeamManager.API.Repositories;
using TeamManager.API.Services;

namespace TeamManager.UnitTests.Services
{
    public class PlayerServiceTests
    {
        private Mock<IPlayerRepository>? mockRepository;
        private int usedJersey;
        private PlayerDto? playerDto;
        private IPlayerService? service;
        private Player? player;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IPlayerRepository>();
            HashSet<Player> players = new HashSet<Player>();
            usedJersey = 11;
            playerDto = new PlayerDto();
            playerDto.Team = "MyTeam";
            playerDto.Jersey = usedJersey;
            player = new Player();
            player.Id = 0;
            player.Team = playerDto.Team;
            player.Jersey = usedJersey;
            players.Add(player);
            mockRepository.Setup(repo => repo
                .FindAll("MyTeam"))
                .Returns(players);
            service = new PlayerService(mockRepository.Object);
            Assert.NotNull(service);
        }

        [Test]
        public void givenOneAddedEarlierViewAllPlayersFromMyTeamReturnsOne()
        {
            HashSet<Player> allPlayersFromMyTeam = service!.GetAllFrom("MyTeam");

            Assert.That(allPlayersFromMyTeam.Count, Is.EqualTo(1));
        }

        [Test]
        public void givenOneAddedEarlierViewAllPlayersFromMyTeamReturnsSameJersey()
        {
            HashSet<Player> allPlayersFromMyTeam = service!.GetAllFrom("MyTeam");

            Assert.That(allPlayersFromMyTeam.First().Jersey, Is.EqualTo(usedJersey));
        }

        [Test]
        public void addAPlayerToMyTeamCallsSaveInRepositoryOnce()
        {
            Assert.NotNull(playerDto);
            service!.Add(playerDto!);
            mockRepository!.Verify(repo => repo.Save(It.IsAny<Player>()), Times.Once());
        }

        [Test]
        public void removeAPlayerFromMyTeamCallsDeleteInRepositoryOnce()
        {
            service!.Remove(playerDto!);
            Assert.NotNull(mockRepository);
            mockRepository!.Verify(
                repo => repo.Delete(It.IsAny<string>(), It.IsAny<int>()), 
                Times.Once());
        }    
    }
}