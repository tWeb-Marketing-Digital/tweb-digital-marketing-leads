using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Commands;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities
{
    public class Lead
    {
        public Guid Id { get; private set; }

        public Guid PersonId { get; private set; }
        public Person Person { get; private set; }
        public string Source { get; private set; }
        public LeadChannel Channel { get; private set; }
        public int? Score { get; private set; }
        public LeadStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }

        private readonly List<LeadStatusHistory> _statusHistory;
        public IReadOnlyCollection<LeadStatusHistory> StatusHistory => _statusHistory;
        private Lead() { }

        public Lead(Guid id, Person person, string source, LeadChannel channel, int? score, LeadStatus status, DateTime createdAt, DateTime? updatedAt, DateTime? closedAt)
        {
            Id = id;
            Person = person;
            Source = source;
            Channel = channel;
            Score = score;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ClosedAt = closedAt;
        }

        public static Lead Create(CreateLeadCommand command)
        {
            return new Lead
            {
                Id = Guid.NewGuid(),
                PersonId = command.PersonId,
                Source = command.Source,                
                Status = LeadStatus.NEW,
                CreatedAt = DateTime.Now
            };
        }

        public void UpdateStatus(LeadStatus newStatus, string reason, string updatedBy)
        {
            _statusHistory.Add(new LeadStatusHistory(this, Status, newStatus, reason, updatedBy, DateTime.UtcNow));
            Status = newStatus;
        }
    }

}
