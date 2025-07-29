namespace MovieReservationSystemAPI.Helpers.DTOs.SeatDTOs
{
    public class CreateSeatDTO
    {
        public int SeatNum { get; set; }
        public string Type { get; set; }
        public Guid TheaterId { get; set; }
        //public ICollection<Ticket> Tickets { get; set; }

    }
}
