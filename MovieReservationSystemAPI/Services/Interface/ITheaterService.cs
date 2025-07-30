using MovieReservationSystemAPI.Helpers.DTOs.TheaterDTOs;

namespace MovieReservationSystemAPI.Services.Interface
{
    public interface ITheaterService
    {
        Task<Theater> GetById(Guid Id);
        Task<List<Theater>> GetAll();
        Task<Theater> Create(CreateTheaterDTO model);
        Task<Theater> Update(Theater Theater, UpdateTheaterDTO model);
        Task Delete(Theater Theater);
    }
}
