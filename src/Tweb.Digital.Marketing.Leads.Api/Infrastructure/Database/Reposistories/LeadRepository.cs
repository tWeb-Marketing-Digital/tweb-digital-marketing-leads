using Microsoft.EntityFrameworkCore;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Reposistories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly LeadsDbContext _context;

        public LeadRepository(LeadsDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            _context = context;
        }

        public async Task AddAsync(Lead entity)
        {
            var dbModel = (DbLeadModel)entity;
            await _context.Lead.AddAsync(dbModel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Lead>> GetAllAsync()
        {           
            var dbModel = await _context.Lead.ToListAsync();

            return dbModel.Select(s=> (Lead)s).ToList();
        }

        public async Task<Lead> GetByIdAsync(Guid leadId)
        {
            var dbModel = await _context.Lead.Where(w=> w.Id == leadId).ToListAsync();

            return (Lead)dbModel.FirstOrDefault();
        }

        public async Task Update(Lead entity)
        {
            var dbModel = (DbLeadModel)entity;
            _context.Lead.Update(dbModel);
            await _context.SaveChangesAsync();
        }
    }
}
