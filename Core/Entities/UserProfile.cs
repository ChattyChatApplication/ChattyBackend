using Core.ValueObjects.UserProfile;
using Path = Core.ValueObjects.Commons.Path;

namespace Core.Entities;

public class UserProfile : BaseEntity
{
   public UserProfile(Name fullname, Path avatarUri, Guid accountId)
   {
      Fullname = fullname;
      AvatarUri = avatarUri;
      AccountId = accountId;
   }

   public UserProfile(Name fullname, Path avatarUri)
   {
      Fullname = fullname;
      AvatarUri = avatarUri;
   }

   #region columns

   public Name Fullname { get; set; }

   public Path AvatarUri { get; set; }

   #endregion

   #region relationship

   public Guid AccountId { get; init; }
   public UserAccount? Account { get; set; }
   
   #endregion
}