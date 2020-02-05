using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Freelancer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Freelancer.Services.UserService;

namespace Freelancer.Conrollers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;

        public AccountController(UserManager<User> userManager,
                                 SignInManager<User> signInManager,
                                 IUserService userService) {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            throw new NotImplementedException();
        }

        // GET: api/Account/email
        [Route("{email}")]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            return CreatedAtAction("GetUser", new { email = email}, new User());
        }

        // PUT: api/Account/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            return NoContent();
        }

        // POST: api/Account
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(MyUser user)
        {
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            return null;
        }

        private bool UserExists(int id)
        {
            return true;
        }
    }
}
