namespace MovieReservationSystemAPI.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions op) : base(op)
        {

        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieSchedule> movieSchedules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<MovieImage> movieImages { get; set; }
    }
}
