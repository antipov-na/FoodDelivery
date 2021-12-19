using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UseCases.Core.Images
{
    public interface IImageService
    {
        Task<CloudinaryApiResult> AddImage(IFormFile file);
        Task<string> RemoveImage(string id);
        Task<GetResourceResult> GetImage(string id);
    }
}