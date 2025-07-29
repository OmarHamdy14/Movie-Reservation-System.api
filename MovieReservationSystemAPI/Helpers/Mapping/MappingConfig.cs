namespace MovieReservationSystemAPI.Helpers.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Movie, CreateMovieDTO>().ReverseMap();
        }
    }
}
