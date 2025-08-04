namespace MovieReservationSystemAPI.Background_Services
{
    public class SeatExpiredLocksCleanService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public SeatExpiredLocksCleanService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var expiredLocks = await context.Seats
                    .Where(s => s.Lock < DateTime.UtcNow)
                    .ToListAsync();

                foreach (var seat in expiredLocks)
                    seat.Lock = null;

                await context.SaveChangesAsync();

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
