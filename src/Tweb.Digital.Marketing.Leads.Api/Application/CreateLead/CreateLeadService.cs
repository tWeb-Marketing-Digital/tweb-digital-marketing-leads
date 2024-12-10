using Microsoft.AspNetCore.Mvc;
using Tweb.Digital.Marketing.Leads.Api.Application.Contract;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Commands;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Entities;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Repositories;

namespace Tweb.Digital.Marketing.Leads.Api.Application.CreateLead
{
    public class CreateLeadService : ICreateLeadService
    {
        private readonly IOutputPort _outputPort;
        private readonly ILeadRepository _leadRepository;
        private readonly IPersonRepository _personRepository;

        public CreateLeadService(IOutputPort outputPort, ILeadRepository leadRepository, IPersonRepository personRepository)
        {
            ArgumentNullException.ThrowIfNull(outputPort, nameof(outputPort));
            ArgumentNullException.ThrowIfNull(leadRepository, nameof(leadRepository));
            ArgumentNullException.ThrowIfNull(personRepository, nameof(personRepository));
            _outputPort = outputPort;
            _leadRepository = leadRepository;
            _personRepository = personRepository;
        }

        public async Task<IActionResult> ProcessAsync(CreateLeadCommand command)
        {
            var person = await _personRepository.GetPersonByEmailAsync(command.Email);

            if (person is null)
            {
                person = Person.Create(command.PersonName, command.Email, command.Phone);
                await _personRepository.AddAsync(person);
            }

            command.WithPersonId(person.Id);
            var lead = Lead.Create(command);

            await _leadRepository.AddAsync(lead);

            return _outputPort.Accepted(lead);
        }
    }
}
