using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Persistence.Configurations;

public class UserHobbyConfiguration : IEntityTypeConfiguration<UserHobby>
{
    public void Configure(EntityTypeBuilder<UserHobby> builder)
    {
        builder.HasKey(uh => new {uh.HobbieId, uh.UserId});

        builder.Property(uh => uh.CreationDate)
            .IsRequired();

        builder.HasOne(uh => uh.Hobby)
            .WithMany(uh => uh.UserHobbies)
            .HasForeignKey(uh => uh.HobbieId);

        builder.HasOne(uh => uh.UserInfo)
            .WithMany(uh => uh.UserHobbies)
            .HasForeignKey(uh => uh.UserId);
    }
}