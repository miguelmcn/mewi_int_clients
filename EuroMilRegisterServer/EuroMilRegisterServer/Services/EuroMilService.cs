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
            return Task.FromResult(new RegisterReply
            {
                Message = $"{request.Key} registred"
            });
        }
    }
}
