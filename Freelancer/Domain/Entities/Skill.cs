﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {  
    public class Skill {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<JobsSkill> JobsSkills { get; set; }
        public virtual IEnumerable<SkillUser> SkillUsers { get; set; }
    }
}
