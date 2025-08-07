using AutoMapper;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;
using MovieReservationSystemAPI.Models;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class MovieScheduleService : IMovieScheduleService
    {
        private readonly IEntityBaseRepository<MovieSchedule> _base;
        private readonly IEntityBaseRepository<Ticket> _baseTicket;
        private readonly IEntityBaseRepository<Seat> _baseSeat;
        private readonly IMapper _mapper; 
        public MovieScheduleService(IEntityBaseRepository<MovieSchedule> @base, IMapper mapper, IEntityBaseRepository<Ticket> baseTicket, IEntityBaseRepository<Seat> baseSeat)
        {
            _base = @base;
            _mapper = mapper;
            _baseTicket = baseTicket;
            _baseSeat = baseSeat;
        }
        public async Task<MovieSchedule> GetById(Guid Id)
        {
            return await _base.Get(ms => ms.Id == Id,"Movie,Theater");
        }
        public async Task<List<MovieSchedule>> GetAllByMovieId(Guid MovieId)
        {
            return await _base.GetAll(ms => ms.MovieId == MovieId, "Movie,Theater");
        }
        public async Task<List<MovieSchedule>> GetAllByTheaterId(Guid TheaterId)
        {
            return await _base.GetAll(ms => ms.TheaterId == TheaterId, "Movie,Theater");
        }
        public async Task<MovieSchedule> Create(CreateMovieScheduleDTO model)
        {
            var schedule = _mapper.Map<MovieSchedule>(model);
            await _base.Create(schedule);
            var seats = await _baseSeat.GetAll(s => s.TheaterId == model.TheaterId);
            foreach(var seat in seats)                        // ***
            {
                var ticket = new Ticket()
                {
                    MovieScheduleId = schedule.Id,
                    SeatId = seat.Id,
                    IsBooked = false,
                    Lock = null,
                    PricePaid = seat.Price
                };
                await _baseTicket.Create(ticket);
            }
            return schedule;
        }
        public async Task<MovieSchedule> Update(MovieSchedule schedule, UpdateMovieScheduleDTO model)
        {
            _mapper.Map(schedule, model);
            await _base.Update(schedule);
            return schedule;
        }
        public async Task Delete(MovieSchedule schedule)
        {
            await _base.Remove(schedule);
        }
    }
}
