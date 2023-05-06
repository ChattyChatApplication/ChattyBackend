using App.Dtos.Requests;
using Core.ValueObjects.Account;
using Domain.Contracts.Database.Repositories;
using FluentValidation;

namespace App.Validations;

public class SignUpRequestValidator : AbstractValidator<SignUpRequestDto>
{
   [Obsolete("Obsolete")]
   public SignUpRequestValidator(IUserAccountRepository userAccountRepository)
   {
      RuleFor(sur => sur.Username)
         .Cascade(CascadeMode.StopOnFirstFailure)
         .Must(Username.IsValid)
         .WithMessage(Username.MessageRegex)
         .MustAsync(async (usn, _) => !await userAccountRepository.IsUsernameExistAsync((Username)usn))
         .WithMessage("username is duplicate");

      RuleFor(sur => sur.Email)
         .Cascade(CascadeMode.StopOnFirstFailure)
         .Must(Email.IsValid)
         .WithMessage("invalid email format")
         .MustAsync(async (eml, _) => !await userAccountRepository.IsEmailExistAsync((Email)eml))
         .WithMessage("email is duplicated");

      RuleFor(sur => sur.Password)
         .Must(Password.IsValid)
         .WithMessage(Password.RegexMessage);
   }
}