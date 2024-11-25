using Microsoft.AspNetCore.Mvc;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Commands;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories;

namespace Tweb.Digital.Marketing.Leads.Api.Controllers.Lead
{
    [ApiController]
    [Route("api/v1/leads")]
    [Produces("application/json")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadRepository _leadRepository;

        public LeadController(ILeadRepository leadRepository)
        {
            ArgumentNullException.ThrowIfNull(leadRepository, nameof(leadRepository));
            _leadRepository = leadRepository;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] LeadRequest request)
        {
            var command = CreateLeadCommand.Create()
                                           .WithName(request.Name)
                                           .WithEmail(request.Email)
                                           .WithPhone(request.Phone)
                                           .WithSource(request.Source)
                                           .WithChannel(request.Channel);
                                           
            var lead = new Domain.Leads.Entities.Lead(command);
            var entity = await _leadRepository.AddAsync(lead);


            return CreatedAtAction(nameof(GetByIdAsync), new { id = lead .Id}, new LeadResponse());

        }

        /// <summary>
        /// Retrieves the details of a lead by its unique identifier (ID).
        /// </summary>
        /// <param name="id">The unique identifier (ID) of the lead to be retrieved.</param>
        /// <returns>Returns the details of the requested lead. If the lead is not found, a 404 Not Found response is returned.</returns>
        /// <response code="200">Lead found successfully. The lead details are returned in the response body.</response>
        /// <response code="404">Lead not found. The lead with the specified ID does not exist in the system.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute]Guid id)
        {
            var entity = await _leadRepository.GetByIdAsync(id);

            return Ok(new  LeadResponse());
        }
    }

}
