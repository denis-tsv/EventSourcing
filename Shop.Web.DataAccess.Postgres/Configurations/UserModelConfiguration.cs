using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Models;
using Shop.Web.Entities;

namespace Shop.Web.DataAccess.Postgres.Configurations;

public class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(128);
    }
}