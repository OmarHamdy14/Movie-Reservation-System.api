using MovieReservationSystemAPI.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.MovieDTOs
{
    public class CreateMovieDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public MovieCategory Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        //public ICollection<MovieSchedule> movieSchedules { get; set; } // ??
        //public MovieImage movieImage { get; set; }
    }
}
