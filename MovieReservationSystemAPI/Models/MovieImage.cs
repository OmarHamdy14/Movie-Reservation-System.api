namespace MovieReservationSystemAPI.Models
{
    public class MovieImage
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Alternative { get; set; }
        public int order { get; set; }
    }
}
