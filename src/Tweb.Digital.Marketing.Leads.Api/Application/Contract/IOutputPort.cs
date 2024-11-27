using Microsoft.AspNetCore.Mvc;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Application.Contract
{
    public interface IOutputPort
    {
        IActionResult Accepted(Lead entity);
        IActionResult UnprocessableEntity();
        IActionResult NotFound();
    }
}
