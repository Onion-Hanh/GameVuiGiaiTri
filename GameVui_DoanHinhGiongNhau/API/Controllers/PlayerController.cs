using API.Interfaces;
using API.Repositories;
using CommonStorage.Player;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public readonly IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        [HttpGet]
        public async Task<List<PlayerDTO>> GetPlayers()
        {
            return await _playerRepository.GetPlayers();
        }
        [HttpPost]
        public bool AddPlayer(PlayerDTO newPlayer)
        {
            if (_playerRepository.AddPlayer(newPlayer))
            {
                return true;
            }
            return false;
        }
    }
}
