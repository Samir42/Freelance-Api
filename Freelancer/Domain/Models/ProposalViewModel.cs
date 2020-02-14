using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Models {
    public class ProposalViewModel {
        public int JobId { get; set; }
        public int FreelancerId { get; set; }
        public string RequestDescription { get; set; }
        public int HowManyDay { get; set; }
        public int Offer { get; set; }
    }
}
