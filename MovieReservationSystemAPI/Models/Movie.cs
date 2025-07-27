namespace MovieReservationSystemAPI.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Describtion { get; set; }
        public string Duration { get; set; }
        public ICollection<MovieSchedule> movieSchedules { get; set; }
    }
}
