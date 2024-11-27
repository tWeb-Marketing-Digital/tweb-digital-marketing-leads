using FluentValidation;
using Tweb.Digital.Marketing.Leads.Api.Controllers.Lead.Request;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Enums;

namespace Tweb.Digital.Marketing.Leads.Api.Validators
{
    public class LeadRequestValidator : AbstractValidator<CreateLeadRequest>
    {
        public LeadRequestValidator() 
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Id is required.");
           
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters.")
                .MaximumLength(100).WithMessage("Name can be at most 100 characters.");
           
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");
            
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\+?\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$")
                .WithMessage("Phone must be a valid phone number.");

           
            RuleFor(x => x.Source)
                .NotEmpty().WithMessage("Source is required.")
                .MaximumLength(50).WithMessage("Source can be at most 50 characters.");
           
            RuleFor(x => x.Channel)
                .IsInEnum().WithMessage("Channel must be a valid LeadChannel.")
                .NotEqual(LeadChannel.NONE);

        }
    }
}
