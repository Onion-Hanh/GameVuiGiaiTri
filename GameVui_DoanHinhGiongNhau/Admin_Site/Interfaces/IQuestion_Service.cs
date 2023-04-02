using CommonStorage.Question;

namespace Admin_Site.Interfaces
{
    public interface IQuestion_Service
    {
        Task<List<QuestionDTO>> getListQuestions();
        Task<List<QuestionDTO>> getQuestionsByName(string questionName);
        Task<QuestionDTO> getQuestionById(int questionId);
        Task<bool> addQuestion(QuestionDTO question);
        Task<bool> updateQuestionById(QuestionDTO question);
        //Task<bool> deleteQuestionById(QuestionDTO question);
    }
}
