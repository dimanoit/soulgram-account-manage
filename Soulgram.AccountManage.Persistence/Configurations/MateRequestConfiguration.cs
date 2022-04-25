using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Persistence.Configurations;

internal class MateRequestConfiguration : IEntityTypeConfiguration<MateRequest>
{
    public void Configure(EntityTypeBuilder<MateRequest> builder)
    {
        builder.HasKey(mr => new { mr.RecipientId, mr.SenderId });

        builder
            .Property(mr => mr.Status)
            .HasConversion<int>()
            .IsRequired();
        
        builder.Property(mr => mr.CreationDate).IsRequired();

    }
}
