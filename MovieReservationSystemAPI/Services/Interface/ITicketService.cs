using MovieReservationSystemAPI.Helpers.DTOs.BookingDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs;

namespace MovieReservationSystemAPI.Services.Interface
{
    public interface ITicketService
    {
        Task<Ticket> GetById(Guid Id);
        Task<List<Ticket>> GetAllByUserId(string UserId);
        //Task<List<Ticket>> GetAllByTheaterId(Guid TheaterId);
        Task<List<Ticket>> GetAllByMovieScheduleIdId(Guid MovieScheduleIdId);
        Task<List<Ticket>> GetAllBySeatId(Guid SeatId);
        Task<CreateCheckoutSessionResponse> CreateCheckoutSession(BookingRequestDTO model);
        //Task<bool> LockTicket(Ticket seat);
        //Task<bool> BookTicket(Ticket ticket);
        Task<Ticket> Create(CreateTicketDTO model);
        Task<Ticket> Update(Ticket Ticket, UpdateTicketDTO model);
        Task Delete(Ticket Ticket);
    }
}
