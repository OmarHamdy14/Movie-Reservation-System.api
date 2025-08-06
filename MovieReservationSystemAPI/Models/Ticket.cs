using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public double PricePaid { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } 
        
        public Guid MovieScheduleId { get; set; }
        public MovieSchedule MovieSchedule { get; set; }

        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }

        public bool IsBooked { get; set; }
        public DateTime? Lock { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public string StripeSessionId { get; set; }


        //public Guid TheaterId { get; set; }
        //public Theater Theater { get; set; }
    }
}
