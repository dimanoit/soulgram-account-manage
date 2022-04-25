using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Persistence.Configurations;

internal class UserMateConfiguration : IEntityTypeConfiguration<UserMate>
{
    public void Configure(EntityTypeBuilder<UserMate> builder)
    {
        builder.HasKey(um => new { um.UserId, um.MateId });

        builder.Property(um => um.CreationDate).IsRequired();
    }
}