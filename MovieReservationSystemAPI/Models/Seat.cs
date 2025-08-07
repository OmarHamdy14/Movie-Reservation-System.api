using MovieReservationSystemAPI.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationSystemAPI.Models
{
    public class Seat
    {
        public Guid Id { get; set; }
        [Required]
        public int SeatNum { get; set; }
        [Required]
        public SeatType SeatType { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Guid TheaterId { get; set; }
        [ForeignKey("TheaterId")]
        public Theater Theater { get; set; }



        //public int TheaterNum { get; set; }
        /*public  Guid MovieScheduleId { get; set; }
        public MovieSchedule MovieSchedule { get; set; }*/
        // public ICollection<Ticket> Tickets { get; set; } // ??
    }
}
