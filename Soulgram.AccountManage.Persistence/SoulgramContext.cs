using Microsoft.EntityFrameworkCore;
using Soulgram.AccountManage.Domain.Entities;
using Soulgram.AccountManage.Persistence.Configurations;

namespace Soulgram.AccountManage.Persistence;

public sealed class SoulgramContext : DbContext
{
    public SoulgramContext(DbContextOptions<SoulgramContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
    public DbSet<UserHobby> UserHobbies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserInfoConfiguration());
        builder.ApplyConfiguration(new HobbyConfiguration());
        builder.ApplyConfiguration(new UserHobbyConfiguration());
    }
}