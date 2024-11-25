using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Entities;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;

namespace Tweb.Digital.Marketing.Leads.Api.Controllers.Lead
{
    public class LeadResponse
    {       
        public Guid Id { get; set; }      
        public Person Person { get; set; }            
        public string Source { get; set; }       
        public string Channel { get; set; }
        public LeadStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
