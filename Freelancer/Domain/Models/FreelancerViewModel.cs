using Freelancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Models {
    public class FreelancerViewModel {
        public int Id { get; set; }
        public int PayHourly { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<SkillUser> SkillUsers { get; set; }
    }
}
