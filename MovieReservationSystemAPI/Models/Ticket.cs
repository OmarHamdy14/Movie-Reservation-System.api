using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationSystemAPI.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        [Required]
        public double PricePaid { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }  // use of it ?

        [Required]
        public Guid MovieScheduleId { get; set; }
        [ForeignKey("MovieScheduleId")]
        public MovieSchedule MovieSchedule { get; set; }

        [Required]
        public Guid SeatId { get; set; }
        [ForeignKey("SeatId")]
        public Seat Seat { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsBooked { get; set; }
        public DateTime? Lock { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public string? StripeSessionId { get; set; }


        //public Guid TheaterId { get; set; }
        //public Theater Theater { get; set; }
    }
}
