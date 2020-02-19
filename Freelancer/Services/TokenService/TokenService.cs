using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Freelancer.Services.TokenService {
    public class TokenService : ITokenService {
        private readonly UserManager<User> userManager;

        public TokenService(UserManager<User> userManager) => this.userManager = userManager;


        public async Task<string> GenerateToken(User user, string JWT_secret,string password) {
            string freelancerIdzero = "0";
            string clientIdzero = "0";
            if (user != null && await userManager.CheckPasswordAsync(user, password)) {
                var tokenDescriptor = new SecurityTokenDescriptor() {
                    Subject = new ClaimsIdentity(new Claim[] {

                        new Claim("UserId", user.Id.ToString()),
                        new Claim("FreelancerId",user.Freelancer == null ? freelancerIdzero : user.Freelancer.Id.ToString()),
                        new Claim("ClientId",user.Client == null ? clientIdzero : user.Client.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT_secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return token;
            }

            return "";
        }
    }
}
