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

            builder.HasKey(x => x.Id)
                   .HasName("PK_Lead_Id");

            builder.Property(x => x.Source)
                   .IsRequired()
                   .HasColumnType("varchar(30)");

            builder.Property(x => x.Channel)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasColumnType("varchar(15)");          

            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasColumnType("varchar(15)");

            builder.Property(x => x.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(x => x.UpdatedAt)                 
                   .HasColumnType("datetime");

            builder.Property(x => x.ClosedAt)                
                   .HasColumnType("datetime");

            builder.HasOne(x => x.Person)
                   .WithMany(p => p.Leads)
                   .HasForeignKey(l => l.PersonId)
                   .HasConstraintName("FK_Leads_PersonId");              
            
        }
    }
}
