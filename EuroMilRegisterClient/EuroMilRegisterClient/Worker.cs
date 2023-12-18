using Grpc.Net.Client;

namespace EuroMilRegisterClient
{
    public class Worker(ILogger<Worker> logger, EuroMilRegisterGateway euroMilRegisterGateway) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("Registering at: {time}", DateTimeOffset.Now);
                }

                var register = new RegisterRequest
                {
                    Checkid = "1234567890123456",
                    Key = Guid.NewGuid().ToString()
                };

                var reply = await euroMilRegisterGateway.RegisterAsync(register);

                logger.LogInformation(reply.Message);

                // TODO: do something with check

                await Task.Delay(1000, stoppingToken);
            }
        }

        
    }
}
