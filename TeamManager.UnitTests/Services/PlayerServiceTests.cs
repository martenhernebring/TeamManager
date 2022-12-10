using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TeamManager.API.Models;
using TeamManager.API.Repositories;
using TeamManager.API.Services;

namespace TeamManager.UnitTests.Services
{
    public class PlayerServiceTests
    {
        private Mock<IPlayerRepository> mockRepository;
        private int usedJersey;
        private Player player;
        private IPlayerService service;

        [SetUp]
        public void Setup()
        {
            mockRepository = new Mock<IPlayerRepository>();
            List<Player> players = new List<Player>();
            usedJersey = 11;
            player = new Player("MyTeam", usedJersey);
            players.Add(player);
            mockRepository.Setup(repo => repo
                .findAll("MyTeam"))
                .Returns(players);
            service = new PlayerService(mockRepository.Object);
        }

        [Test]
        public void givenOneAddedEarlierViewAllPlayersFromMyTeamReturnsOne()
        {
            List<Player> allPlayersFromMyTeam = service.getAllFrom("MyTeam");

            Assert.That(allPlayersFromMyTeam.Count, Is.EqualTo(1));
        }

        [Test]
        public void givenOneAddedEarlierViewAllPlayersFromMyTeamReturnsSameJersey()
        {
            List<Player> allPlayersFromMyTeam = service.getAllFrom("MyTeam");

            Assert.That(allPlayersFromMyTeam.First().getJersey(), Is.EqualTo(usedJersey));
        }

        [Test]
        public void addAPlayerToMyTeamCallsSaveInRepositoryOnce()
        {
            service.add(player);
            mockRepository.Verify(repo => repo.save(It.IsAny<Player>()), Times.Once());
        }

        [Test]
        public void removeAPlayerFromMyTeamCallsDeleteInRepositoryOnce()
        {
            service.remove(player);
            mockRepository.Verify(repo => repo.delete(It.IsAny<Player>()), Times.Once());
        }    
    }
}