using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeirdBack.Models
{
    public class Topic
    {
        public Guid TopicId { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
    }
}
