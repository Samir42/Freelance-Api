using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {
    public class Freelancer {
        public int Id { get; set; }
        public int PayHourly { get; set; }
        public int UserForeignKey { get; set; }
        public User User { get; set; }
        public IEnumerable<SkillsUser> SkillsUsers { get; set; }
    }
}
