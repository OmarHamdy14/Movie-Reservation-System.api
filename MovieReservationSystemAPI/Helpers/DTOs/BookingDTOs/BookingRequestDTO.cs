namespace MovieReservationSystemAPI.Helpers.DTOs.BookingDTOs
{
    public class BookingRequestDTO
    {
        public Guid SeatId { get; set; }
        public Guid MovieScheduleId { get; set; }
    }
}
