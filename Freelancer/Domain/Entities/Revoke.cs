using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {
    public class Revoke {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string Note { get; set; }
        public Request Request { get; set; }
    }
}
