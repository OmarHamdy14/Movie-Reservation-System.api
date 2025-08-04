
using Microsoft.Extensions.DependencyInjection;
using MovieReservationSystemAPI.Background_Services;
using MovieReservationSystemAPI.Helpers.Cloudinary;
using System.Text;

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
            builder.Services.AddScoped<IMovieImageService, MovieImageService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<ISeatService, SeatService>();
            builder.Services.AddScoped<ITheaterService, TheaterService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IEntityBaseRepository<Movie>, EntityBaseRepository<Movie>>();
            builder.Services.AddScoped<IEntityBaseRepository<MovieImage>, EntityBaseRepository<MovieImage>>();
            builder.Services.AddScoped<IEntityBaseRepository<MovieSchedule>, EntityBaseRepository<MovieSchedule>>();
            builder.Services.AddScoped<IEntityBaseRepository<Seat>, EntityBaseRepository<Seat>>();
            builder.Services.AddScoped<IEntityBaseRepository<Theater>, EntityBaseRepository<Theater>>();
            builder.Services.AddScoped<IEntityBaseRepository<Ticket>, EntityBaseRepository<Ticket>>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
            builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));

            builder.Services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = true;
                op.SaveToken = true;
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]))
                };

            });


            builder.Services.AddHostedService<SeatExpiredLocksCleanService>();

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