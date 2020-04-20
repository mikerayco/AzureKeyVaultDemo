using System;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;

namespace AzureKeyVaultDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            var azureServiceTokenProvider1 =
                new AzureServiceTokenProvider();
            var kvc = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(
                    azureServiceTokenProvider1.KeyVaultTokenCallback));

            var kvBaseUrl = "<key vault url here>";
            var secret = await kvc.GetSecretAsync(
                kvBaseUrl, "secret key here");
            System.Console.WriteLine(secret.Value);
        }
    }
}
