using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace App.Commons.Validations;

public class ImageValidator : AbstractValidator<IFormFile>
{
   public ImageValidator()
   {
      RuleFor(img => img.ContentType)
         .Must(fileType =>
            fileType.Equals("image/jpeg") ||
            fileType.Equals("image/jpg") ||
            fileType.Equals("image/png")
         );
   }
}