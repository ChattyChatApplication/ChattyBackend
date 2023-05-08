using Core.ValueObjects.Account;

namespace Core.Entities;

public class UserAccount : BaseEntity
{
   public UserAccount(Username username, Email email, PasswordHash passwordHash)
   {
      Username = username;
      Email = email;
      PasswordHash = passwordHash;
   }

   #region columns

   public Username Username { get; init; }
   
   public Email Email { get; init; }

   public PasswordHash PasswordHash { get; set; }

   #endregion

   #region relationships

   public UserProfile? Profile { get; set; }

   #endregion
}