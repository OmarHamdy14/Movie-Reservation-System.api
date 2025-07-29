using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;

namespace MovieReservationSystemAPI.Services.Interface
{
    public interface IMovieScheduleService
    {
        Task<MovieSchedule> GetById(Guid Id);
        Task<List<MovieSchedule>> GetAllByMovieId(Guid MovieId);
        Task<List<MovieSchedule>> GetAllByTheaterId(Guid TheaterId);
        Task<MovieSchedule> Create(CreateMovieScheduleDTO model);
        Task<MovieSchedule> Update(MovieSchedule schedule, UpdateMovieScheduleDTO model);
        Task Delete(MovieSchedule schedule);
    }
}
