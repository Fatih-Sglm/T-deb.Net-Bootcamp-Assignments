using System;

namespace TödebBootcampAssignment4.DTOs.AuthDto
{
    public class TokenDto
    {
        public string Token { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
