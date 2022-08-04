using Bussines.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using TödebBootcampAssignment4.BusinessLayer.Configuration.Auth;
using TödebBootcampAssignment4.BusinessLayer.Configuration.Validations;
using TödebBootcampAssignment4.BusinessLayer.Features.Abstract;
using TödebBootcampAssignment4.DTOs.AuthDto;

namespace TödebBootcampAssignment4.BusinessLayer.Features.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerService _customerService;
        private readonly IConfiguration _configuration;
        public AuthService(ICustomerService customerService, IConfiguration configuration)
        {
            _customerService = customerService;
            _configuration = configuration;
        }
        public TokenDto Login(LoginDto loginDto)
        {
            var validator = new LoginUserDtoValidation();
            validator.Validate(loginDto).ThrowIfException();
            var user = _customerService.Get(x => x.Mail == loginDto.Email);
            if (user.Password == loginDto.Password)
            {
                try
                {
                    return CreateJwt.GetJtwtToken(_configuration, user);

                }
                catch (Exception)
                {
                    throw new Exception("Giriş Yapılamadı.Lütfen Tekrar deneyiniz.");
                }
            }
            else
                throw new Exception("Giriş Yapılamadı.Lütfen Tekrar deneyiniz.");
        }
    }
}
