using FluentValidation;
using System.Text.RegularExpressions;
using TödebBootcampAssignment4.DTOs.Customer;

namespace TödebBootcampAssignment4.BusinessLayer.Configuration.Validations
{
    public class CreateCustomerValidate : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerValidate()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Lütfen Adınızı Yazınız")
                .MaximumLength(15).WithMessage("İsminiz En fazla 15 karakterden oluşabilir");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lütfen Soyadınızı Yazınız")
                .MaximumLength(15).WithMessage("Soyadınız En fazla 15 karakterden oluşabilir");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen Adınızı Yazınız")
                .EmailAddress().WithMessage("Lütfen Geçerli Bir E-mail Adresi Giriniz!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Lütfen Telefon Numaranızı giriniz")
                .Length(10).WithMessage("Telefon Numarası 10 Haneli olmak zorunda ")
                .Matches(new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$"))
                .WithMessage("PhoneNumber not valid");
            RuleFor(x => x.Password).Matches(@"[A-Z]+").WithMessage("Şİfreniz Mutlaka bir Büyük Harf İçermeli.");
            RuleFor(x => x.RePassword).Equal(x => x.Password).WithMessage("Şifreler Eşleşmiyor");
        }
    }
}
