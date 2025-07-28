namespace MovieReservationSystemAPI.Helpers.DTOs.SeatDTOs
{
    public class CreateSeatDTO
    {
        public int SeatNum { get; set; }
        public Guid TheaterId { get; set; }
    }
}
