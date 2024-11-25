using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Configuration
{
    public class PersonModelConfiguration : IEntityTypeConfiguration<DbPersonModel>
    {
        public void Configure(EntityTypeBuilder<DbPersonModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
