using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Entities {
    public class Job {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int? FreelancerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public DateTime OpenedAt { get; set; }
        public virtual Client Client { get; set; }
        public virtual Freelancer Freelancer { get; set; }

        public virtual IEnumerable<JobsSkill> JobsSkills { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }
    }
}
