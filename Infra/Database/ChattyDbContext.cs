using Core.Entities;
using Infra.Database.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database;

public class ChattyDbContext : DbContext
{
   public DbSet<UserAccount> UserAccounts { get; set; } = null!;
   
   public ChattyDbContext(DbContextOptions options) : base(options)
   {
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserAccountConfig).Assembly);
   }
}