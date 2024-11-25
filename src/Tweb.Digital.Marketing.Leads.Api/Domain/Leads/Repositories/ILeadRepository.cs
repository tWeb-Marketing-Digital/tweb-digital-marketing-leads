using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories
{
    public interface ILeadRepository
    {
        Task<Lead> AddAsync(Lead entity);
        Task UpdateAsync(Lead entity);
        Task DeleteAsync(Lead entity);  
        Task<Lead> GetAsync(Lead entity);
        Task<Lead> GetByIdAsync(Guid leadId);

    }
}
