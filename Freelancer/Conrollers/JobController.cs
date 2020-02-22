using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Freelancer.DataAccess.EF;
using Freelancer.Domain.Entities;
using Freelancer.Services.JobService;
using Microsoft.AspNetCore.Authorization;
using Freelancer.Domain.Models;
using Freelancer.Services.SkillService;

namespace Freelancer.Conrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;
        private readonly ISkillService skillService;

        public JobController(FreelanceDbContext context , IJobService jobService,ISkillService skillService)
        {
            this.jobService = jobService;
            this.skillService = skillService;
        }

        // GET: api/Job
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            return await jobService.GetAllAsync() as List<Job>;
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var data = await jobService.GetJobById(id);

            return data == null ? NotFound() : new ActionResult<Job>(data);
        }

        [HttpGet("{id}/Requests")]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests(int id) {
            
            return await jobService.GetRequestsAsync(id) as List<Request>;
        }

        
        // POST: api/Job
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(JobViewModel vm)
        {
            var cid = User.Claims.First(x => x.Type == "ClientId").Value;

            vm.ClientId = int.Parse(cid);

            var jobId = await this.jobService.PostJobAsync(vm);

            var jobsSkills = vm.JobsSkills.Select(c => new JobsSkill() { JobId = jobId, SkillId = c.Skill.Id }).ToList();

            await this.skillService.AddRangeAsync(jobsSkills);

            return Ok();
        }

        [Authorize]
        [HttpGet("done")]
        public async Task<ActionResult<IEnumerable<Job>>> GetDoneProjects() {
            string id = User.Claims.First(x => x.Type == "FreelancerId").Value;

            int freelancerId = int.Parse(id);

            var doneProjects = await jobService.GetDoneProjectsByFreelancerIdAsync(freelancerId);

            if (doneProjects == null) return NotFound("No done project found");

            return Ok(doneProjects);
        }
       
        // I know it's not good approaching but i will corrected my wrongs. It's my first api

        [Authorize]
        [HttpPost("update")]
        public async Task<ActionResult> UpdateJobAsync(JobViewModel vm) {
            await this.jobService.UpdateJobAsync(vm);

            return Ok();
        }

    }
}
