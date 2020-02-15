using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Domain.Entities;
using Freelancer.Services.SkillService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Conrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService) => this.skillService = skillService;
        // GET: api/Skill
        [HttpGet]
        public async Task<IActionResult> GetSkilssAsync()
        {
            var data = await skillService.GetSkillsAsync();

            if (data == null)
                return NotFound();
            else
                return Ok(data);
        }

        // GET: api/Skill/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Skill
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Skill/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
