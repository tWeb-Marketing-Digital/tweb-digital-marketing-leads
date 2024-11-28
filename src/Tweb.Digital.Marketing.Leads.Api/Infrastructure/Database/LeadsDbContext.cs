using Microsoft.EntityFrameworkCore;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Configuration;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database
{
    public class LeadsDbContext : DbContext
    {
        public DbSet<DbLeadModel> Lead { get; set; }     
        public DbSet<DbPersonModel> Person { get; set; }
        public LeadsDbContext(DbContextOptions<LeadsDbContext> options) : base (options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LeadModelConfiguration());         
            modelBuilder.ApplyConfiguration(new PersonModelConfiguration());            
        }
    }
}
