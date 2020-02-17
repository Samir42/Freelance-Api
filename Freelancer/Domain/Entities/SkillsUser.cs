using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {
    public class SkillsUser {
        public int Id { get; set; }
        public int FreelancerId { get; set; }
        public int SkillId { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
