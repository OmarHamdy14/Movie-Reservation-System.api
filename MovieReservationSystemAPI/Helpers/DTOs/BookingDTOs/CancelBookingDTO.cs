using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.BookingDTOs
{
    public class CancelBookingDTO
    {
        [Required]
        public Guid TicketId { get; set; }
    }
}
