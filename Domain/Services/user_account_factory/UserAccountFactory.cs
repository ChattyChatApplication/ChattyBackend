using Core.Entities;
using Core.ValueObjects.Account;
using Core.ValueObjects.Commons;
using Domain.Contracts.Database;
using Domain.Contracts.Database.Repositories;
using Domain.Exceptions;

namespace Domain.Services;

public class UserAccountFactory : IUserAccountFactory
{
   private readonly IUserAccountRepository _userAccountRepository;
   private readonly IPasswordHashService _passwordHashService;

   public UserAccountFactory(IPasswordHashService passwordHashService, IChattyDbContext chattyDbContext)
   {
      _userAccountRepository = chattyDbContext.UserAccountRepository();
      _passwordHashService = passwordHashService;
   }

   public async Task<UserAccount> CreateUserAccountAsync(Username username, Email email, Password password)
   {
      if (await _userAccountRepository.IsEmailExistAsync(email))
      {
         throw new DuplicatedEmailException(email);
      }

      if (await _userAccountRepository.IsUsernameExistAsync(username))
      {
         throw new DuplicatedUsernameException(username);
      }

      var passwordHash = _passwordHashService.Hash(password);
      
      return new UserAccount(username, email, passwordHash);
   }
}