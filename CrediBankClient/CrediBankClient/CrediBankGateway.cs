using System.Net.Http.Json;

namespace CrediBankClient
{
    public class CrediBankGateway(ApplicationOptions options, ILogger<CrediBankGateway> logger)
    {
        public async Task<IEnumerable<DigitalCheckDataModel>?> GetCheckAsync(string creditAccountId, int debitValue)
        {
            using HttpClient httpClient = new HttpClient();

            string apiUrl = options.CredBankUrl
                .Replace("{credit_account_id}", creditAccountId)
                .Replace("{value}", debitValue.ToString());

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var checks = await response.Content.ReadFromJsonAsync<IEnumerable<DigitalCheckDataModel>>();

                    if (checks == null)
                    {
                        throw new Exception("Cannot deselize response");
                    }

                    foreach (var check in checks)
                    {
                        logger.LogInformation($"Check ID: {check.CheckID} emited at {check.Date}");
                    }                   

                    return checks;
                }
                else
                {
                    logger.LogError($"Error: {response.StatusCode} - {response.ReasonPhrase}");

                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical($"Exception: {ex.Message}");

                return null;
            }
        }
    }
}
