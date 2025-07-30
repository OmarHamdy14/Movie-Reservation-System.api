using AutoMapper;
using MovieReservationSystemAPI.Helpers.DTOs.MovieDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IEntityBaseRepository<Movie> _base;
        private readonly IMapper _mapper;
        public MovieService(IEntityBaseRepository<Movie> @base, IMapper mapper)
        {
            _base = @base;
            _mapper = mapper;
        }
        public async Task<Movie> GetById(Guid Id)
        {
            return await _base.Get(ms => ms.Id == Id, "movieSchedules,movieImages");
        }
        public async Task<List<Movie>> GetAll()
        {
            return await _base.GetAll(null,"movieSchedules,movieImages");
        }
        public async Task<Movie> Create(CreateMovieDTO model)
        {
            /*var movie = new Movie()  
            {
                Name = model.Name,
                Category = model.Category,
                Describtion = model.Describtion,
                Duration = model.Duration,
                movieSchedules = model.movieSchedules.Select(m => new MovieSchedule()
                {
                    StartingDate = m.StartingDate,
                    MovieId = m.MovieId,
                    TheaterId = m.TheaterId
                }).ToList()
            };*/
            var movie = _mapper.Map<Movie>(model);
            await _base.Create(movie);
            return movie;
        }
        public async Task<Movie> Update(Movie Movie, UpdateMovieDTO model) // ?
        {
            _mapper.Map(Movie, model);
            await _base.Update(Movie);
            return Movie;
        }
        public async Task Delete(Movie Movie)
        {
            await _base.Remove(Movie);
        }
    }
}
