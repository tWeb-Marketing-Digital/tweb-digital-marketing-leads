#nullable enable
using Microsoft.EntityFrameworkCore;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;
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

            return dbModel.Select(s => (Lead)s).ToList();
        }

        public async Task<Lead> GetByIdAsync(Guid leadId)
        {
            var dbModel = await _context.Lead.Where(w => w.Id == leadId).ToListAsync();

            return (Lead)dbModel.FirstOrDefault();
        }

        public async Task<(List<Lead> Leads, int TotalCount)> GetPaginatedLeadsAsync(
            int page,
            int pageSize,
            string? status = null,
            string? segment = null,
            string? sortBy = "createdAt",
            string? sortOrder = "asc")
        {
            var query = _context.Lead.AsQueryable();

            // Filtra os leads com base nos parâmetros
            if (!string.IsNullOrEmpty(status) && Enum.TryParse<LeadStatus>(status, out var leadStatus))
            {
                query = query.Where(l => l.Status == leadStatus);
            }

            if (!string.IsNullOrEmpty(segment))
            {
                query = query.Where(l => l.Source == segment);
            }

            // Ordenação
            query = sortOrder?.ToLower() == "desc"
                ? query.OrderByDescending(e => EF.Property<object>(e, sortBy ?? "createdAt"))
                : query.OrderBy(e => EF.Property<object>(e, sortBy ?? "createdAt"));

            // Total de registros antes da paginação
            var totalCount = await query.CountAsync();

            // Paginação
            var dbLeads = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var leads = dbLeads.Select(dbLead => (Lead)dbLead).ToList();

            return (leads, totalCount);
        }

        public async Task Update(Lead entity)
        {
            var dbModel = (DbLeadModel)entity;
            _context.Lead.Update(dbModel);
            await _context.SaveChangesAsync();
        }
    }
}
