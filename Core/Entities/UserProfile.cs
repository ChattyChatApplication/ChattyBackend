namespace Core.Entities;

public class UserProfile : BaseEntity
{
   #region columns

   

   #endregion

   #region relationship

   public Guid AccountId { get; init; }
   public UserAccount? Account { get; set; }
   
   #endregion
}