using API.Data;
using API.Interfaces;
using API.Models;
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
        public bool AddQuestion(QuestionDTO newQuestion)
        {
            Question question = new Question();
            question.QuestionContent = newQuestion.QuestionContent;
            question.Answer_1 = newQuestion.Answer_1;
            question.Answer_2 = newQuestion.Answer_2;
            question.Answer_3 = newQuestion.Answer_3;
            question.Answer_4 = newQuestion.Answer_4;
            question.CorrectAnswer = newQuestion.CorrectAnswer;
            question.AnswerTime = newQuestion.AnswerTime;
            question.Point = newQuestion.Point;
            question.Status = true;
            try
            {
                _gameVuiDBContext.questions.Add(question);
                _gameVuiDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateQuestion(QuestionDTO updateQuestion)
        {
            try
            {
                var question = _gameVuiDBContext.questions.Where(c => c.Id == updateQuestion.Id).FirstOrDefault();
                if (question != null)
                {
                    question.QuestionContent = updateQuestion.QuestionContent;
                    question.Answer_1 = updateQuestion.Answer_1;
                    question.Answer_2 = updateQuestion.Answer_2;
                    question.Answer_3 = updateQuestion.Answer_3;
                    question.Answer_4 = updateQuestion.Answer_4;
                    question.CorrectAnswer = updateQuestion.CorrectAnswer;
                    question.AnswerTime = updateQuestion.AnswerTime;
                    question.Point = updateQuestion.Point;
                    question.Status = updateQuestion.Status;
                    _gameVuiDBContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool SoftDeleteQuestion(int questionId)
        {
            try
            {
                var question = _gameVuiDBContext.questions.Where(c => c.Id == questionId).FirstOrDefault();
                if (question != null)
                {                   
                    question.Status = false;
                    _gameVuiDBContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool HardDeleteQuestion(int questionId)
        {
            try
            {
                var question = _gameVuiDBContext.questions.Where(c => c.Id == questionId).FirstOrDefault();
                if (question != null)
                {
                    _gameVuiDBContext.questions.Remove(question);
                    _gameVuiDBContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
