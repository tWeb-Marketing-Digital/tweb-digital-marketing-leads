using Tweb.Digital.Marketing.Leads.Api.Application.Contract;
using Tweb.Digital.Marketing.Leads.Api.Application.CreateLead;
using Tweb.Digital.Marketing.Leads.Api.Application.QueryLead;
using Tweb.Digital.Marketing.Leads.Api.Controllers.Lead;
using Tweb.Digital.Marketing.Leads.Api.Domain.Leads.Repositories;
using Tweb.Digital.Marketing.Leads.Api.Domain.Persons.Repositories;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Reposistories;

namespace Tweb.Digital.Marketing.Leads.Api.Extensions.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateLeadService, CreateLeadService>();
            services.AddScoped<ILeadQueryService, LeadQueryService>();
            services.AddScoped<IOutputPort, LeadPresenter>();
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<LeadsDbContext>();

            return services;
        }
    }
}

