using Core.Entities;
using Core.ValueObjects.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.EntityConfigs;

public class UserAccountConfig : IEntityTypeConfiguration<UserAccount>
{
   public void Configure(EntityTypeBuilder<UserAccount> builder)
   {
      #region indexs

      builder
         .HasKey(uac => uac.Id);

      builder
         .HasIndex(uac => uac.Username)
         .IsUnique();
      
      builder
         .HasIndex(uac => uac.Email)
         .IsUnique();

      #endregion

      #region columns
      
      builder
         .Property(uac => uac.Username)
         .HasConversion(
            username => username.ToString(),
            value => new Username(value)
         )
         .HasColumnType("varchar(30)")
         // TODO limit min length to 2
         .IsRequired();

      builder
         .Property(uac => uac.Email)
         .HasConversion(
            email => email.ToString(),
            value => new Email(value)
         )
         .HasColumnType("varchar")
         .IsRequired();
      
      builder
         .Property(uac => uac.PasswordHash)
         .HasConversion(
            email => email.ToString(),
            value => new PasswordHash(value)
         )
         .HasColumnType("varchar")
         .IsRequired();

      #endregion

      #region auto generates

      builder
         .Property(ett => ett.Inserted)
         .HasColumnType("timestamp")
         .HasDefaultValueSql("CURRENT_TIMESTAMP")
         .ValueGeneratedOnAdd();
      
      builder
         .Property(ett => ett.Updated)
         .HasColumnType("timestamp")
         .HasDefaultValueSql("CURRENT_TIMESTAMP")
         .ValueGeneratedOnAddOrUpdate();

      #endregion
   }
}