using Microsoft.AspNetCore.Mvc;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Commands;

namespace Tweb.Digital.Marketing.Leads.Api.Application.Contract
{
    public interface ICreateLeadService
    {
        Task<IActionResult> ProcessAsync(CreateLeadCommand command);
    }
}
