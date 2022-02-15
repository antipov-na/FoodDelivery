using Microsoft.AspNetCore.Http;

namespace UseCases.Core.DTOs
{
    public class CreateImageDto
    {
        public IFormFile Image { get; set; }
    }
}
