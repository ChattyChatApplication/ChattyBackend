using Core.ValueObjects.Account;
using Core.ValueObjects.Commons;
using Domain.Contracts.Database.Repositories;
using Domain.Services;
using FluentValidation;

namespace App.Features;

public interface ISignUpFeat
{
   public Task<AuthToken> HandleAsync(SignUpRequestDto signUpRequest);
}

public class SignUpFeat : ISignUpFeat
{
   private readonly IUserAccountFactory _userAccountFactory;
   private readonly IUserAccountRepository _userAccountRepository;
   private readonly IAuthTokenService _authTokenService;
   private readonly IValidator<SignUpRequestDto> _validator;

   public SignUpFeat(
      IUserAccountFactory userAccountFactory, 
      IUserAccountRepository userAccountRepository, 
      IAuthTokenService authTokenService, 
      IValidator<SignUpRequestDto> validator)
   {
      _userAccountFactory = userAccountFactory;
      _userAccountRepository = userAccountRepository;
      _authTokenService = authTokenService;
      _validator = validator;
   }

   public async Task<AuthToken> HandleAsync(SignUpRequestDto signUpRequest)
   {
      var validateResult = await _validator.ValidateAsync(signUpRequest);
      if (!validateResult.IsValid) throw new ValidationException(validateResult.Errors);
      
      var newAccount = await _userAccountFactory.CreateUserAccountAsync(
         (Username)signUpRequest.Username,
         (Email)signUpRequest.Email, 
         (Password)signUpRequest.Password);

      await _userAccountRepository.InsertAsync(newAccount);
      
      throw new NotImplementedException();
   }
}