using Microsoft.AspNetCore.Http;

namespace App.Features;

public class SignUpRequestDto
{
   public string Username { get; set; } = null!;
   public string Email { get; set; } = null!;
   public string Password { get; set; } = null!;
   public string Fullname { get; set; } = null!;
   public IFormFile Avatar { get; set; } = null!;
}