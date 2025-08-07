using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationSystemAPI.Models
{
    public class MovieSchedule
    {
        public Guid Id { get; set; } // sshould put required here?
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public Guid MovieId { get; set; }
        [Required]
        public Guid TheaterId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("TheaterId")]
        public Theater Theater { get; set; }
        public ICollection<Ticket> Tickets { get; set; } 
        public ICollection<SeatPrice> SeatPrices { get; set; }
        
        
        
        //public ICollection<Seat> Seats { get; set; }  
    }
}
