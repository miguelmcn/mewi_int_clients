using Grpc.Net.Client;

namespace EuroMilRegisterClient
{
    public class Worker(ILogger<Worker> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("Registering at: {time}", DateTimeOffset.Now);
                }

                using var channel = GrpcChannel.ForAddress("http://localhost:5246");
                var client = new Euromil.EuromilClient(channel);
                var reply = await client.RegisterEuroMilAsync(
                                  new RegisterRequest
                                  {
                                      Checkid = "1234567890123456",
                                      Key = Guid.NewGuid().ToString()
                                  });

                logger.LogInformation(reply.Message);


                // TODO: do something with check

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
