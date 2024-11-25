using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Commands;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;

namespace Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities
{
    public class Lead
    {
        public Guid Id { get; private set; }
        public Person Person { get; private set; }
        public string Source { get; private set; }
        public LeadChannel Channel { get; private set; }
        public int Score { get; private set; }
        public LeadStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ConvertedAt { get; private set; }
        public DateTime? ClosedAt { get; private set; }

        private readonly List<LeadStatusHistory> _statusHistory;
        public IReadOnlyCollection<LeadStatusHistory> StatusHistory => _statusHistory;

        public Lead(CreateLeadCommand command)
        {
            Id = Guid.NewGuid();
            //Person = person;
            Source = command.Source;
            Channel = command.Channel;
            Status = LeadStatus.NEW;
            CreatedAt = DateTime.UtcNow;
            _statusHistory = new List<LeadStatusHistory>();
        }      

        public void UpdateStatus(LeadStatus newStatus, string reason, string updatedBy)
        {
            _statusHistory.Add(new LeadStatusHistory(this, Status, newStatus, reason, updatedBy, DateTime.UtcNow));
            Status = newStatus;
        }
    }   

}
