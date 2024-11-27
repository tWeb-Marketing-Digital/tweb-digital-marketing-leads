using Microsoft.EntityFrameworkCore;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Entities;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Repositories;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Reposistories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly LeadsDbContext _context;

        public PersonRepository(LeadsDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            _context = context;
        }
        public async Task AddAsync(Person entity)
        {
            var dbModel = (DbPersonModel)entity;
            await _context.Person.AddAsync(dbModel);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetPersonByEmailAsync(string email)
        {
            var dbModel = await _context.Person.Where(w => w.Email == email).ToListAsync();

            return (Person)dbModel.FirstOrDefault();
        }
    }
}
