using Admin_Site.Interfaces;
using CommonStorage.Paging;
using CommonStorage.Question;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Site.ViewComponents
{
    public class QuestionViewComponent : ViewComponent
    {
        public readonly IQuestion_Service _question_Service;
        List<QuestionDTO> listQuestion;
        public QuestionViewComponent(IQuestion_Service question_Service)
        {
            _question_Service = question_Service;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? categoryId, string questionName, int page)
        {
            listQuestion = new List<QuestionDTO>();
            if (categoryId == null && questionName == null)
            {
                listQuestion = await _question_Service.getListQuestions();
            }
            //else if (categoryId != null)
            //{
            //    listQuestion = await _product_Service.getProductsByCategoryId(int.Parse(categoryId.ToString()));
            //}
            else
            {
                listQuestion = await _question_Service.getQuestionsByName(questionName);
                if (listQuestion.Count == 0)
                {
                    ViewBag.search = "Không tìm thấy câu hỏi nào!";
                }
            }
            return View<List<QuestionDTO>>("Question", Paging(page, listQuestion));
        }
        public List<QuestionDTO> Paging(int page, List<QuestionDTO> list)
        {
            const int pageSize = 9;
            if (page < 1)
            {
                page = 1;
            }
            int totalItems = list.Count();
            PagerDTO pager = new PagerDTO(totalItems, page, pageSize);
            int recSkip = (page - 1) * pageSize;
            var data = list.Skip(recSkip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
            return data;
        }
    }
}
