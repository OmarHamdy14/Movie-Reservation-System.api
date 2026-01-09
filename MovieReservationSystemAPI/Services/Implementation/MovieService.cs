using AutoMapper;
using MovieReservationSystemAPI.Helpers.DTOs.MovieDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;

namespace MovieReservationSystemAPI.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IEntityBaseRepository<Movie> _base;
        private readonly IEntityBaseRepository<MovieImage> _baseMovieImage;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IMapper _mapper;
        public MovieService(IEntityBaseRepository<Movie> @base, IMapper mapper, ICloudinaryService cloudinaryService, IEntityBaseRepository<MovieImage> baseMovieImage)
        {
            _base = @base;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
            _baseMovieImage = baseMovieImage;
        }
        public async Task<Movie> GetById(Guid Id)
        {
            return await _base.Get(ms => ms.Id == Id, "movieSchedules,movieImages");
        }
        public async Task<List<Movie>> GetAll()
        {
            return await _base.GetAll(null,"movieSchedules,movieImages");
        }
        public async Task<Movie> Create(CreateMovieDTO model, IFormFile file)
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
            var res = await _cloudinaryService.UploadFile(file);
            var movieImage = new MovieImage()
            {
                MovieId = movie.Id,
                ImageUrl = res.Url,
                PublicId = res.PublicId,
                Alternative = movie.Name
            };
            await _baseMovieImage.Create(movieImage);
            return movie;
        }
        public async Task<Movie> Update(Movie Movie, UpdateMovieDTO model, IFormFile file) // how to update photo if there is already a photo
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
