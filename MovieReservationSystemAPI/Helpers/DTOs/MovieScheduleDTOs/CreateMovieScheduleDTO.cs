namespace MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs
{
    public class CreateMovieScheduleDTO
    {
        public DateTime StartingDate { get; set; }
        public Guid MovieId { get; set; }
        public Guid TheaterId { get; set; }
        //public ICollection<Ticket> Tickets { get; set; }
    }
}
