using CommonStorage.Question;

namespace Admin_Site.Interfaces
{
    public interface IQuestion_Service
    {
        Task<List<QuestionDTO>> getListQuestions();
        Task<List<QuestionDTO>> getQuestionsByName(string questionName);
    }
}
