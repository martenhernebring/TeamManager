using TeamManager.API.Dtos;
using TeamManager.API.Models;

namespace TeamManager.API.Services
{
    public interface IPlayerService
    {
        void Add(PlayerDto playerDto);
        public HashSet<Player> GetAllFrom(string team);
        void Remove(PlayerDto playerDto);
    }
}