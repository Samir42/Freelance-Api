using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;

namespace Freelancer.Services.ProposalService {
    public class ProposalService : IProposalService {
        private readonly IProposalRepository proposalRepository;

        public ProposalService(IProposalRepository proposalRepository) {
            this.proposalRepository = proposalRepository;
        }

        public async Task AddAsync(ProposalViewModel model) {
            await this.proposalRepository.AddAsync(new Request() {
                JobId = model.JobId,
                FreelancerId = model.FreelancerId,
                RequestDescription = model.RequestDescription,
                Offer = model.Offer,
                HowManyDay = model.HowManyDay
            });
        }

        public async Task<IEnumerable<Request>> GetProposalsByFreelancerIdAsync(int freelancerId) {
            return await this.proposalRepository.GetProposalsByFreelancerIdAsync(freelancerId);
        }

        public async Task<IEnumerable<Request>> GetProposalsByJobIdAsync(int jobId) {
            return await this.proposalRepository.GetProposalsByJobIdAsync(jobId);
        }

    }
}
