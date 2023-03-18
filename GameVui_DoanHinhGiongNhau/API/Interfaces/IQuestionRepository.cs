using CommonStorage.Question;

namespace API.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<QuestionDTO>> GetQuestions();
        bool AddQuestion(QuestionDTO newQuestion);
        bool UpdateQuestion(QuestionDTO updateQuestion);
        bool SoftDeleteQuestion(int questionId);
        bool HardDeleteQuestion(int questionId);
    }
}
