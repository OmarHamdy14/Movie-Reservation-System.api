namespace MovieReservationSystemAPI.Models
{
    public class Seat
    {
        public Guid Id { get; set; }
        //public int TheaterNum { get; set; }
        public int SeatNum { get; set; }
        public Guid TheaterId { get; set; }
        public Theater Theater { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
