using AutoMapper;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.TheaterDTOs;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class TheaterService : ITheaterService
    {
        private readonly IEntityBaseRepository<Theater> _base;
        private readonly IMapper _mapper;
        public TheaterService(IEntityBaseRepository<Theater> @base, IMapper mapper)
        {
            _base = @base;
            _mapper = mapper;
        }
        public async Task<Theater> GetById(Guid Id)
        {
            return await _base.Get(ms => ms.Id == Id, "Seats,MovieSchedules");
        }
        public async Task<List<Theater>> GetAll()
        {
            return await _base.GetAll(null, "Seats,MovieSchedules");
        }
        public async Task<Theater> Create(CreateTheaterDTO model)
        {
            var Theater = _mapper.Map<Theater>(model);
            await _base.Create(Theater);
            return Theater;
        }
        public async Task<Theater> Update(Theater Theater, UpdateTheaterDTO model)
        {
            _mapper.Map(Theater, model);
            await _base.Update(Theater);
            return Theater;
        }
        public async Task Delete(Theater Theater)
        {
            await _base.Remove(Theater);
        }
    }
}
