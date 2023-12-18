using Grpc.Net.Client;

namespace EuroMilRegisterClient
{
    public class EuroMilRegisterGateway(ApplicationOptions applicationOptions)
    {
        public async Task<RegisterReply> RegisterAsync(RegisterRequest register)
        {
            using var channel = GrpcChannel.ForAddress(applicationOptions.EuroMilAddresss);
            var client = new Euromil.EuromilClient(channel);

            return await client.RegisterEuroMilAsync(register);
        }
    }
}
