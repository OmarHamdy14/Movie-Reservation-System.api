namespace MovieReservationSystemAPI.Helpers.DTOs.BookingDTOs
{
    public class CreateCheckoutSessionResponse
    {
        public bool IsSuccess { get; set; }
        public string? Msg { get; set; }
        public string? sessionId { get; set; }
        public string? url { get; set; }
    }
}
