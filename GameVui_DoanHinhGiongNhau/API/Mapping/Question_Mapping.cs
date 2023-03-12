using API.Models;
using AutoMapper;
using CommonStorage.Question;

namespace API.Mapping
{
    public class Question_Mapping : Profile
    {
        public Question_Mapping()
        {
            CreateMap<Question, QuestionDTO>();
            //CreateMap<Category, CategoryAminDTO>();
        }
    }
}
