using System.ComponentModel.DataAnnotations;

namespace MovieReservationSystemAPI.Helpers.DTOs.TheaterDTOs
{
    public class UpdateTheaterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int TotalSeatsNum { get; set; }
        //public ICollection<Seat> Seats { get; set; }
        //public ICollection<MovieSchedule> MovieSchedules { get; set; }
    }
}
