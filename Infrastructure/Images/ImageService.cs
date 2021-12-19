using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using UseCases.Core.Images;

namespace Infrastructure.Images
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary _cloudinary;

        public ImageService(IOptions<CloudinaryApiSettings> config)
        {
            var cloudinaryAccount = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            _cloudinary = new Cloudinary(cloudinaryAccount);
        }

        public async Task<CloudinaryApiResult> AddImage(IFormFile file)
        {
            if (file.Length == 0)
            {
                return null;
            }

            await using var readStream = file.OpenReadStream();
            var parameters = new ImageUploadParams()
            {
                File = new FileDescription(file.Name, readStream),
                Transformation = new Transformation().Width(500).Height(500).Crop("fill")
            };
            var result = await _cloudinary.UploadAsync(parameters);
            if (result.Error != null)
            {
                throw new CloudinaryUploadException($"{result.Error.Message}");
            }

            return new CloudinaryApiResult
            {
                Id = result.PublicId,
                Url = result.Url.ToString()
            };
        }

        public async Task<string> RemoveImage(string id)
        {
            var parameters = new DeletionParams(id);
            var result = await _cloudinary.DestroyAsync(parameters);
            if (result.Error != null)
            {
                throw new EntityNotFoundException($"{result.Error.Message}");
            }

            return result.ToString();
        }

        public async Task<GetResourceResult> GetImage(string id)
        {
           return await _cloudinary.GetResourceAsync(id);
        }
    }
}
