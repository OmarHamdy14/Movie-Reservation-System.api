using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Models
{
    public class Theater
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int TotalSeatsNum { get; set; }
        public ICollection<MovieSchedule> MovieSchedules { get; set; }
        public ICollection<Seat> Seats { get; set; }
        
        
        //public ICollection<Ticket> Tickets { get; set; } 
    }
}
