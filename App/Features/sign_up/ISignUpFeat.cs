using App.Dtos.Requests;
using Domain.Services;

namespace App.Features;

public interface ISignUpFeat
{
   public Task<AuthToken> Handle(SignUpRequestDto signUpRequest);
}