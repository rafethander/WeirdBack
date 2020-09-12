using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeirdBack.Models
{
    public class Exam
    {
        public Guid ExamId { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime IsCreated { get; set; }
        [NotMapped]
        public string IsCreatedString { get; set; }
        public string Name { get; set; }


        //Fk Questions
        public virtual ICollection<Question> Questions { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
        }

    }
}
