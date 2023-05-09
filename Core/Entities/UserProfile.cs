using Core.ValueObjects.Commons;
using Core.ValueObjects.UserProfile;

namespace Core.Entities;

public class UserProfile : BaseEntity
{
   public UserProfile(Guid accountId, Name fullname, FilePath avatarUri)
   {
      AccountId = accountId;
      Fullname = fullname;
      AvatarUri = avatarUri;
   }

   public UserProfile(Name fullname, FilePath avatarUri)
   {
      Fullname = fullname;
      AvatarUri = avatarUri;
   }

   #region columns

   public Name Fullname { get; set; }

   public FilePath AvatarUri { get; set; }

   #endregion

   #region relationship

   public Guid AccountId { get; init; }
   public UserAccount? Account { get; set; }
   
   #endregion
}