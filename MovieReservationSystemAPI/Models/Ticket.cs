namespace MovieReservationSystemAPI.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string UserId { get; set; }
        public Guid MovieScheduleId { get; set; }
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
        public MovieSchedule MovieSchedule { get; set; }
        public ApplicationUser User { get; set; }   
        //public Guid TheaterId { get; set; }
        //public Theater Theater { get; set; }
    }
}
