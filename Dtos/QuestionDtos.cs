using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeirdBack.Models;

namespace WeirdBack.Dtos
{
   public class QuestionGetDto
    {
        public Exam  Exam { get; set; }
        public string QuestionSentence { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
