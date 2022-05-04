using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soulgram.AccountManage.Domain.Entities;

namespace Soulgram.AccountManage.Persistence.Configurations;

public class UserGenreConfiguration : IEntityTypeConfiguration<UserGenre>
{
    public void Configure(EntityTypeBuilder<UserGenre> builder)
    {
        builder.HasKey(pi => new {pi.GenreName, pi.UserId});
        builder.Property(pi => pi.CreationDate).IsRequired();

        builder
            .HasOne(bc => bc.Genre)
            .WithMany(b => b.UserGenres)
            .HasForeignKey(bc => bc.GenreName);

        builder
            .HasOne(bc => bc.User)
            .WithMany(b => b.UserGenres)
            .HasForeignKey(bc => bc.UserId);
    }
}