using System;

namespace UseCases.Core.Authentication
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set;}
    }
}
