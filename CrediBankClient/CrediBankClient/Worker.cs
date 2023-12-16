namespace CrediBankClient
{
    public class Worker(ILogger<Worker> logger, CrediBankGateway crediBankGateway) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("Requesting Check at: {time}", DateTimeOffset.Now);
                }

                string creditAccountID = "1234567890123456";
                int debitValue = 100;

                var check = await crediBankGateway.GetCheckAsync(creditAccountID, debitValue);

                // TODO: do something with check

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
