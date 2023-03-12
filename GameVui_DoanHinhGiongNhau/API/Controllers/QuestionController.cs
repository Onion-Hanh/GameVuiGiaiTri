using API.Interfaces;
using CommonStorage.Question;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public readonly IQuestionRepository _questionRepository;
        //Customer
        public QuestionController(IQuestionRepository qeustionRepository)
        {
            _questionRepository = qeustionRepository;
        }
        [HttpGet]
        public async Task<List<QuestionDTO>> GetQuestions()
        {
            return await _questionRepository.GetQuestions();
        }
    }
}
