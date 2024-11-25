using FluentValidation;
using FluentValidation.AspNetCore;
using Tweb.Digital.Marketing.Leads.Api.Validators;

namespace Tweb.Digital.Marketing.Leads.Api.Extensions.Swagger
{
    public static class SwaggerFluentValidationExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            ValidatorOptions.Global.LanguageManager.Enabled = false;
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<LeadRequestValidator>();
        
            return services;
        }
    }
}
