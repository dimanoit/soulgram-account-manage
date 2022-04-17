using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Persistence.Configurations;

public class HobbyImageConfiguration : IEntityTypeConfiguration<HobbyImage>
{
    public void Configure(EntityTypeBuilder<HobbyImage> builder)
    {
        builder.HasKey(hi => hi.Id);

        builder.HasOne(hi => hi.Hobby)
            .WithMany(hi => hi.HobbyImages)
            .HasForeignKey(hi => hi.HobbyId);
    }
}