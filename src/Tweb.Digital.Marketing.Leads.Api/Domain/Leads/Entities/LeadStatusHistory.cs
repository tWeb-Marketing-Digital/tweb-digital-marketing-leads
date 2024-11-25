using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;

namespace Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities
{
    public class LeadStatusHistory
    {
        public Guid Id { get; private set; }
        public Lead Lead { get; private set; }
        public LeadStatus PreviousStatus { get; private set; }
        public LeadStatus CurrentStatus { get; private set; }
        public string Reason { get; private set; }
        public string UpdatedBy { get; private set; }
        public DateTime ChangedAt { get; private set; }

        public LeadStatusHistory(Lead lead, LeadStatus previousStatus, LeadStatus currentStatus, string reason, string updatedBy, DateTime changedAt)
        {
            Id = Guid.NewGuid();
            Lead = lead;
            PreviousStatus = previousStatus;
            CurrentStatus = currentStatus;
            Reason = reason;
            UpdatedBy = updatedBy;
            ChangedAt = changedAt;
        }
    }

}
