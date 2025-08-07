using MovieReservationSystemAPI.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationSystemAPI.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public MovieCategory Category { get; set; }
        [Required]
        public string Describtion { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public ICollection<MovieSchedule> movieSchedules { get; set; }
        public Guid MovieImageId { get; set; }
        [ForeignKey("MovieImageId")]
        public MovieImage movieImage { get; set; } // is this required?


        // rate ??
        //public ICollection<Theater> Theaters { get; set; }
    }
}
