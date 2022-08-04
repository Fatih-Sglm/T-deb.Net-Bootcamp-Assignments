using TödebBootcampAssignment4.DTOs.AuthDto;

namespace TödebBootcampAssignment4.BusinessLayer.Features.Abstract
{
    public interface IAuthService
    {
        TokenDto Login(LoginDto loginDto);
    }
}
