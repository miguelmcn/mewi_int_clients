using EuroMilRegisterClient;
using Grpc.Core;
using Microsoft.AspNetCore.Identity.Data;

namespace EuroMilRegisterClient.Services
{
    public class EuroMilService : Euromil.EuromilBase
    {
        private readonly ILogger<EuroMilService> _logger;
        public EuroMilService(ILogger<EuroMilService> logger)
        {
            _logger = logger;
        }

        public override Task<RegisterReply> RegisterEuroMil(RegisterRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Register Request received at {DateTimeOffset.Now.ToString()}");

            return Task.FromResult(new RegisterReply
            {
                Message = $"{request.Key} registred"
            });
        }
    }
}
