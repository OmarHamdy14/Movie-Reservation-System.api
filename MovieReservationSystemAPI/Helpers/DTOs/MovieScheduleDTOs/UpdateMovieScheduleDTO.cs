namespace MovieReservationSystemAPI.Helpers.DTOs.MovieScheduleDTOs
{
    public class UpdateMovieScheduleDTO
    {
        public DateTime StartingDate { get; set; }
        public Guid MovieId { get; set; }
        public Guid TheaterId { get; set; }
    }
}
