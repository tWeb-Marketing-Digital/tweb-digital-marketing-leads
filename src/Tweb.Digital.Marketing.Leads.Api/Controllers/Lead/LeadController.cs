using Microsoft.AspNetCore.Mvc;
using Tweb.Digital.Marketing.Leads.Api.Application.Contract;
using Tweb.Digital.Marketing.Leads.Api.Controllers.Lead.Request;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Commands;

namespace Tweb.Digital.Marketing.Leads.Api.Controllers.Lead
{
    [ApiController]
    [Route("api/v1/leads")]
    [Produces("application/json")]
    public class LeadController : ControllerBase
    {
        private readonly ICreateLeadService _createLeadService;

        public LeadController(ICreateLeadService createLeadService)
        {
            ArgumentNullException.ThrowIfNull(createLeadService, nameof(createLeadService));
            _createLeadService = createLeadService;
        }


        /// <summary>
        /// Creates a new lead asynchronously.
        /// </summary>
        /// <param name="request">An object containing the details of the lead to be created.</param>
        /// <returns>Returns a CreatedAtAction result with the created lead's details.</returns>
        /// <response code="201">Lead created successfully. The location of the created lead is included in the response header.</response>
        /// <response code="400">Bad request. The data provided is invalid or missing required fields.</response>
        /// <response code="401">Unauthorized. The request is missing valid authentication credentials.</response>
        /// <response code="409">Conflict. A lead with the same data already exists.</response>
        /// <response code="500">Internal server error. Something went wrong while processing the request.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateLeadRequest request)
        {
            var command = CreateLeadCommand.Create()
                                           .WithName(request.Name)
                                           .WithEmail(request.Email)
                                           .WithPhone(request.Phone)
                                           .WithSource(request.Source)
                                           .WithChannel(request.Channel);

            return await _createLeadService.ProcessAsync(command);
        }
    }

}
