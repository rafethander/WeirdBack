using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeirdBack.Models;

namespace WeirdBack.Dtos
{
   public class ExamAddDto
    {
        public string Name { get; set; }
        public IList<Question> Questions { get; set; }
    }

    public class ExamGetDto
    {
        public Guid ExamId { get; set; }
        public DateTime IsCreated { get; set; }
        public string Name { get; set; }

        private string isCreatedString;

        public string IsCreatedString
        {
            get { return isCreatedString; }
            set { isCreatedString = IsCreated.ToShortDateString(); }
        }

    }
}
