using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.TicketDTOs
{
    public class UpdateTicketDTO
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public Guid MovieScheduleId { get; set; }
        [Required]
        public Guid SeatId { get; set; }
        [Required]
        public Guid TheaterId { get; set; }
    }
}
