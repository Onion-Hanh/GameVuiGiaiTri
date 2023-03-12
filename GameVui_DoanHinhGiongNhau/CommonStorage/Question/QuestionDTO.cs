using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonStorage.Question
{
    public class QuestionDTO
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
