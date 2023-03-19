using API.Models;
using AutoMapper;
using CommonStorage.Record;

namespace API.Mapping
{
    public class Record_Mapping : Profile
    {
        public Record_Mapping()
        {
            CreateMap<Record, RecordDTO>().ForMember(dto => dto.PlayerName, src => src.MapFrom(player => player.Player.PlayerName));
        }
    }
}
