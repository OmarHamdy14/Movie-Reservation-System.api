namespace MovieReservationSystemAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Ticket> Tickets { get; set; } 
    }
}
