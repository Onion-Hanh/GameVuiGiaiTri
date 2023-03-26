using Admin_Site.Interfaces;
using CommonStorage.Question;
using Newtonsoft.Json;
using System.Text;

namespace Admin_Site.Services
{
    public class Question_Service : IQuestion_Service
    {
        IHttpClientFactory _factory;
        List<QuestionDTO> questions;
        public Question_Service(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<List<QuestionDTO>> getListQuestions()
        {
            questions = new List<QuestionDTO>();
            var httpClient = _factory.CreateClient();
            var reponseMessage = await httpClient.GetAsync("Question");
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data = await reponseMessage.Content.ReadAsStringAsync();
                questions = JsonConvert.DeserializeObject<List<QuestionDTO>>(data);
            }
            return questions;
        }
        public async Task<List<QuestionDTO>> getQuestionsByName(string questionName)
        {
            questions = new List<QuestionDTO>();
            var httpClient = _factory.CreateClient();
            var reponseMessage = await httpClient.GetAsync("Question/getQuestionsByName/" + questionName);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data = await reponseMessage.Content.ReadAsStringAsync();
                questions = JsonConvert.DeserializeObject<List<QuestionDTO>>(data);
            }
            return questions;
        }
        public async Task<QuestionDTO> getQuestionById(int questionId)
        {
            QuestionDTO question = new QuestionDTO();
            var httpClient = _factory.CreateClient();
            var reponseMessage = await httpClient.GetAsync("Question/getQuestionById/" + questionId);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data = await reponseMessage.Content.ReadAsStringAsync();
                question = JsonConvert.DeserializeObject<QuestionDTO>(data);
            }
            return question;
        }
        public async Task<bool> addQuestion(QuestionDTO question)
        {
            try
            {
                var httpClient = _factory.CreateClient();
                string data = JsonConvert.SerializeObject(question);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                var reponseMessage = await httpClient.PostAsync("Question", content);
                if (reponseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        //public async Task<bool> updateQuestionById(QuestionDTO quesiton)
        //{
        //    try
        //    {
        //        var httpClient = _factory.CreateClient();
        //        string data = JsonConvert.SerializeObject(receipt);
        //        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //        var reponseMessage = await httpClient.PostAsync("Receipt", content);
        //        if (reponseMessage.IsSuccessStatusCode)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
