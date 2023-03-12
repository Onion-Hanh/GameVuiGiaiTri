using CommonStorage.Question;

namespace API.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<QuestionDTO>> GetQuestions();
    }
}
