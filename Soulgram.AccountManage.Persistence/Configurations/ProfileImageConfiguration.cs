using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Persistence.Configurations;

public class ProfileImageConfiguration : IEntityTypeConfiguration<ProfileImage>
{
    public void Configure(EntityTypeBuilder<ProfileImage> builder)
    {
        builder.HasKey(pi => pi.Id);

        builder.Property(pi => pi.CreationDate).IsRequired();

        builder.HasOne(pi => pi.UserInfo)
            .WithMany(ui => ui.ProfileImages)
            .HasForeignKey(pi => pi.UserId);
    }
}