using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {
    public class Request {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int FreelancerId { get; set; }
        public string RequestDescription { get; set; }
        public int HowManyDay { get; set; }
        public int Offer { get; set; }
        public Freelancer Freelancer { get; set; }
        public Job Job { get; set; }
    }
}
