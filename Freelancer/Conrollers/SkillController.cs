using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Domain.Entities;
using Freelancer.Services.SkillService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Freelancer.Conrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase {
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService) => this.skillService = skillService;

        // GET: api/Skill
        [HttpGet]
        public async Task<IActionResult> GetSkilssAsync() {
            var data = await skillService.GetSkillsAsync();

            if (data == null)
                return NotFound();
            else
                return Ok(data);
        }
    }
}
