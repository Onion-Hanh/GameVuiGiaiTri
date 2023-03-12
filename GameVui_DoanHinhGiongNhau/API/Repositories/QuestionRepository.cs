using API.Data;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonStorage.Question;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public readonly GameVuiDBContext _gameVuiDBContext;
        public readonly IMapper _mapper;
        public QuestionRepository(GameVuiDBContext gameVuiDBContext, IMapper mapper)
        {
            _gameVuiDBContext = gameVuiDBContext;
            _mapper = mapper;
        }

        public async Task<List<QuestionDTO>> GetQuestions()
        {
            return await _gameVuiDBContext.questions.ProjectTo<QuestionDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
