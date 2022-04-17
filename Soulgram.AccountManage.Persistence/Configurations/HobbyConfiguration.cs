using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Persistence.Configurations;

public class HobbyConfiguration : IEntityTypeConfiguration<Hobby>
{
    public void Configure(EntityTypeBuilder<Hobby> builder)
    {
        builder.HasKey(h => h.Id);

        builder
            .HasIndex(h => h.Name)
            .IsClustered(false)
            .IsUnique()
            .HasDatabaseName("UX_Hobby_Name");

        builder.Property(h => h.IsActive).IsRequired();
        builder.Property(h => h.Desription).IsRequired();
        builder.Property(h => h.IsGroupOnly).IsRequired();
    }
}