using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Freelancer.Services.ProposalService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Conrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ControllerBase {
        private readonly IProposalService proposalService;

        public ProposalsController(IProposalService proposalService) {
            this.proposalService = proposalService;
        }
        // GET: api/Proposals/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestsByIdAsync(int id) {
            var data = await this.proposalService.GetProposalsByJobIdAsync(id);

            if (data == null)
                return BadRequest($"No Proposal found for {id}");

            return Ok(data);

            //return data == null ? BadRequest($"No Proposal found for {id}") : Ok(data);
        }

       

        // POST: api/Proposals
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAsync(ProposalViewModel model) {
            string res = User.Claims.First(x => x.Type == "FreelancerId").Value;

            int freelancerId = int.Parse(res);

            model.FreelancerId = freelancerId;

            await proposalService.AddAsync(model);

            return Ok();
        }

        [Authorize]
        [HttpGet("{jobId}/exists")]
        public async Task<bool> Exists(int jobId) {
            string res = User.Claims.First(x => x.Type == "FreelancerId").Value;

            int freelancerId = int.Parse(res);

            var data = await this.proposalService.GetProposalsByJobIdAsync(jobId);

            var exists = data.FirstOrDefault(x => x.FreelancerId == freelancerId) != null;

            return exists;
        }
    }
}
