using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Freelancer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Freelancer.Services.UserService;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Freelancer.Domain.Models;
using Freelancer.ViewModels;

namespace Freelancer.Conrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;
        private readonly ApplicationSettings appSettings;

        public AccountController(UserManager<User> userManager,
                                 SignInManager<User> signInManager,
                                 IUserService userService,
                                 IOptions<ApplicationSettings> options) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.appSettings = options.Value;
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
        public async Task<IActionResult> Login(MyUser user) {
            //This means freelancer is null and i will check at other side that id null or not 
            string freelancerIdzero = "0";
            var res = await userService.GetUserByEmailAsync(user.Email);

            if (user != null && await userManager.CheckPasswordAsync(res, user.Password)){
                var tokenDescriptor = new SecurityTokenDescriptor() {
                    Subject = new ClaimsIdentity(new Claim[] {

                        new Claim("UserId", res.Id.ToString()),
                        new Claim("FreelancerId",res.Freelancer == null ? freelancerIdzero : res.Freelancer.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest("Username or password is incorrect");
        }


        [HttpPost]
        [Route("signup")]
        public async Task<User> SignUp(UserViewModel model) {
            return await this.userService.SignUp(model);
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
        public async Task<ActionResult<User>> PostUser(MyUser user) {
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
