using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Models;

namespace Tweb.Digital.Marketing.Leads.Api.Infrastructure.Database.Configuration
{
    public class PersonModelConfiguration : IEntityTypeConfiguration<DbPersonModel>
    {
        public void Configure(EntityTypeBuilder<DbPersonModel> builder)
        {
            builder.ToTable("Persons");

            builder.HasKey(x => x.Id)
                    .HasName("PK_Person_Id");

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasColumnType("varchar(30)");

            builder.HasIndex(p => p.Email)
                   .IsUnique()
                   .HasDatabaseName("IX_Person_Email");

            builder.Property(x => x.Phone)
                   .IsRequired()               
                   .HasColumnType("varchar(30)");

            builder.Property(x => x.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(x => x.UpdatedAt)
                   .HasColumnType("datetime");      

        }
    }
}
