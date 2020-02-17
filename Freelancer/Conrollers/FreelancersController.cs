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

namespace Freelancer.Conrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancersController : ControllerBase
    {
        private readonly FreelanceDbContext _context;

        public FreelancersController(FreelanceDbContext context)
        {
            _context = context;
        }

        // GET: api/Freelancers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Entities.Freelancer>>> GetFreelancers() {
            return await _context.Freelancers.ToListAsync();
        }

        // GET: api/Freelancers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Entities.Freelancer>> GetFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);

            if (freelancer == null)
            {
                return NotFound();
            }

            return freelancer;
        }

        // PUT: api/Freelancers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFreelancer(int id, Domain.Entities.Freelancer freelancer)
        {
            if (id != freelancer.Id)
            {
                return BadRequest();
            }

            _context.Entry(freelancer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreelancerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Freelancers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult> PostFreelancer(FreelancerViewModel vm)
        {
            return null;
        }

        // DELETE: api/Freelancers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Domain.Entities.Freelancer>> DeleteFreelancer(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null)
            {
                return NotFound();
            }

            _context.Freelancers.Remove(freelancer);
            await _context.SaveChangesAsync();

            return freelancer;
        }

        private bool FreelancerExists(int id)
        {
            return _context.Freelancers.Any(e => e.Id == id);
        }
    }
}
