namespace MovieReservationSystemAPI.Models
{
    public class Theater
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalSeatsNum { get; set; }
        public ICollection<MovieSchedule> MovieSchedules { get; set; }
        public ICollection<Seat> Seats { get; set; }
        //public ICollection<Ticket> Tickets { get; set; } 
    }
}
