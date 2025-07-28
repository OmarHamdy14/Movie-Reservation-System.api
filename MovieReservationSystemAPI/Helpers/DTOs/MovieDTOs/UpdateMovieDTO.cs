namespace MovieReservationSystemAPI.Helpers.DTOs.MovieDTOs
{
    public class UpdateMovieDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Describtion { get; set; }
        public string Duration { get; set; }
        public ICollection<MovieSchedule> movieSchedules { get; set; } // ??
    }
}
