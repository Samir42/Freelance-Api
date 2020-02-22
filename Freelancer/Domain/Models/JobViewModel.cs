using Freelancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Models {
    public class JobViewModel {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int FreelancerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public virtual IEnumerable<JobsSkill> JobsSkills { get; set; }
    }
}
