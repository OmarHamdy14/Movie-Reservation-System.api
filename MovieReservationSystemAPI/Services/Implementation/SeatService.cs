using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.SeatDTOs;
using MovieReservationSystemAPI.Models;
using MovieReservationSystemAPI.SignalR;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class SeatService : ISeatService
    {
        private readonly IEntityBaseRepository<Seat> _base;
        private readonly IMapper _mapper;
        public SeatService(IEntityBaseRepository<Seat> @base, IMapper mapper)
        {
            _base = @base;
            _mapper = mapper;
        }
        public async Task<Seat> GetById(Guid Id)
        {
            return await _base.Get(ms => ms.Id == Id, "Theater,Tickets");
        }
        public async Task<List<Seat>> GetAllByTheaterId(Guid TheaterId)
        {
            return await _base.GetAll(ms => ms.TheaterId == TheaterId, "Theater,Tickets");
        }


        public async Task<Seat> Create(CreateSeatDTO model)
        {
            var Seat = _mapper.Map<Seat>(model);
            await _base.Create(Seat);
            return Seat;
        }
        public async Task<Seat> Update(Seat Seat, UpdateSeatDTO model)
        {
            _mapper.Map(Seat, model);
            await _base.Update(Seat);
            return Seat;
        }
        public async Task Delete(Seat Seat)
        {
            await _base.Remove(Seat);
        }
    }
}
