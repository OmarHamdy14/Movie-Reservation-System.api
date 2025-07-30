using AutoMapper;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class MovieScheduleService : IMovieScheduleService
    {
        private readonly IEntityBaseRepository<MovieSchedule> _base;
        private readonly IMapper _mapper; 
        public MovieScheduleService(IEntityBaseRepository<MovieSchedule> @base, IMapper mapper)
        {
            _base = @base;
            _mapper = mapper;
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
