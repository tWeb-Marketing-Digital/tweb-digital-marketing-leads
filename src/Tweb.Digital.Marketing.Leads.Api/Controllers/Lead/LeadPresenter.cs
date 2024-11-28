using System.Net;
using Microsoft.AspNetCore.Mvc;
using Tweb.Digital.Marketing.Leads.Api.Application.Contract;
using Tweb.Digital.Marketing.Leads.Api.Controllers.Lead.Response;

namespace Tweb.Digital.Marketing.Leads.Api.Controllers.Lead
{
    public class LeadPresenter : IOutputPort
    {
        public IActionResult Accepted(Domain.Leads.Entities.Lead entity)
            => new AcceptedResult(string.Empty, new CreateLeadResponse());        

        public IActionResult NotFound()
            => new NotFoundResult();        

        public IActionResult UnprocessableEntity()
            => new ObjectResult("") { StatusCode = (int)HttpStatusCode.UnprocessableEntity};        
    }
}
