using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using MovieReservationSystemAPI.Helpers.Cloudinary;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IOptions<CloudinarySettings> options;
        public CloudinaryService()
        {
            var acc = new Account()
            {
                Cloud = options.Value.CloudName,
                ApiKey = options.Value.APIKey,
                ApiSecret = options.Value.APISecret
            };
            _cloudinary = new Cloudinary(acc);
        }
        public async Task<UploadResponse> UploadFile(IFormFile file)
        {
            if(file == null || file.Length < 0)
            {
                return new UploadResponse()
                {
                    IsSuccess = false,
                    Message = "Invalid File"
                };
            }
            var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream)
            };
            var UploadResult = await _cloudinary.UploadAsync(uploadParams);
            return new UploadResponse()
            {
                Url = UploadResult.SecureUri.AbsoluteUri,
                PublicId = UploadResult.PublicId,
                IsSuccess = true
            };
        }
        public async Task<DeleteResponse> DeleteFile(string FileId)
        {
            if (string.IsNullOrEmpty(FileId))
            {
                return new DeleteResponse()
                {
                    IsSuccess = false,
                    Message = "FileId is null"
                };
            }
            var deleteParams = new DeletionParams(FileId);
            var res = await _cloudinary.DestroyAsync(deleteParams);
            if(res.Result == "deleted")
            {
                return new DeleteResponse()
                {
                    IsSuccess = true,
                };
            }
            return new DeleteResponse()
            {
                IsSuccess = false,
                Message = $"Failed to delete this image!! {res.Error.Message}"
            };
        }
    }
}
