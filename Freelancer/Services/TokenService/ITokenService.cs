using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Services.TokenService {
    public interface ITokenService {
        Task<string> GenerateToken(User user, string JWT_secret,string password);
    }
}
