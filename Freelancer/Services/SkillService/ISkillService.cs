using Freelancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Services.SkillService {
    public interface ISkillService {
        Task<IEnumerable<Skill>> GetSkillsAsync();
        Task AddRangeAsync(IEnumerable<SkillUser> skillsUsers);
        Task AddRangeAsync(IEnumerable<JobsSkill> jobsSkills);
    }
}
