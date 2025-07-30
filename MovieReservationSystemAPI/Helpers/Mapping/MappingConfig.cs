using MovieReservationSystemAPI.Helpers.DTOs.AccountDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.RoleDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.SeatDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.TheaterDTOs;
using MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs;

namespace MovieReservationSystemAPI.Helpers.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Movie, CreateMovieDTO>().ReverseMap();
            CreateMap<Movie, UpdateMovieDTO>().ReverseMap();

            CreateMap<MovieSchedule, CreateMovieScheduleDTO>().ReverseMap();
            CreateMap<MovieSchedule, UpdateMovieScheduleDTO>().ReverseMap();

            CreateMap<Seat, CreateSeatDTO>().ReverseMap();
            CreateMap<Seat, UpdateSeatDTO>().ReverseMap();

            CreateMap<Theater, CreateTheaterDTO>().ReverseMap();
            CreateMap<Theater, UpdateTheaterDTO>().ReverseMap();

            CreateMap<Ticket, CreateTicketDTO>().ReverseMap();
            CreateMap<Ticket, UpdateMovieDTO>().ReverseMap();

            CreateMap<IdentityRole, CreateRoleDTO>().ReverseMap();
            CreateMap<IdentityRole, CreateRoleDTO>().ReverseMap();

            CreateMap<ApplicationUser, RegisterationDTO>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserDTO>().ReverseMap();
        }
    }
}
