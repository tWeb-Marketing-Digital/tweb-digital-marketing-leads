using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Reposistories.Lead
{
    public class LeadRepository : ILeadRepository
    {
        public Task<Domain.Leads.Entities.Lead> AddAsync(Domain.Leads.Entities.Lead entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Domain.Leads.Entities.Lead entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Leads.Entities.Lead> GetAsync(Domain.Leads.Entities.Lead entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Leads.Entities.Lead> GetByIdAsync(Guid leadId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Domain.Leads.Entities.Lead entity)
        {
            throw new NotImplementedException();
        }
    }
}
