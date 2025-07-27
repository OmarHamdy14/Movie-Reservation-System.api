namespace MovieReservationSystemAPI.Models
{
    public class MovieSchedule
    {
        public Guid Id { get; set; }
        public DateTime StartingDate { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid TheaterId { get; set; }
        public Theater Theater { get; set; }

    }
}
