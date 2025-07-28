namespace MovieReservationSystemAPI.Helpers.DTOs.SeatDTOs
{
    public class UpdateSeatDTO
    {
        public int SeatNum { get; set; }
        public Guid TheaterId { get; set; }
    }
}
