using CommonStorage.Question;

namespace API.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<QuestionDTO>> GetQuestions();
        Task<List<QuestionDTO>> GetQuestionsByName(string questionName);
        Task<QuestionDTO> GetQuestionDetail(int questionId);
        bool AddQuestion(QuestionDTO newQuestion);
        bool UpdateQuestion(QuestionDTO updateQuestion);
        bool SoftDeleteQuestion(int questionId);
        bool HardDeleteQuestion(int questionId);

    }
}
