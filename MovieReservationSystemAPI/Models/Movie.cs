namespace MovieReservationSystemAPI.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Describtion { get; set; }
        public string Duration { get; set; }
        // rate ??
        public ICollection<MovieSchedule> movieSchedules { get; set; }
        //public ICollection<Theater> Theaters { get; set; }
        public MovieImage movieImages { get; set; } // ?
    }
}
