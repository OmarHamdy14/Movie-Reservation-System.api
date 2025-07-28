

using MovieReservationSystemAPI.Base.Implementation;
using MovieReservationSystemAPI.Base.Interface;

namespace MovieReservationSystemAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IMovieScheduleService, MovieScheduleService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<ISeatService, SeatService>();
            builder.Services.AddScoped<ITheaterService, TheaterService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IEntityBaseRepository<Movie>, EntityBaseRepository<Movie>>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}