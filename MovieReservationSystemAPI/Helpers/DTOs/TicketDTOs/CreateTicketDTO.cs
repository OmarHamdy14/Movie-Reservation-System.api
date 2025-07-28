namespace MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs
{
    public class CreateTicketDTO
    {
        public double Price { get; set; }
        public string UserId { get; set; }
        public Guid TheaterId { get; set; }
        public Guid MovieScheduleId { get; set; }
        public Guid SeatId { get; set; }
    }
}
