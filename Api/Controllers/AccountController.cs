using App.Features;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
   private readonly ISignUpFeat _signUpFeat;

   public AccountController(ISignUpFeat signUpFeat)
   {
      _signUpFeat = signUpFeat;
   }
   
   [HttpPost]
   public async Task<IActionResult> SignUpAsync([FromForm] SignUpRequestDto signUpRequest)
   {
      try
      {
         var authToken = await _signUpFeat.HandleAsync(signUpRequest);
         return StatusCode(201, new
         {
            authToken
         });
      }
      catch (ValidationException e)
      {
         return BadRequest(e.Errors);
      }
   }
}