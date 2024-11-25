using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Configuration
{
    public class LeadModelConfiguration : IEntityTypeConfiguration<DbLeadModel>
    {
        public void Configure(EntityTypeBuilder<DbLeadModel> builder)
        {
            builder.ToTable("Leads");
        }
    }
}
