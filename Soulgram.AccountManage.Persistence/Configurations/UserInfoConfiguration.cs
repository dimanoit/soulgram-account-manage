using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Persistence.Configurations;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.HasKey(ui => ui.UserId);

        builder.Property(ui => ui.Birthdate).IsRequired();
        builder.Property(ui => ui.Email).IsRequired();
        builder.Property(ui => ui.Nickname).IsRequired();
        builder.Property(ui => ui.Fullname).IsRequired();
    }
}