using MovieReservationSystemAPI.Helpers.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.SeatDTOs
{
    public class UpdateSeatDTO
    {
        [Required]
        public int SeatNum { get; set; }
        [Required]
        public SeatType Type { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Guid TheaterId { get; set; }
        //public ICollection<Ticket> Tickets { get; set; }
    }
}
