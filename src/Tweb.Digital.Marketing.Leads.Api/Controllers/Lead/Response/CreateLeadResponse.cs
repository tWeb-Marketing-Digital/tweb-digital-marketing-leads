using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Entities;

namespace Tweb.Digital.Marketing.Leads.Api.Controllers.Lead.Response
{
    public class CreateLeadResponse
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public string Source { get; set; }
        public string Channel { get; set; }
        public LeadStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
