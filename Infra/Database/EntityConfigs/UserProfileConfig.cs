using Core.Entities;
using Core.ValueObjects.Commons;
using Core.ValueObjects.UserProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.EntityConfigs;

public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
{
   public void Configure(EntityTypeBuilder<UserProfile> builder)
   {
      #region indexs

      builder
         .HasKey(prf => prf.Id);

      builder
         .HasIndex(prf => prf.AvatarUri)
         .IsUnique();

      builder
         .HasIndex(prf => prf.AccountId)
         .IsUnique();
      
      #endregion

      #region columns

      builder
         .Property(prf => prf.Fullname)
         .HasConversion(
            fullname => fullname.ToString(),
            value => (Name)value
         )
         .IsRequired();

      builder
         .Property(prf => prf.AvatarUri)
         .HasConversion(
            avatarUri => avatarUri.ToString(),
            value => (FilePath)value
         )
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