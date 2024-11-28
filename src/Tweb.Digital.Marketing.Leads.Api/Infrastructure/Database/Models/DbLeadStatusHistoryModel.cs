using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models
{
    public class DbLeadStatusHistoryModel
    {
        public Guid Id { get; set; }
        public DbLeadModel Lead { get; set; }
        public LeadStatus PreviousStatus { get; set; }
        public LeadStatus CurrentStatus { get; set; }
        public string Reason { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
