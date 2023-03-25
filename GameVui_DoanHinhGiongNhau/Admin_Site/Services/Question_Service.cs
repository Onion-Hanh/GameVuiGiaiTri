using Admin_Site.Interfaces;
using CommonStorage.Question;
using Newtonsoft.Json;

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
    }
}
