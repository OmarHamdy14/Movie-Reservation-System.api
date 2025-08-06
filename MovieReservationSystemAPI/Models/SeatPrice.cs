using MovieReservationSystemAPI.Helpers.Enums;

namespace MovieReservationSystemAPI.Models
{
    public class SeatPrice
    {
        public Guid Id { get; set; }
        public SeatType seatType { get; set; }
        public double Price { get; set; }
        public Guid MovieScheduleId { get; set; }
        public MovieSchedule movieSchedule { get; set; }
    }
}