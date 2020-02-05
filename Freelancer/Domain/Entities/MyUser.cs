using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {
    public class MyUser {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
