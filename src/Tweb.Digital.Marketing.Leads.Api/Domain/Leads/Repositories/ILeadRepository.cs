﻿#nullable enable

using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories
{
    public interface ILeadRepository
    {
        Task AddAsync(Lead entity);
        Task Update(Lead entity);
        Task<List<Lead>> GetAllAsync();
        Task<Lead> GetByIdAsync(Guid leadId);

        /// <summary>
        /// Retrieves a paginated list of leads based on the provided filters.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="pageSize">The number of leads per page.</param>
        /// <param name="status">The status filter for leads (optional).</param>
        /// <param name="segment">The segment filter for leads (optional).</param>
        /// <param name="sortBy">The field to sort the results by (default: CreatedAt).</param>
        /// <param name="sortOrder">The sort order (asc/desc, default: asc).</param>
        /// <returns>A paginated result containing the leads and the total count.</returns>
        Task<(List<Lead> Leads, int TotalCount)> GetPaginatedLeadsAsync(
            int page,
            int pageSize,

            string? status = null,
            string? segment = null,
            string? sortBy = "CreatedAt",
            string? sortOrder = "asc");
    }
}
