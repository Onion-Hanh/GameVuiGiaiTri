using System.Drawing;

namespace API.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public string Answer_1 { get; set; }
        public string Answer_2 { get; set; }
        public string Answer_3 { get; set; }
        public string Answer_4 { get; set; }
        public int AnswerTimne { get; set; }
        public int Point { get; set; }
    }
}
