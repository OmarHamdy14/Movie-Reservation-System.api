using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs
{
    public class CreateMovieScheduleDTO
    {
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public Guid MovieId { get; set; }
        [Required]
        public Guid TheaterId { get; set; }
        //public ICollection<Ticket> Tickets { get; set; }
    }
}
