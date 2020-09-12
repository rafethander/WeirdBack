using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeirdBack.Models
{
    public class Login
    {
        public Guid LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
