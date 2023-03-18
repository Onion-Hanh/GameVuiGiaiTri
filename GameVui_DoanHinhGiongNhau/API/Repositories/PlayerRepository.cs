using API.Data;
using API.Interfaces;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonStorage.Player;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public readonly GameVuiDBContext _gameVuiDBContext;
        public readonly IMapper _mapper;
        public PlayerRepository(GameVuiDBContext gameVuiDBContext, IMapper mapper)
        {
            _gameVuiDBContext = gameVuiDBContext;
            _mapper = mapper;
        }
        public async Task<List<PlayerDTO>> GetPlayers()
        {
            return await _gameVuiDBContext.players.ProjectTo<PlayerDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public bool AddPlayer(PlayerDTO newPlayer)
        {
            Player player = new Player();
            player.PlayerName = newPlayer.PlayerName;
            try
            {
                _gameVuiDBContext.players.Add(player);
                _gameVuiDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
