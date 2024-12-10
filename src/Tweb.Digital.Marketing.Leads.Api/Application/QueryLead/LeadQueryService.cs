#nullable enable
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Tweb.Digital.Marketing.Leads.Api.Application.Contract;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories;

namespace Tweb.Digital.Marketing.Leads.Api.Application.QueryLead
{
    public class LeadQueryService : ILeadQueryService
    {
        private readonly IOutputPort _outputPort;
        private readonly ILeadRepository _leadRepository;

        public LeadQueryService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<(List<Lead> Leads, int TotalCount)> GetLeadsAsync(
            int page,
            int pageSize,
            string? status = null,
            string? segment = null,
            string? sortBy = "CreatedAt",
            string? sortOrder = "asc")
        {
            // Validação dos parâmetros
            if (page <= 0)
                throw new ArgumentException("Page must be greater than zero.", nameof(page));

            if (pageSize <= 0)
                throw new ArgumentException("PageSize must be greater than zero.", nameof(pageSize));

            // Chama o repositório para buscar os dados
            var result = await _leadRepository.GetPaginatedLeadsAsync(
                page,
                pageSize,
                status,
                segment,
                sortBy,
                sortOrder
            );

            // Retorna um json com a lista de resultados
            return result;
        }
    }
}
