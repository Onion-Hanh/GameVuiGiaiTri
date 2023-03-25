using Admin_Site.Models;
using CommonStorage.Player;
using CommonStorage.Question;
using CommonStorage.Record;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Admin_Site.Controllers
{
    public class HomeController : Controller
    {
        List<QuestionDTO> listQuestion = new List<QuestionDTO>();
        List<PlayerDTO> listPlayer = new List<PlayerDTO>();
        List<RecordDTO> listRecord = new List<RecordDTO>();
        readonly Paging _paging;
        public HomeController(IOptions<Paging> paging)
        {
            _paging = paging.Value;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogInAction(IFormCollection form)
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
        ////Product detail page
        //public async Task<IActionResult> ProductDetail(int productId)
        //{
        //    ViewBag.productId = productId;
        //    _paging.product_Id = productId;
        //    return View();
        //}
        //Search product
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
    }
}