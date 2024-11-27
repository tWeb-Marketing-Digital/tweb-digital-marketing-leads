using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories
{
    public interface ILeadRepository
    {
        Task AddAsync(Lead entity);
        Task Update(Lead entity);
        Task<List<Lead>> GetAllAsync();
        Task<Lead> GetByIdAsync(Guid leadId);

    }
}
