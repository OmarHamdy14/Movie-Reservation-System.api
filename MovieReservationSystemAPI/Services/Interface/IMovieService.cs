using MovieReservationSystemAPI.Helpers.DTOs.MovieDTOs;

namespace MovieReservationSystemAPI.Services.Interface
{
    public interface IMovieService
    {
        Task<Movie> GetById(Guid Id);
        Task<List<Movie>> GetAll();
        Task<Movie> Create(CreateMovieDTO model, IFormFile file);
        Task<Movie> Update(Movie Movie, UpdateMovieDTO model, IFormFile file);
        Task Delete(Movie Movie);
    }
}
