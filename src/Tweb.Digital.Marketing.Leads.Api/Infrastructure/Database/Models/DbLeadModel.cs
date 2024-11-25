using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models
{
    public class DbLeadModel
    {
        public Guid Id { get; set; }
        public DbPersonModel Person { get; set; }
        public string Source { get; set; }
        public string Channel { get; set; }
        public int Score { get; set; }
        public LeadStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ConvertedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public List<DbLeadStatusHistoryModel> LeadStatusHistoryModels { get; set; }
    }
}
