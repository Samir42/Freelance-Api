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
        public Client Client { get; set; }
        public Freelancer Freelancer { get; set; }

        public IEnumerable<JobsSkill> JobsSkills { get; set; }
        public IEnumerable<Request> Requests { get; set; }
    }
}
