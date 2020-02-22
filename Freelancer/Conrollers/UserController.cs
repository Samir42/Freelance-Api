using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Freelancer.DataAccess.EF;
using Freelancer.Domain.Entities;
using Freelancer.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Freelancer.Services.JobService;
using Freelancer.Services.ProposalService;

namespace Freelancer.Conrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IUserService userService;
        private readonly IJobService jobService;
        private readonly IProposalService proposalService;

        private FreelanceDbContext _context;

        public UserController(IUserService userService, IJobService jobService, IProposalService proposalService) {
            this.userService = userService;
            this.jobService = this.jobService = jobService;
            this.proposalService = proposalService;
        }


        [HttpGet("Freelancer")]
        public async Task<ActionResult<IEnumerable<User>>> GetFreelancers() {
            return await userService.GetFreelancersAsync() as List<User>;
        }
        [HttpGet("Client")]
        public async Task<ActionResult<IEnumerable<User>>> GetClients() {
            return await userService.GetClientsAsync() as List<User>;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> GetUser() {
            string id = User.Claims.First(x => x.Type == "UserId").Value;

            var res = int.Parse(id);

            var user = await this.userService.GetAsync(res);

            return user == null ? NotFound() : new ActionResult<User>(user);
        }

        [Authorize]
        [HttpGet("jobs")]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs() {
            string res = User.Claims.First(x => x.Type == "ClientId").Value;

            int clientId = int.Parse(res);

            var jobs = await this.jobService.GetAllAsync(clientId);

            if (jobs == null) return NotFound();

            return Ok(jobs);
        }

        [Authorize]
        [HttpGet("proposals")]
        public async Task<ActionResult<IEnumerable<Request>>> GetProposals() {
            string res = User.Claims.First(x => x.Type == "FreelancerId").Value;

            int freelancerId = int.Parse(res);

            var proposals = await proposalService.GetProposalsByFreelancerIdAsync(freelancerId);

            if (proposalService == null) return NotFound("No proposals found");

            return Ok(proposals);
        }
    }
}
