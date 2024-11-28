using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Repositories
{
    public interface IPersonRepository
    {
        Task AddAsync(Person entity);
        Task<Person> GetPersonByEmailAsync(string email);
    }
}
