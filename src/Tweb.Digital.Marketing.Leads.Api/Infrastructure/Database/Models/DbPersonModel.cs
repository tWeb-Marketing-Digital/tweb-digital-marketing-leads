using System.Net;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models
{
    public class DbPersonModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<DbLeadModel> Leads { get; set; }

        public static explicit operator DbPersonModel(Person entity)
        {
            if (entity == null) return null;

            return new DbPersonModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static explicit operator Person(DbPersonModel model)
        {
            if (model == null) return null;

            return new Person(
                model.Id,
                model.Name,
                model.Email,
                model.Phone,
                model.CreatedAt,
                model.UpdatedAt);
        }
    }
}
