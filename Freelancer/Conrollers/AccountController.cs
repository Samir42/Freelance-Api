using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Freelancer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Freelancer.Services.UserService;
using Microsoft.Extensions.Options;
using Freelancer.Domain.Models;
using Freelancer.Services.TokenService;

namespace Freelancer.Conrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly ApplicationSettings appSettings;

        public AccountController(UserManager<User> userManager,
                                 SignInManager<User> signInManager,
                                 IUserService userService,
                                 ITokenService tokenService,
                                 IOptions<ApplicationSettings> options) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.appSettings = options.Value;
            this.tokenService = tokenService;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
            throw new NotImplementedException();
        }

        // GET: api/Account/email
        [Route("{email}")]
        public async Task<ActionResult<User>> GetUser(string email) {
            return CreatedAtAction("GetUser", new { email = email }, new User());
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserViewModel vm) {
            var res = await userService.GetUserByEmailAsync(vm.Email);

            var token = await this.tokenService.GenerateToken(res, appSettings.JWT_Secret, vm.Password);

            if (token != "")
                return Ok(new { token });

            return BadRequest("Username or password is incorrect");
        }


        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(UserViewModel model) {
            var result = await userService.SignUpAsync(model);

            //Take user to get Token
            if (result.Succeeded) {
                var user = await userService.GetUserByEmailAsync(model.Email);


                var token = await tokenService.GenerateToken(user, appSettings.JWT_Secret, model.Password);

                if (token == "") return BadRequest();

                return Ok(new { token });
            }


            return BadRequest(result.Errors);
        }
        // PUT: api/Account/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user) {
            return NoContent();
        }

        // POST: api/Account
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserViewModel user) {
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id) {
            return null;
        }

        private bool UserExists(int id) {
            return true;
        }
    }
}
