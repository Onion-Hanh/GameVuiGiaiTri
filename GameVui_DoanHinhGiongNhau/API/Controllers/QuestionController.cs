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
        [HttpPost]
        public bool AddQuestion(QuestionDTO newQuestion)
        {
            if (_questionRepository.AddQuestion(newQuestion))
            {
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool UpdateQuestion(QuestionDTO updateQuestion)
        {
            if (_questionRepository.UpdateQuestion(updateQuestion))
            {
                return true;
            }
            return false;
        }
        [HttpPut("{questionId}")]
        public bool SoftDeleteQuestion(int questionId)
        {
            if (_questionRepository.SoftDeleteQuestion(questionId))
            {
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool HardDeleteQuestion(int questionId)
        {
            if (_questionRepository.HardDeleteQuestion(questionId))
            {
                return true;
            }
            return false;
        }
    }
}
