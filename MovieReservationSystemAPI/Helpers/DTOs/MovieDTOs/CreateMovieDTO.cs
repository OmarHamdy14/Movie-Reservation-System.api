namespace MovieReservationSystemAPI.Helpers.DTOs.MovieDTOs
{
    public class CreateMovieDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Describtion { get; set; }
        public string Duration { get; set; }
        public ICollection<MovieSchedule> movieSchedules { get; set; } // ??
        public ICollection<MovieImage> movieImages { get; set; }
    }
}
