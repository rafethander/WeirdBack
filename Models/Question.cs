using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeirdBack.Models
{
    public class Question
    {

        public Guid QuestionId { get; set; }
        public DateTime IsCreated { get; set; }
        public bool IsDeleted { get; set; }
        public string QuestionSentence { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }

        //Fk Exam
        public virtual Exam Exam { get; set; }

    }
}
