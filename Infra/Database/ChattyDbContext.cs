using Core.Entities;
using Domain.Contracts.Database;
using Domain.Contracts.Database.Repositories;
using Infra.Database.EntityConfigs;
using Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database;

public class ChattyDbContext : DbContext, IChattyDbContext
{
   public DbSet<UserAccount> UserAccounts { get; set; } = null!;
   public DbSet<UserProfile> UserProfiles { get; set; } = null!;
   
   public ChattyDbContext(DbContextOptions options) : base(options)
   {
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserAccountConfig).Assembly);
   }

   public IUserAccountRepository UserAccountRepository()
   {
      return new UserAccountRepository(this);
   }

   public IUserProfileRepository UserProfileRepository()
   {
      return new UserProfileRepository(this);
   }
}