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
        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        [HttpGet]
        public async Task<List<QuestionDTO>> GetQuestions()
        {
            return await _questionRepository.GetQuestions();
        }
        [HttpGet("[action]/{questionName}")]
        public async Task<IActionResult> getQuestionsByName(string questionName)
        {
            var questions = await _questionRepository.GetQuestionsByName(questionName);
            if (questions == null)
            {
                return BadRequest();
            }
            return Ok(questions);
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
