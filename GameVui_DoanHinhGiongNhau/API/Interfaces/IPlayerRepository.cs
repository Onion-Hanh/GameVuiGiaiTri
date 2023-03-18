using CommonStorage.Player;

namespace API.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<PlayerDTO>> GetPlayers();
        bool AddPlayer(PlayerDTO newPlayer);
    }
}
