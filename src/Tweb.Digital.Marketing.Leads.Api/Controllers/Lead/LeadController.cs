#nullable enable
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
        private readonly ILeadQueryService _leadQueryService;

        public LeadController(ICreateLeadService createLeadService, ILeadQueryService leadQueryService)
        {
            ArgumentNullException.ThrowIfNull(createLeadService, nameof(createLeadService));
            _createLeadService = createLeadService;

            ArgumentNullException.ThrowIfNull(leadQueryService, nameof(leadQueryService));
            _leadQueryService = leadQueryService;
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
        /// <summary>
        /// Retrieves a paginated list of leads based on filters.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="pageSize">The number of leads per page.</param>
        /// <param name="status">The status filter for leads.</param>
        /// <param name="segment">The segment filter for leads.</param>
        /// <param name="sortBy">The field to sort the results by.</param>
        /// <param name="sortOrder">The sort order (asc/desc).</param>
        /// <returns>Returns a paginated list of leads.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLeadsAsync(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? status = null,
            [FromQuery] string? segment = null,
            [FromQuery] string? sortBy = "CreatedAt",
            [FromQuery] string? sortOrder = "asc")
        {
            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest("Page and pageSize must be greater than zero.");
            }

            var result = await _leadQueryService.GetLeadsAsync(page, pageSize, status, segment, sortBy, sortOrder);

            return Ok(new
            {
                Data = result.Leads,
                TotalCount = result.TotalCount,
                Page = page,
                PageSize = pageSize
            });
        }
    }

}
