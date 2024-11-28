using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models
{
    public class DbLeadModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public DbPersonModel Person { get; set; }
        public string Source { get; set; }
        public LeadChannel Channel { get; set; }

        public int? Score { get; set; }
        public LeadStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }       

        public static explicit operator DbLeadModel(Lead entity)
        {
            if (entity == null) return null;

            return new DbLeadModel()
            {
                Id = entity.Id,
                PersonId = entity.PersonId,
                Source = entity.Source,
                Channel = entity.Channel,
                Score = entity.Score,
                Status = entity.Status,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                ClosedAt = entity.ClosedAt
            };
        }

        public static explicit operator Lead(DbLeadModel model)
        {
            if (model == null) return null;

            return new Lead(
                model.Id,
                (Person)model.Person,
                model.Source,
                model.Channel,
                model.Score,
                model.Status,
                model.CreatedAt,
                model.UpdatedAt,
                model.ClosedAt);
        }
    }
}
