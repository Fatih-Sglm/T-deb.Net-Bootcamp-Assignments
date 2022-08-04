using FluentValidation;
using TödebBootcampAssignment4.DTOs.AuthDto;

namespace TödebBootcampAssignment4.BusinessLayer.Configuration.Validations
{
    public class LoginUserDtoValidation : AbstractValidator<LoginDto>
    {
        public LoginUserDtoValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Mail Kısmı Boş Geçilemez")
                .EmailAddress().WithMessage("Lütfen Geçerli Bir E-mail Adresi Giriniz!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Kısmı Boş Geçilemez");
        }
    }
}
