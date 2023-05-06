using App.Dtos.Requests;
using Core.ValueObjects.Account;
using Domain.Contracts.Database.Repositories;
using Domain.Services;

namespace App.Features;

public class SignUpFeat : ISignUpFeat
{
   private readonly IUserAccountFactory _userAccountFactory;
   private readonly IUserAccountRepository _userAccountRepository;
   private readonly IAuthTokenService _authTokenService;

   public SignUpFeat(IUserAccountFactory userAccountFactory, IUserAccountRepository userAccountRepository, IAuthTokenService authTokenService)
   {
      _userAccountFactory = userAccountFactory;
      _userAccountRepository = userAccountRepository;
      _authTokenService = authTokenService;
   }

   // TODO send email, verify OTP
   public async Task<AuthToken> Handle(SignUpRequestDto signUpRequest)
   {
      var username = new Username(signUpRequest.Username);
      var email = new Email(signUpRequest.Email);
      var password = new Password(signUpRequest.Password);

      var newAccount = await _userAccountFactory.CreateUserAccountAsync(username, email, password);
      await _userAccountRepository.InsertAsync(newAccount);

      return _authTokenService.CreateAuthToken(newAccount);
   }
}