using Microsoft.AspNetCore.Http;

namespace UseCases.Core.DTOs
{
    public class EditImageDto
    {
        public string Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
