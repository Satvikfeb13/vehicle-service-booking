using VehicleService.API.Services.Interfaces;

namespace VehicleService.API.BackgroundJobsScheduler
{
    public class MechanicAllocationWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<MechanicAllocationWorker> _logger;

        public MechanicAllocationWorker(
            IServiceScopeFactory scopeFactory,
            ILogger<MechanicAllocationWorker> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var allocator = scope.ServiceProvider.GetRequiredService<IMechanicAllocator>();

                    await allocator.AllocatePendingBookingsAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while allocating mechanics");
                }

                // Run every 15 seconds for testing
                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }
        }
    }

}
