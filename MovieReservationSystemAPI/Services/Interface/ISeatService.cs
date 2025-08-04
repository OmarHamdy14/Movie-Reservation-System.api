using MovieReservationSystemAPI.Helpers.DTOs.SeatDTOs;

namespace MovieReservationSystemAPI.Services.Interface
{
    public interface ISeatService
    {
        Task<Seat> GetById(Guid Id);
        Task<List<Seat>> GetAllByTheaterId(Guid TheaterId);
        Task<bool> LockSeat(Seat seat);
        Task<Seat> Create(CreateSeatDTO model);
        Task<Seat> Update(Seat Seat, UpdateSeatDTO model);
        Task Delete(Seat Seat);
    }
}
