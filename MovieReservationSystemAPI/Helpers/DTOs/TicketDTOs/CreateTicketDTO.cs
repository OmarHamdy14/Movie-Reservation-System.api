using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs
{
    public class CreateTicketDTO
    {
        [Required]
        public double PricePaid { get; set; }
        [Required]
        public Guid MovieScheduleId { get; set; }
        [Required]
        public Guid SeatId { get; set; }
        [Required]
        public Guid TheaterId { get; set; }
    }
}
