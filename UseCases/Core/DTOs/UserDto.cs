using System;

namespace UseCases.Core.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
