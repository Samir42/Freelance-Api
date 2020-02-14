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

        // GET: api/Proposals/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Proposals
        [Authorize]
        [HttpPost]
        public IActionResult Post(ProposalViewModel model) {
            //Take freelancerId if it does not exist within model. 
            if (model.FreelancerId == 0) {

                //Find freelancer 
                var id = User.Claims.First(x => x.Type == "FreelancerId").Value;

                //If does not exists Register the User

                //try {
                //    freelancerId = int.Parse(id);
                //    model.FreelancerId = freelancerId;
                //}
                //finally { }
            }

            proposalService.AddAsync(model);

            return CreatedAtAction("Post", new { id = model.JobId }, model);
        }

        // PUT: api/Proposals/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
