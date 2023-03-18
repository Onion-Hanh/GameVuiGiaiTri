using API.Models;
using AutoMapper;
using CommonStorage.Player;

namespace API.Mapping
{
    public class Player_Mapping : Profile
    {
        public Player_Mapping()
        {
            CreateMap<Player, PlayerDTO>();
        }
    }
}
