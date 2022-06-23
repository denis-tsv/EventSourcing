using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Web.Entities;

namespace Shop.Web.DataAccess.Postgres.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(128);
    }
}