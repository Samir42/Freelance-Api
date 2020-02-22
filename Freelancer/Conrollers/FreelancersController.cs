using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Freelancer.DataAccess.EF;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Freelancer.Services.SkillService;
using Freelancer.Services.FreelancerService;
using Freelancer.Services.TokenService;
using Freelancer.Services.UserService;
using Microsoft.Extensions.Options;
using Freelancer.Services.ClientService;

namespace Freelancer.Conrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancersController : ControllerBase {
        private readonly FreelanceDbContext _context;
        private readonly ApplicationSettings appSettings;
        private readonly ISkillService skillService;
        private readonly IFreelancerService freelancerService;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IClientService clientService;

        public FreelancersController(ISkillService skillService, IFreelancerService freelancerService, ITokenService tokenService,IClientService clientService, IUserService userService, IOptions<ApplicationSettings> options) {
            this.skillService = skillService;
            this.freelancerService = freelancerService;
            this.tokenService = tokenService;
            this.userService = userService;
            this.appSettings = options.Value;
            this.clientService = clientService;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> PostFreelancer(FreelancerViewModel vm) {
            string res = User.Claims.First(x => x.Type == "UserId").Value;

            int id = int.Parse(res);

            vm.UserId = id;

            var freelancer = new Domain.Entities.Freelancer() { UserForeignKey = id, PayHourly = vm.PayHourly };
            await freelancerService.AddAsync(freelancer);
            await clientService.AddAsync(vm.CompanyName, id);

            var user = await userService.GetAsync(id);

            var token = await tokenService.GenerateToken(user, appSettings.JWT_Secret, vm.Password);

            //Update freelancerId and skillId of Skills
            var skillsUsers = vm.SkillUsers.Select(c => new SkillUser { FreelancerId = user.Freelancer.Id, SkillId = c.Skill.Id }).ToList();
            await skillService.AddRangeAsync(skillsUsers);

            if (token == "") return BadRequest();


            return Ok(new { token });
        }
    }
}
