using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {
    public class JobsSkill {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int SkillId { get; set; }

        public virtual Job Job { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
