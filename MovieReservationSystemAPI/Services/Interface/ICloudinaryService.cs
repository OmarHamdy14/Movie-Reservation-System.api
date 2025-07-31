using MovieReservationSystemAPI.Helpers.Cloudinary;

namespace MovieReservationSystemAPI.Services.Interface
{
    public interface ICloudinaryService
    {
        Task<UploadResponse> UploadFile(IFormFile file);
        Task<DeleteResponse> DeleteFile(string FileId);
    }
}
