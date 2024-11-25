using System.ComponentModel.DataAnnotations;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;

namespace Tweb.Digital.Marketing.Leads.Api.Controllers.Lead
{
    public class LeadRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public LeadChannel Channel { get; set; }      
    }
}
