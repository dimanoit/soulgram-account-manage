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
    public DbSet<MateRequest> MateRequests { get; set; }
    public DbSet<UserMate> UserMates { get; set; }

    public DbSet<ProfileImage> ProfileImages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ProfileImageConfiguration());
        builder.ApplyConfiguration(new UserInfoConfiguration());
        builder.ApplyConfiguration(new MateRequestConfiguration());
        builder.ApplyConfiguration(new UserMateConfiguration());
    }
}