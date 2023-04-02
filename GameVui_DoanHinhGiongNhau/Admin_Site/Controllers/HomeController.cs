using Admin_Site.Interfaces;
using Admin_Site.Models;
using CommonStorage.Player;
using CommonStorage.Question;
using CommonStorage.Record;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Admin_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestion_Service _question_Service;
        List<QuestionDTO> listQuestion = new List<QuestionDTO>();
        List<PlayerDTO> listPlayer = new List<PlayerDTO>();
        List<RecordDTO> listRecord = new List<RecordDTO>();
        readonly Paging _paging;
        public HomeController(IQuestion_Service question_Service, IOptions<Paging> paging)
        {
            _question_Service = question_Service;
            _paging = paging.Value;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(IFormCollection form)
        {
            string userName = form["inputUserName"].ToString();
            string password = form["inputPassword"].ToString();
            if (userName == "Hanh" && password == "123")
            {
                ViewData["error"] = "";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng!";
                return RedirectToAction("LogIn", "Home");
            }
        }     
        //Main page
        public async Task<IActionResult> Index(int? categoryId, bool index, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            if (index == true)
            {
                _paging.category_Id = null;
                _paging.question_Name = null;
            }
            if (categoryId != null)
            {
                index = false;
                _paging.category_Id = categoryId;
                _paging.question_Name = null;
            }
            ViewBag.productName = _paging.question_Name;
            ViewBag.categoryId = _paging.category_Id;
            ViewBag.page = page;
            return View();
        }
        //Question detail page
        public async Task<IActionResult> QuestionDetail(int questionId)
        {
            ViewBag.questionId = questionId;
            _paging.question_Id = questionId;
            return View();
        }
        //Search question
        public async Task<IActionResult> SearchQuestion(IFormCollection form, bool index, int? page)
        {
            if (page == null)
            {
                page = 1;
            }
            ViewBag.page = page;
            listQuestion.Clear();
            string questionName = form["search"];
            if (questionName != null)
            {
                index = false;
                _paging.category_Id = null;
                _paging.question_Name = questionName;
                ViewBag.questionName = _paging.question_Name;
            }
            return View("Index", listQuestion);
        }
        //Add question page
        [HttpGet]
        public IActionResult AddQuestion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddQuestion(IFormCollection form)
        {
            QuestionDTO question = new QuestionDTO();
            string status = "";
            string difficultLevel = "";
            if (form["status"].ToString() == "")
            {
                status = "true";
            }
            else
            {
                status = form["status"].ToString();
            }
            if (form["difficultLevel"].ToString() == "")
            {
                difficultLevel = "1";
            }
            else 
            {
                difficultLevel = form["difficultLevel"].ToString();
            }
            question.QuestionContent = form["questionContent"].ToString();
            question.Answer_1 = form["questionAnswer1"].ToString();
            question.Answer_2 = form["questionAnswer2"].ToString();
            question.Answer_3 = form["questionAnswer3"].ToString();
            question.Answer_4 = form["questionAnswer4"].ToString();
            question.CorrectAnswer = form["correctAnswer"].ToString();
            question.AnswerTime = int.Parse(form["timeAnswer"].ToString());
            question.DifficultLevel = int.Parse(difficultLevel);
            question.Status = bool.Parse(status);
            if (_question_Service.addQuestion(question).Result == true)
            {
                ViewBag.AddResult = "Thêm thành công!";
            }
            else
            {
                ViewBag.AddResult = "Thêm thất bại!";
            }
            ViewBag.productName = null;
            ViewBag.categoryId = null;
            ViewBag.page = 1;
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(IFormCollection form)
        {
            QuestionDTO question = new QuestionDTO();
            question.Id = int.Parse(form["questionIdHidden"].ToString());
            question.QuestionContent = form["questionContent"].ToString();
            question.Answer_1 = form["questionAnswer1"].ToString();
            question.Answer_2 = form["questionAnswer2"].ToString();
            question.Answer_3 = form["questionAnswer3"].ToString();
            question.Answer_4 = form["questionAnswer4"].ToString();
            question.CorrectAnswer = form["correctAnswer"].ToString();
            question.AnswerTime = int.Parse(form["timeAnswer"].ToString());
            question.DifficultLevel = int.Parse(form["difficultLevel"].ToString());
            question.Status = bool.Parse(form["status"].ToString());
            if (_question_Service.updateQuestionById(question).Result == true)
            {
                ViewBag.AddResult = "Cập nhật thành công!";
            }
            else
            {
                ViewBag.AddResult = "Cập nhật thất bại!";
            }
            ViewBag.productName = null;
            ViewBag.categoryId = null;
            ViewBag.page = 1;
            return View("Index");
        }
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            listQuestion = _question_Service.getListQuestions().Result.ToList();
            QuestionDTO question = new QuestionDTO();
            question = listQuestion.Where(c => c.Id == questionId).FirstOrDefault();
            question.Status = false;
            if (_question_Service.updateQuestionById(question).Result == true)
            {
                ViewBag.AddResult = "Xóa thành công!";
            }
            else
            {
                ViewBag.AddResult = "Xóa thất bại!";
            }
            ViewBag.productName = null;
            ViewBag.categoryId = null;
            ViewBag.page = 1;
            listQuestion.Clear();
            return View("Index");
        }
    }
}