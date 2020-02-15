using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;

namespace Freelancer.Services.SkillService {
    public class SkillService : ISkillService {
        private readonly ISkillRepository skillRepository;
        public SkillService(ISkillRepository skillRepository) => this.skillRepository = skillRepository;
        public async Task AddRangeAsync(IEnumerable<Skill> skills) {
            await this.skillRepository.AddRangeAsync(skills);
        }

        public async Task<IEnumerable<Skill>> GetSkillsAsync() {
            return await this.skillRepository.GetAllAsync();
        }
    }
}
