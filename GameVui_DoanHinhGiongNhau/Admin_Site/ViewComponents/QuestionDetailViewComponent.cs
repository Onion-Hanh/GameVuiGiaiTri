using Admin_Site.Interfaces;
using CommonStorage.Question;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Site.ViewComponents
{
    public class QuestionDetailViewComponent : ViewComponent
    {
        public readonly IQuestion_Service _question_Service;
        QuestionDTO question;
        public QuestionDetailViewComponent(IQuestion_Service question_Service)
        {
            _question_Service = question_Service;
        }
        public async Task<IViewComponentResult> InvokeAsync(int questionId)
        {
            question = new QuestionDTO();
            question = await _question_Service.getQuestionById(questionId);
            return View("QuestionDetail", question);
        }
    }
}
