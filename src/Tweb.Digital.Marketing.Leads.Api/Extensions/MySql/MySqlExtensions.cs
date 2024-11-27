using Microsoft.EntityFrameworkCore;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database;

namespace Tweb.Digital.Marketing.Leads.Api.Extensions.MySql
{
    public static class MySqlExtensions
    {
        public static IServiceCollection GetConnectionStringMySql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeadsDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("MysqlConnection"), new MySqlServerVersion(new Version(8, 0, 32)));
            });

            return services;
        }
    }
}
