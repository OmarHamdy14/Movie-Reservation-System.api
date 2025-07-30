using AutoMapper;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IEntityBaseRepository<Ticket> _base;
        private readonly IMapper _mapper;
        public TicketService(IEntityBaseRepository<Ticket> @base, IMapper mapper)
        {
            _base = @base;
            _mapper = mapper;
        }
        public async Task<Ticket> GetById(Guid Id)
        {
            return await _base.Get(ms => ms.Id == Id, "Seat,MovieSchedule,User,Theater");
        }
        public async Task<List<Ticket>> GetAllByUserId(string UserId)
        {
            return await _base.GetAll(ms => ms.UserId == UserId, "Seat,MovieSchedule,User,Theater");
        }
        public async Task<List<Ticket>> GetAllByTheaterId(Guid TheaterId)
        {
            return await _base.GetAll(ms => ms.TheaterId == TheaterId, "Seat,MovieSchedule,User,Theater");
        }
        public async Task<List<Ticket>> GetAllByMovieScheduleIdId(Guid MovieScheduleIdId)
        {
            return await _base.GetAll(ms => ms.MovieScheduleId == MovieScheduleIdId, "Seat,MovieSchedule,User,Theater");
        }
        public async Task<List<Ticket>> GetAllBySeatId(Guid SeatId)
        {
            return await _base.GetAll(ms => ms.SeatId == SeatId, "Seat,MovieSchedule,User,Theater");
        }
        public async Task<Ticket> Create(CreateTicketDTO model)
        {
            var Ticket = _mapper.Map<Ticket>(model);
            await _base.Create(Ticket);
            return Ticket;
        }
        public async Task<Ticket> Update(Ticket Ticket, UpdateTicketDTO model)
        {
            _mapper.Map(Ticket, model);
            await _base.Update(Ticket);
            return Ticket;
        }
        public async Task Delete(Ticket Ticket)
        {
            await _base.Remove(Ticket);
        }
    }
}
