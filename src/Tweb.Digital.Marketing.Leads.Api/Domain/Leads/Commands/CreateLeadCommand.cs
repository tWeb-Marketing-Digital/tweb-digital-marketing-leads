using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;

namespace Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Commands
{
    public class CreateLeadCommand
    {
        public string Name => DomainComands.CREATE_LEAD_COMMAND;       
        public string PersonName { get; private set; }      
        public string Email { get; private set; }
        public string Phone { get; private set; }      
        public string Source { get; private set; }        
        public LeadChannel Channel { get; private set; }

        public static CreateLeadCommand Create()
            => new CreateLeadCommand();

        public CreateLeadCommand WithName(string name)
        {
            PersonName = name;
            return this;
        }

        public CreateLeadCommand WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CreateLeadCommand WithPhone(string phone)
        {
            Phone = phone;
            return this;
        }

        public CreateLeadCommand WithSource(string source)
        {
            Source = source;
            return this;
        }

        public CreateLeadCommand WithChannel(LeadChannel channel)
        {
            Channel = channel;
            return this;
        }
    }
}
