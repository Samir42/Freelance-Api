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
        public IEnumerable<SkillsUser> SkillsUsers { get; set; }
    }
}
