using System;

namespace UseCases.Core.Authentication
{
    public class Jwt
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
