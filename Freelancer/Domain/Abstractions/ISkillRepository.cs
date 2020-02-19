using Freelancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface ISkillRepository : IRepository<Skill>{
        Task AddRangeAsync(IEnumerable<SkillUser> skillsUsers);
    }
}
